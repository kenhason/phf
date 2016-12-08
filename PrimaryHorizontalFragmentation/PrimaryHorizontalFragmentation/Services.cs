using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace PrimaryHorizontalFragmentation
{
    public class Services
    {
        public DataSet loadTableFromDatabase(DataSet ds,string connectionString, string tableName)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "SELECT * FROM " + tableName;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            ds = new DataSet();
            dataAdapter.Fill(ds, "Original");
            conn.Close();
            return ds;
        }

        public void generateDatabaseTable(string excelFilePath, string connectionString, string tableName)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = 
                "USE master IF EXISTS(SELECT * FROM sys.objects where name = '" +
                tableName +
                "' and type = 'u') DROP TABLE " + 
                tableName + 
                " SELECT * INTO " + 
                tableName + 
                " FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0','Excel 12.0; Database=" +
                excelFilePath + 
                "; HDR=YES; IMEX=1','SELECT * FROM [Sheet1$]')";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = conn;
            command.ExecuteNonQuery();
            conn.Close();
        }

        public DataSet generateFragments(string connectionString, string tableName, DataSet ds, List<string> minterms)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            foreach (string minterm in minterms)
            {
                string query = "SELECT * FROM " + tableName + " WHERE " + minterm;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(ds, minterm);
            }
            return ds;
        }

        public List<Models.predicate> getCompleteMininalPredicates(List<Models.attribute> relation, List<Models.predicate> pr) 
        {
            List<Models.predicate> pr_prime = new List<Models.predicate>();
            //Make set of predicates minimal by eleminate irrelevant predicate
            relation = eleminateDuplicatedAttributeNames(relation);
            List<Models.predicateGroup> predicateGroups = groupPredicatesByRelevantAttributes(relation, pr);
            List<Models.predicateGroup> completePredicateGroups = getCompletePredicateGroup(predicateGroups);
            if (completePredicateGroups.Count == getRelevantAttributes(relation).Count)
                pr_prime = convertPredicateGroupsToPredicateList(completePredicateGroups);
            return pr_prime;
        }

        public List<string> getMintermPredicates(List<Models.predicate> pr_prime)
        {
            List<Models.attribute> attributesOfCompleteMinimalPredicates = getAttributesFromCompleteMinimalPredicates(pr_prime);
            attributesOfCompleteMinimalPredicates = eleminateDuplicatedAttributeNames(attributesOfCompleteMinimalPredicates);
            List<Models.attribute> relevantAttributes = getRelevantAttributes(attributesOfCompleteMinimalPredicates);
            int sizeLimit = relevantAttributes.Count;

            List<List<Models.predicate>> groupedPredicatesList = GetAllCombinations(pr_prime);
            groupedPredicatesList.RemoveAll(predicates => isInvalid(sizeLimit, predicates));
            List<Models.minterm> minterms = convertGroupedPredicatesListToMinterm(groupedPredicatesList);
            List<string> mintermStrings = convertMintermsToStrings(minterms);
            return mintermStrings;
        }

        private List<string> convertMintermsToStrings(List<Models.minterm> minterms)
        {
            List<String> mintermStrings = new List<string>();
            foreach (Models.minterm minterm in minterms)
            {
                mintermStrings.Add(minterm.ToString());
            }
            return mintermStrings;
        }

        private List<Models.minterm> convertGroupedPredicatesListToMinterm(List<List<Models.predicate>> groupedPredicatesList)
        {
            List<Models.minterm> minterms = new List<Models.minterm>();
            foreach (List<Models.predicate> groupedPredicates in groupedPredicatesList)
            {
                Models.minterm minterm = new Models.minterm();
                minterm.simplePredicates = new List<Models.predicate>();
                foreach (Models.predicate predicate in groupedPredicates)
                {
                    minterm.simplePredicates.Add(predicate);
                }
                minterms.Add(minterm);
            }
            return minterms;
        }

        private static bool isInvalid(int sizeLimit, List<Models.predicate> predicates)
        {
            return 
                (predicates.Count > sizeLimit) ||
                (predicates.Count <=1) ||
                containsSameAttributes(predicates);
        }

        private static bool containsSameAttributes(List<Models.predicate> predicates)
        {
            bool containsSameAttributes = false;
            for (int i = 0; i < predicates.Count; i++)
            {
                for (int j = i + 1; j < predicates.Count; j++)
                {
                    if (predicates[i].attributeName == predicates[j].attributeName)
                        return true;
                }
            }
            return containsSameAttributes;
        }

        List<List<Models.predicate>> GetAllCombinations(List<Models.predicate> predicates)
        {
            List<List<Models.predicate>> combinations = new List<List<Models.predicate>>();
            // head
            combinations.Add(new List<Models.predicate>());
            combinations.Last().Add(predicates[0]);
            if (predicates.Count == 1)
                return combinations;
            // tail
            List<List<Models.predicate>> tailCombos = GetAllCombinations(predicates.Skip(1).ToList());
            tailCombos.ForEach(combo =>
            {
                combinations.Add(new List<Models.predicate>(combo));
                combo.Add(predicates[0]);
                combinations.Add(new List<Models.predicate>(combo));
            });
            return combinations;
        }

        private List<Models.attribute> getAttributesFromCompleteMinimalPredicates(List<Models.predicate> pr_prime)
        {
            List<Models.attribute> attributeNames = new List<Models.attribute>();
            foreach (Models.predicate predicate in pr_prime)
            {
                attributeNames.Add(new Models.attribute(predicate.attributeName, "", true));
            }
            return attributeNames;
        }

        private List<Models.attribute> eleminateDuplicatedAttributeNames(List<Models.attribute> relation)
        {
            List<Models.attribute> attributes = new List<Models.attribute>();
            foreach (Models.attribute attribute in relation)
            {
                if (!attributes.Contains(attribute))
                    attributes.Add(attribute);
            }
            return attributes;
        }

        private List<Models.predicate> convertPredicateGroupsToPredicateList(List<Models.predicateGroup> completePredicateGroups)
        {
            List<Models.predicate> listOfAllPredicates = new List<Models.predicate>();
            foreach (Models.predicateGroup predicateGroup in completePredicateGroups)
            {
                foreach (Models.predicate predicate in predicateGroup.predicates)
                {
                    listOfAllPredicates.Add(predicate);
                }
            }
            return listOfAllPredicates;
        }

        private List<Models.predicateGroup> getCompletePredicateGroup(List<Models.predicateGroup> predicateGroups)
        {
            foreach(Models.predicateGroup predicateGroup in predicateGroups)
            {
                if (predicateGroup.predicates.Count == 1)
                {
                    //complement comparison operator
                    Models.predicate predicate = predicateGroup.predicates.First();
                    string complementOperator = getNegativeOperator(predicate.comparisonOperator);
                    Models.predicate complementPredicate = new Models.predicate(predicate.attributeName, complementOperator, predicate.value);
                    predicateGroup.predicates.Add(complementPredicate);
                }
            }
            predicateGroups.RemoveAll(group => group.predicates.Count == 0);
            return predicateGroups;
        }

        private string getNegativeOperator(string comparisonOperator)
        {
            switch (comparisonOperator)
            {
                case "=": 
                    return "!=";
                case "!=":
                    return "=";
                case ">":
                    return "<=";
                case ">=":
                    return "<";
                case "<":
                    return ">=";
                case "<=":
                    return ">";
                default:
                    return comparisonOperator;
            }
        }

        private List<Models.predicateGroup> groupPredicatesByRelevantAttributes(List<Models.attribute> relation, List<Models.predicate> pr)
        {
            List<Models.attribute> relevantAttributes = getRelevantAttributes(relation);
            List<Models.predicateGroup> predicateGroups = new List<Models.predicateGroup>();
            foreach (Models.attribute relevantAttribute in relevantAttributes)
            {
                predicateGroups.Add(new Models.predicateGroup(relevantAttribute.name));
            }
            foreach (Models.predicate predicate in pr)
            {
                if (isRelevant(predicate.attributeName, relation))
                    predicateGroups.Find(group => group.groupName.Equals(predicate.attributeName)).addPredicate(predicate);
            }

            return predicateGroups;
        }

        private List<Models.attribute> getRelevantAttributes(List<Models.attribute> relation)
        {
            List<Models.attribute> relevantAttributes = new List<Models.attribute>();
            foreach (Models.attribute attribute in relation)
            {
                if (attribute.isRelevant == true)
                    relevantAttributes.Add(attribute);
            }
            return relevantAttributes;
        }

        /*
         * check if attributeName is a relevant attribute
         */
        private bool isRelevant(string attributeName, List<Models.attribute> relation)
        {
            bool isRelevant = false;
            List<Models.attribute> relevantAttributes = getRelevantAttributes(relation);
            foreach (Models.attribute relevantAttribute in relevantAttributes)
            {
                if (attributeName == relevantAttribute.name)
                    return true;
            }
            return isRelevant;
        }
    }
}
