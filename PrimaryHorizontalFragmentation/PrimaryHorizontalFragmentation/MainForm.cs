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
        string connectionString = "";
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
            setVisibilityForControls();
            setFocusForControl();
            setAutoCompleteForComboBoxes();
        }

        private void setFocusForControl()
        {
            textBox_AttributeName.Select();
        }

        private void setVisibilityForControls()
        {
            groupBox_SimplePredicates.Enabled = false;
            button_Import.Enabled = false;
            button_Run.Enabled = false;
        }

        private void setAutoCompleteForComboBoxes()
        {
            comboBox_DataType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_DataType.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_Attributes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_Attributes.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_IsRelevant.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_IsRelevant.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_Operators.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_Operators.AutoCompleteSource = AutoCompleteSource.ListItems;
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
                button_Run.Enabled = true;
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
            if (textBox_AttributeName.Text != "" &&
                comboBox_DataType.SelectedIndex > -1 &&
                comboBox_IsRelevant.SelectedIndex > -1)
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
                textBox_AttributeName.Focus();
                textBox_AttributeName.SelectAll();
            }
            else
                MessageBox.Show("Invalid Input");
        }

        private void button_FinishAttributesInput_Click(object sender, EventArgs e)
        {
            groupBox_SimplePredicates.Enabled = true;
            loadAttributeToComboBox();
            comboBox_Attributes.Focus();
        }

        private void loadAttributeToComboBox()
        {
            foreach (Models.attribute attribute in relation)
                comboBox_Attributes.Items.Add(attribute.name);
        }

        private void button_AddSimplePredicate_Click(object sender, EventArgs e)
        {
            if (comboBox_Attributes.SelectedIndex >-1 &&
                comboBox_Operators.SelectedIndex > -1 &&
                textBox_Value.Text != "")
            {
                int selectedIndex = comboBox_Attributes.SelectedIndex;
                Models.predicate predicate = new Models.predicate(
                    relation[selectedIndex],
                    comboBox_Operators.SelectedItem.ToString(),
                    textBox_Value.Text);
                pr.Add(predicate);
                textBox_SimplePredicates.AppendText(predicate.ToString());
                textBox_SimplePredicates.AppendText(Environment.NewLine);
                comboBox_Attributes.SelectAll();
            }
            else
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void button_FinishSimplePredicateInput_Click(object sender, EventArgs e)
        {
            textBox_AlgorithmResults.Clear();
            pr_prime = services.getCompleteMininalPredicates(relation, pr);
            minterms = services.getMintermPredicates(pr_prime);
            textBox_AlgorithmResults.Visible = true;
            textBox_AlgorithmResults.Text += "After applying COM_MIN algorithm, Pr' includes:\n";
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
            textBox_ServerName.Focus();
            textBox_ServerName.SelectAll();
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            if (textBox_ServerName.Text != "")
            {
                this.connectionString = @"Data Source=" + @textBox_ServerName.Text + @";Initial Catalog=master;Integrated Security=True";
                bool testResult = testConnection(this.connectionString);
                if (testResult == true)
                    button_Import.Enabled = true;
                else
                    MessageBox.Show("Cannot connect to SQL Server");
            }
            else
                MessageBox.Show("Please input SERVER NAME!");
        }

        private bool testConnection(string connString)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
