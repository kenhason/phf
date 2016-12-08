using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

namespace PrimaryHorizontalFragmentation
{
    public partial class MainForm : Form
    {
        Services services;
        DataSet ds;
        string connectionString = @"Data Source=KEN-PC\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
        string tableName = "PHF_Demo";
        string filePath = "";
        List<String> minterms;
        List<Models.attribute> relation;
        List<Models.predicate> pr;
        List<Models.predicate> pr_prime;

        public MainForm()
        {
            InitializeComponent();
            services = new Services();
            ds = new DataSet();
            minterms = new List<string>();
            relation = new List<Models.attribute>();
            pr = new List<Models.predicate>();
            pr_prime = new List<Models.predicate>();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            groupBox_SimplePredicates.Enabled = false;
            textBox_AlgorithmResults.Visible = false;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            textBox_AlgorithmResults.Visible = false;
            ds.Clear();
            var filePicker = new System.Windows.Forms.OpenFileDialog();
            if (filePicker.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = getFilePath(filePicker);
                services.generateDatabaseTable(filePath, connectionString, tableName);
                ds = services.loadTableFromDatabase(ds, connectionString, tableName);
                displayData(ds);
            }
        }

        private string getFilePath(OpenFileDialog filePicker)
        {
            string filePath = filePicker.FileName;
            filePath = filePath.Replace(@"\", @"\\");
            return filePath;
        }

        private void setDefaultComboBoxItem()
        {
            comboBox_SelectTables.Text = comboBox_SelectTables.Items[0].ToString();
        }

        private void displayData(DataSet ds)
        {
            showTableContentInDataGridView(ds);
            loadTableNamesToComboBox(ds);
        }

        private void loadTableNamesToComboBox(DataSet ds)
        {
            foreach (DataTable table in ds.Tables)
            {
                comboBox_SelectTables.Items.Add(table.TableName);
            }
            setDefaultComboBoxItem();
        }

        private void showTableContentInDataGridView(DataSet ds)
        {
            dataGridView_ExecutionStages.DataSource = ds.Tables[0].DefaultView;
        }

        private void cbSelectTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView_ExecutionStages.DataSource = ds.Tables[comboBox_SelectTables.SelectedItem.ToString()].DefaultView;
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            ds = services.generateFragments(connectionString, tableName, ds, minterms);
            loadFragmentNamesToComboBox();
        }

        private void loadFragmentNamesToComboBox()
        {
            comboBox_SelectTables.Items.Clear();
            foreach (DataTable table in ds.Tables)
            {
                comboBox_SelectTables.Items.Add(table.TableName);
            }
        }

        private void button_AddAttribute_Click(object sender, EventArgs e)
        {
            if ((textBox_AttributeName.Text != "") || (textBox_AttributeName != null) &&
                comboBox_DataType.SelectedItem != null && comboBox_IsRelevant.SelectedItem != null)
            {
                bool isRelevant = false;
                if (comboBox_IsRelevant.SelectedItem.ToString() == "true")
                    isRelevant = true;
                else
                    isRelevant = false;
                Models.attribute attribute = new Models.attribute(
                    textBox_AttributeName.Text,
                    comboBox_DataType.SelectedItem.ToString(),
                    isRelevant);
                relation.Add(attribute);
                textBox_AttributeList.AppendText(attribute.ToString());
                textBox_AttributeList.AppendText(Environment.NewLine);
            }
            else
                MessageBox.Show("Invalid Input");
        }

        private void button_FinishAttributesInput_Click(object sender, EventArgs e)
        {
            groupBox_SimplePredicates.Enabled = true;
            loadAttributeNameToComboBox();
        }

        private void loadAttributeNameToComboBox()
        {
            foreach (Models.attribute attribute in relation)
                comboBox_Attributes.Items.Add(attribute.name);
        }

        private void button_AddSimplePredicate_Click(object sender, EventArgs e)
        {
            if (comboBox_Attributes.SelectedItem != null && comboBox_Operators.SelectedItem != null &&
                (textBox_Value.Text != "" || textBox_Value != null))
            {
                Models.predicate predicate = new Models.predicate(
                    comboBox_Attributes.SelectedItem.ToString(),
                    comboBox_Operators.SelectedItem.ToString(),
                    textBox_Value.Text);
                pr.Add(predicate);
                textBox_SimplePredicates.AppendText(predicate.ToString());
                textBox_SimplePredicates.AppendText(Environment.NewLine);
            }
            else
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void button_FinishSimplePredicateInput_Click(object sender, EventArgs e)
        {
            pr_prime = services.getCompleteMininalPredicates(relation, pr);
            minterms = services.getMintermPredicates(pr_prime);
            textBox_AlgorithmResults.Visible = true;
            textBox_AlgorithmResults.Text += "Pr' after applying COM_MIN algorithm:\n";
            foreach (Models.predicate predicate in pr_prime)
            {
                textBox_AlgorithmResults.AppendText(predicate.ToString());
                textBox_AlgorithmResults.AppendText(Environment.NewLine);
            }
            textBox_AlgorithmResults.AppendText("Minterm predicates:");
            textBox_AlgorithmResults.AppendText(Environment.NewLine);
            foreach (string minterm in minterms)
            {
                textBox_AlgorithmResults.AppendText(minterm);
                textBox_AlgorithmResults.AppendText(Environment.NewLine);
            }
        }
    }
}
