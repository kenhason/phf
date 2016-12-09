namespace PrimaryHorizontalFragmentation
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Import = new System.Windows.Forms.Button();
            this.dataGridView_ExecutionStages = new System.Windows.Forms.DataGridView();
            this.comboBox_SelectTables = new System.Windows.Forms.ComboBox();
            this.button_Run = new System.Windows.Forms.Button();
            this.groupBox_AttributeInput = new System.Windows.Forms.GroupBox();
            this.button_FinishAttributesInput = new System.Windows.Forms.Button();
            this.textBox_AttributeList = new System.Windows.Forms.TextBox();
            this.comboBox_IsRelevant = new System.Windows.Forms.ComboBox();
            this.comboBox_DataType = new System.Windows.Forms.ComboBox();
            this.button_AddAttribute = new System.Windows.Forms.Button();
            this.textBox_AttributeName = new System.Windows.Forms.TextBox();
            this.label_IsRelevant = new System.Windows.Forms.Label();
            this.label_DataType = new System.Windows.Forms.Label();
            this.label_AttributeName = new System.Windows.Forms.Label();
            this.groupBox_SimplePredicates = new System.Windows.Forms.GroupBox();
            this.button_FinishSimplePredicateInput = new System.Windows.Forms.Button();
            this.textBox_SimplePredicates = new System.Windows.Forms.TextBox();
            this.comboBox_Attributes = new System.Windows.Forms.ComboBox();
            this.comboBox_Operators = new System.Windows.Forms.ComboBox();
            this.button_AddSimplePredicate = new System.Windows.Forms.Button();
            this.textBox_Value = new System.Windows.Forms.TextBox();
            this.label_Value = new System.Windows.Forms.Label();
            this.label_Operator = new System.Windows.Forms.Label();
            this.label_Attribute = new System.Windows.Forms.Label();
            this.textBox_AlgorithmResults = new System.Windows.Forms.TextBox();
            this.textBox_ServerName = new System.Windows.Forms.TextBox();
            this.label_ServerName = new System.Windows.Forms.Label();
            this.button_Connect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ExecutionStages)).BeginInit();
            this.groupBox_AttributeInput.SuspendLayout();
            this.groupBox_SimplePredicates.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Import
            // 
            this.button_Import.Location = new System.Drawing.Point(598, 265);
            this.button_Import.Name = "button_Import";
            this.button_Import.Size = new System.Drawing.Size(75, 23);
            this.button_Import.TabIndex = 13;
            this.button_Import.Text = "IMPORT";
            this.button_Import.UseVisualStyleBackColor = true;
            this.button_Import.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // dataGridView_ExecutionStages
            // 
            this.dataGridView_ExecutionStages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ExecutionStages.Location = new System.Drawing.Point(428, 293);
            this.dataGridView_ExecutionStages.Name = "dataGridView_ExecutionStages";
            this.dataGridView_ExecutionStages.Size = new System.Drawing.Size(564, 221);
            this.dataGridView_ExecutionStages.TabIndex = 1;
            // 
            // comboBox_SelectTables
            // 
            this.comboBox_SelectTables.FormattingEnabled = true;
            this.comboBox_SelectTables.Location = new System.Drawing.Point(769, 267);
            this.comboBox_SelectTables.Name = "comboBox_SelectTables";
            this.comboBox_SelectTables.Size = new System.Drawing.Size(223, 21);
            this.comboBox_SelectTables.TabIndex = 15;
            this.comboBox_SelectTables.SelectedIndexChanged += new System.EventHandler(this.cbSelectTables_SelectedIndexChanged);
            // 
            // button_Run
            // 
            this.button_Run.Location = new System.Drawing.Point(688, 265);
            this.button_Run.Name = "button_Run";
            this.button_Run.Size = new System.Drawing.Size(75, 23);
            this.button_Run.TabIndex = 14;
            this.button_Run.Text = "RUN";
            this.button_Run.UseVisualStyleBackColor = true;
            this.button_Run.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // groupBox_AttributeInput
            // 
            this.groupBox_AttributeInput.Controls.Add(this.button_FinishAttributesInput);
            this.groupBox_AttributeInput.Controls.Add(this.textBox_AttributeList);
            this.groupBox_AttributeInput.Controls.Add(this.comboBox_IsRelevant);
            this.groupBox_AttributeInput.Controls.Add(this.comboBox_DataType);
            this.groupBox_AttributeInput.Controls.Add(this.button_AddAttribute);
            this.groupBox_AttributeInput.Controls.Add(this.textBox_AttributeName);
            this.groupBox_AttributeInput.Controls.Add(this.label_IsRelevant);
            this.groupBox_AttributeInput.Controls.Add(this.label_DataType);
            this.groupBox_AttributeInput.Controls.Add(this.label_AttributeName);
            this.groupBox_AttributeInput.Location = new System.Drawing.Point(25, 25);
            this.groupBox_AttributeInput.Name = "groupBox_AttributeInput";
            this.groupBox_AttributeInput.Size = new System.Drawing.Size(474, 233);
            this.groupBox_AttributeInput.TabIndex = 4;
            this.groupBox_AttributeInput.TabStop = false;
            this.groupBox_AttributeInput.Text = "ATTRIBUTE";
            // 
            // button_FinishAttributesInput
            // 
            this.button_FinishAttributesInput.FlatAppearance.BorderSize = 0;
            this.button_FinishAttributesInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_FinishAttributesInput.Location = new System.Drawing.Point(403, 160);
            this.button_FinishAttributesInput.Margin = new System.Windows.Forms.Padding(1);
            this.button_FinishAttributesInput.Name = "button_FinishAttributesInput";
            this.button_FinishAttributesInput.Size = new System.Drawing.Size(55, 49);
            this.button_FinishAttributesInput.TabIndex = 5;
            this.button_FinishAttributesInput.Text = "DONE";
            this.button_FinishAttributesInput.UseVisualStyleBackColor = true;
            this.button_FinishAttributesInput.Click += new System.EventHandler(this.button_FinishAttributesInput_Click);
            // 
            // textBox_AttributeList
            // 
            this.textBox_AttributeList.Location = new System.Drawing.Point(15, 85);
            this.textBox_AttributeList.Multiline = true;
            this.textBox_AttributeList.Name = "textBox_AttributeList";
            this.textBox_AttributeList.Size = new System.Drawing.Size(358, 124);
            this.textBox_AttributeList.TabIndex = 9;
            // 
            // comboBox_IsRelevant
            // 
            this.comboBox_IsRelevant.FormattingEnabled = true;
            this.comboBox_IsRelevant.Items.AddRange(new object[] {
            "true",
            "false"});
            this.comboBox_IsRelevant.Location = new System.Drawing.Point(283, 49);
            this.comboBox_IsRelevant.Name = "comboBox_IsRelevant";
            this.comboBox_IsRelevant.Size = new System.Drawing.Size(90, 21);
            this.comboBox_IsRelevant.TabIndex = 3;
            // 
            // comboBox_DataType
            // 
            this.comboBox_DataType.FormattingEnabled = true;
            this.comboBox_DataType.Items.AddRange(new object[] {
            "string",
            "int",
            "datetime",
            "(other)"});
            this.comboBox_DataType.Location = new System.Drawing.Point(164, 50);
            this.comboBox_DataType.Name = "comboBox_DataType";
            this.comboBox_DataType.Size = new System.Drawing.Size(107, 21);
            this.comboBox_DataType.TabIndex = 1;
            // 
            // button_AddAttribute
            // 
            this.button_AddAttribute.FlatAppearance.BorderSize = 0;
            this.button_AddAttribute.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.button_AddAttribute.Location = new System.Drawing.Point(403, 85);
            this.button_AddAttribute.Margin = new System.Windows.Forms.Padding(1);
            this.button_AddAttribute.Name = "button_AddAttribute";
            this.button_AddAttribute.Size = new System.Drawing.Size(55, 50);
            this.button_AddAttribute.TabIndex = 4;
            this.button_AddAttribute.Text = "+";
            this.button_AddAttribute.UseVisualStyleBackColor = true;
            this.button_AddAttribute.Click += new System.EventHandler(this.button_AddAttribute_Click);
            // 
            // textBox_AttributeName
            // 
            this.textBox_AttributeName.Location = new System.Drawing.Point(15, 50);
            this.textBox_AttributeName.Name = "textBox_AttributeName";
            this.textBox_AttributeName.Size = new System.Drawing.Size(138, 20);
            this.textBox_AttributeName.TabIndex = 0;
            // 
            // label_IsRelevant
            // 
            this.label_IsRelevant.AutoSize = true;
            this.label_IsRelevant.Location = new System.Drawing.Point(280, 29);
            this.label_IsRelevant.Name = "label_IsRelevant";
            this.label_IsRelevant.Size = new System.Drawing.Size(83, 13);
            this.label_IsRelevant.TabIndex = 3;
            this.label_IsRelevant.Text = "IS RELEVANT?";
            // 
            // label_DataType
            // 
            this.label_DataType.AutoSize = true;
            this.label_DataType.Location = new System.Drawing.Point(164, 30);
            this.label_DataType.Name = "label_DataType";
            this.label_DataType.Size = new System.Drawing.Size(67, 13);
            this.label_DataType.TabIndex = 2;
            this.label_DataType.Text = "DATA TYPE";
            // 
            // label_AttributeName
            // 
            this.label_AttributeName.AutoSize = true;
            this.label_AttributeName.Location = new System.Drawing.Point(16, 30);
            this.label_AttributeName.Name = "label_AttributeName";
            this.label_AttributeName.Size = new System.Drawing.Size(38, 13);
            this.label_AttributeName.TabIndex = 1;
            this.label_AttributeName.Text = "NAME";
            // 
            // groupBox_SimplePredicates
            // 
            this.groupBox_SimplePredicates.Controls.Add(this.button_FinishSimplePredicateInput);
            this.groupBox_SimplePredicates.Controls.Add(this.textBox_SimplePredicates);
            this.groupBox_SimplePredicates.Controls.Add(this.comboBox_Attributes);
            this.groupBox_SimplePredicates.Controls.Add(this.comboBox_Operators);
            this.groupBox_SimplePredicates.Controls.Add(this.button_AddSimplePredicate);
            this.groupBox_SimplePredicates.Controls.Add(this.textBox_Value);
            this.groupBox_SimplePredicates.Controls.Add(this.label_Value);
            this.groupBox_SimplePredicates.Controls.Add(this.label_Operator);
            this.groupBox_SimplePredicates.Controls.Add(this.label_Attribute);
            this.groupBox_SimplePredicates.Location = new System.Drawing.Point(518, 25);
            this.groupBox_SimplePredicates.Name = "groupBox_SimplePredicates";
            this.groupBox_SimplePredicates.Size = new System.Drawing.Size(474, 233);
            this.groupBox_SimplePredicates.TabIndex = 11;
            this.groupBox_SimplePredicates.TabStop = false;
            this.groupBox_SimplePredicates.Text = "SIMPLE PREDICATES";
            // 
            // button_FinishSimplePredicateInput
            // 
            this.button_FinishSimplePredicateInput.FlatAppearance.BorderSize = 0;
            this.button_FinishSimplePredicateInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_FinishSimplePredicateInput.Location = new System.Drawing.Point(403, 160);
            this.button_FinishSimplePredicateInput.Margin = new System.Windows.Forms.Padding(0);
            this.button_FinishSimplePredicateInput.Name = "button_FinishSimplePredicateInput";
            this.button_FinishSimplePredicateInput.Size = new System.Drawing.Size(55, 49);
            this.button_FinishSimplePredicateInput.TabIndex = 10;
            this.button_FinishSimplePredicateInput.Text = "DONE";
            this.button_FinishSimplePredicateInput.UseVisualStyleBackColor = true;
            this.button_FinishSimplePredicateInput.Click += new System.EventHandler(this.button_FinishSimplePredicateInput_Click);
            // 
            // textBox_SimplePredicates
            // 
            this.textBox_SimplePredicates.Location = new System.Drawing.Point(15, 85);
            this.textBox_SimplePredicates.Multiline = true;
            this.textBox_SimplePredicates.Name = "textBox_SimplePredicates";
            this.textBox_SimplePredicates.Size = new System.Drawing.Size(358, 124);
            this.textBox_SimplePredicates.TabIndex = 100;
            // 
            // comboBox_Attributes
            // 
            this.comboBox_Attributes.FormattingEnabled = true;
            this.comboBox_Attributes.Location = new System.Drawing.Point(19, 50);
            this.comboBox_Attributes.Name = "comboBox_Attributes";
            this.comboBox_Attributes.Size = new System.Drawing.Size(134, 21);
            this.comboBox_Attributes.TabIndex = 6;
            // 
            // comboBox_Operators
            // 
            this.comboBox_Operators.FormattingEnabled = true;
            this.comboBox_Operators.Items.AddRange(new object[] {
            "=",
            "!=",
            ">",
            ">=",
            "<",
            "<="});
            this.comboBox_Operators.Location = new System.Drawing.Point(164, 50);
            this.comboBox_Operators.Name = "comboBox_Operators";
            this.comboBox_Operators.Size = new System.Drawing.Size(107, 21);
            this.comboBox_Operators.TabIndex = 7;
            // 
            // button_AddSimplePredicate
            // 
            this.button_AddSimplePredicate.FlatAppearance.BorderSize = 0;
            this.button_AddSimplePredicate.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.button_AddSimplePredicate.Location = new System.Drawing.Point(403, 85);
            this.button_AddSimplePredicate.Margin = new System.Windows.Forms.Padding(1);
            this.button_AddSimplePredicate.Name = "button_AddSimplePredicate";
            this.button_AddSimplePredicate.Size = new System.Drawing.Size(55, 50);
            this.button_AddSimplePredicate.TabIndex = 9;
            this.button_AddSimplePredicate.Text = "+";
            this.button_AddSimplePredicate.UseVisualStyleBackColor = true;
            this.button_AddSimplePredicate.Click += new System.EventHandler(this.button_AddSimplePredicate_Click);
            // 
            // textBox_Value
            // 
            this.textBox_Value.Location = new System.Drawing.Point(283, 50);
            this.textBox_Value.Name = "textBox_Value";
            this.textBox_Value.Size = new System.Drawing.Size(90, 20);
            this.textBox_Value.TabIndex = 8;
            // 
            // label_Value
            // 
            this.label_Value.AutoSize = true;
            this.label_Value.Location = new System.Drawing.Point(280, 29);
            this.label_Value.Name = "label_Value";
            this.label_Value.Size = new System.Drawing.Size(42, 13);
            this.label_Value.TabIndex = 3;
            this.label_Value.Text = "VALUE";
            // 
            // label_Operator
            // 
            this.label_Operator.AutoSize = true;
            this.label_Operator.Location = new System.Drawing.Point(164, 30);
            this.label_Operator.Name = "label_Operator";
            this.label_Operator.Size = new System.Drawing.Size(67, 13);
            this.label_Operator.TabIndex = 2;
            this.label_Operator.Text = "OPERATOR";
            // 
            // label_Attribute
            // 
            this.label_Attribute.AutoSize = true;
            this.label_Attribute.Location = new System.Drawing.Point(16, 30);
            this.label_Attribute.Name = "label_Attribute";
            this.label_Attribute.Size = new System.Drawing.Size(68, 13);
            this.label_Attribute.TabIndex = 1;
            this.label_Attribute.Text = "ATTRIBUTE";
            // 
            // textBox_AlgorithmResults
            // 
            this.textBox_AlgorithmResults.Location = new System.Drawing.Point(25, 293);
            this.textBox_AlgorithmResults.Multiline = true;
            this.textBox_AlgorithmResults.Name = "textBox_AlgorithmResults";
            this.textBox_AlgorithmResults.Size = new System.Drawing.Size(397, 221);
            this.textBox_AlgorithmResults.TabIndex = 12;
            // 
            // textBox_ServerName
            // 
            this.textBox_ServerName.Location = new System.Drawing.Point(121, 266);
            this.textBox_ServerName.Name = "textBox_ServerName";
            this.textBox_ServerName.Size = new System.Drawing.Size(177, 20);
            this.textBox_ServerName.TabIndex = 11;
            // 
            // label_ServerName
            // 
            this.label_ServerName.AutoSize = true;
            this.label_ServerName.Location = new System.Drawing.Point(30, 270);
            this.label_ServerName.Name = "label_ServerName";
            this.label_ServerName.Size = new System.Drawing.Size(85, 13);
            this.label_ServerName.TabIndex = 14;
            this.label_ServerName.Text = "SERVER NAME";
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(303, 264);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(119, 23);
            this.button_Connect.TabIndex = 12;
            this.button_Connect.Text = "CONNECT";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 526);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.label_ServerName);
            this.Controls.Add(this.textBox_ServerName);
            this.Controls.Add(this.textBox_AlgorithmResults);
            this.Controls.Add(this.groupBox_SimplePredicates);
            this.Controls.Add(this.groupBox_AttributeInput);
            this.Controls.Add(this.button_Run);
            this.Controls.Add(this.comboBox_SelectTables);
            this.Controls.Add(this.dataGridView_ExecutionStages);
            this.Controls.Add(this.button_Import);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "PRIMARY HORIZONTAL FRAGMENTATION SOFTWARE";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ExecutionStages)).EndInit();
            this.groupBox_AttributeInput.ResumeLayout(false);
            this.groupBox_AttributeInput.PerformLayout();
            this.groupBox_SimplePredicates.ResumeLayout(false);
            this.groupBox_SimplePredicates.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Import;
        private System.Windows.Forms.DataGridView dataGridView_ExecutionStages;
        private System.Windows.Forms.ComboBox comboBox_SelectTables;
        private System.Windows.Forms.Button button_Run;
        private System.Windows.Forms.GroupBox groupBox_AttributeInput;
        private System.Windows.Forms.ComboBox comboBox_IsRelevant;
        private System.Windows.Forms.ComboBox comboBox_DataType;
        private System.Windows.Forms.Button button_AddAttribute;
        private System.Windows.Forms.TextBox textBox_AttributeName;
        private System.Windows.Forms.Label label_IsRelevant;
        private System.Windows.Forms.Label label_DataType;
        private System.Windows.Forms.Label label_AttributeName;
        private System.Windows.Forms.Button button_FinishAttributesInput;
        private System.Windows.Forms.TextBox textBox_AttributeList;
        private System.Windows.Forms.GroupBox groupBox_SimplePredicates;
        private System.Windows.Forms.Button button_FinishSimplePredicateInput;
        private System.Windows.Forms.TextBox textBox_SimplePredicates;
        private System.Windows.Forms.ComboBox comboBox_Attributes;
        private System.Windows.Forms.ComboBox comboBox_Operators;
        private System.Windows.Forms.Button button_AddSimplePredicate;
        private System.Windows.Forms.TextBox textBox_Value;
        private System.Windows.Forms.Label label_Value;
        private System.Windows.Forms.Label label_Operator;
        private System.Windows.Forms.Label label_Attribute;
        private System.Windows.Forms.TextBox textBox_AlgorithmResults;
        private System.Windows.Forms.TextBox textBox_ServerName;
        private System.Windows.Forms.Label label_ServerName;
        private System.Windows.Forms.Button button_Connect;
    }
}