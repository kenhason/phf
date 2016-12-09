using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimaryHorizontalFragmentation
{
    public class Models
    {
        public struct attribute
        {
            public string name;
            public string datatype;
            public bool isRelevant;
            //public attribute()
            //{
            //    name = "";
            //    datatype = "";
            //    isRelevant = false;
            //}
            public attribute(string _name, string _datatype, bool _isRelevant)
            {
                name = _name;
                datatype = _datatype;
                isRelevant = _isRelevant;
            }
            public override string ToString()
            {
                return name + ": " + datatype + ", " + isRelevant.ToString();
            }
        }

        public struct predicate
        {
            public attribute attribute;
            public string comparisonOperator;
            public string value;

            public predicate(attribute _attribute, string _comparisonOperator, string _value)
            {
                attribute = _attribute;
                comparisonOperator = _comparisonOperator;
                value = _value;
            }

            public override string ToString()
            {
                string _value = "";
                if (this.attribute.datatype == "string")
                    _value = "'" + this.value + "'";
                else
                    _value = this.value;
                return this.attribute.name + ' ' + this.comparisonOperator + ' ' + _value;
            }

            public override bool Equals(Object obj)
            {
                predicate other = (predicate)obj;
                return 
                    (this.attribute.Equals(other.attribute)) &&
                    (this.comparisonOperator == other.comparisonOperator) &&
                    (this.value == other.value);
            }
        }

        public struct minterm
        {
            public List<predicate> simplePredicates;

            public void addPredicate(predicate predicate)
            {
                simplePredicates.Add(predicate);
            }

            public override string ToString()
            {
                string mintermString = "";
                foreach(predicate simplePredicate in this.simplePredicates)
                {
                    if (simplePredicate.Equals(this.simplePredicates.First()))
                        mintermString += simplePredicate.ToString() + " AND ";
                    else
                        mintermString += simplePredicate.ToString();
                }
                return mintermString;
            }
        }

        public struct predicateGroup
        {
            public List<predicate> predicates;
            public string groupName;

            //public predicateGroup()
            //{
            //    predicates = new List<predicate>();
            //    groupName = "";
            //}

            public predicateGroup(string _groupName)
            {
                predicates = new List<predicate>();
                groupName = _groupName;
            }

            public void addPredicate(predicate predicate)
            {
                predicates.Add(predicate);
            }
        }
    }
}
