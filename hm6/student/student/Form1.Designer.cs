namespace student
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            studentDataGridView = new DataGridView();
            schoolComboBox = new ComboBox();
            classComboBox = new ComboBox();
            lable1 = new Label();
            label2 = new Label();
            addButton = new Button();
            deleteButton = new Button();
            logDataGridView = new DataGridView();
            logButton = new Button();
            studentNameTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)studentDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logDataGridView).BeginInit();
            SuspendLayout();
            // 
            // studentDataGridView
            // 
            studentDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            studentDataGridView.Location = new Point(127, 92);
            studentDataGridView.Name = "studentDataGridView";
            studentDataGridView.RowTemplate.Height = 25;
            studentDataGridView.Size = new Size(857, 228);
            studentDataGridView.TabIndex = 0;
            // 
            // schoolComboBox
            // 
            schoolComboBox.FormattingEnabled = true;
            schoolComboBox.Location = new Point(187, 33);
            schoolComboBox.Name = "schoolComboBox";
            schoolComboBox.Size = new Size(171, 25);
            schoolComboBox.TabIndex = 1;
            // 
            // classComboBox
            // 
            classComboBox.FormattingEnabled = true;
            classComboBox.Location = new Point(675, 36);
            classComboBox.Name = "classComboBox";
            classComboBox.Size = new Size(188, 25);
            classComboBox.TabIndex = 2;
            // 
            // lable1
            // 
            lable1.AutoSize = true;
            lable1.Location = new Point(127, 35);
            lable1.Name = "lable1";
            lable1.Size = new Size(32, 17);
            lable1.TabIndex = 3;
            lable1.Text = "学校";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(622, 39);
            label2.Name = "label2";
            label2.Size = new Size(32, 17);
            label2.TabIndex = 4;
            label2.Text = "班级";
            // 
            // addButton
            // 
            addButton.Location = new Point(448, 347);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 23);
            addButton.TabIndex = 5;
            addButton.Text = "添加学生";
            addButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(750, 337);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(75, 23);
            deleteButton.TabIndex = 6;
            deleteButton.Text = "删除学生";
            deleteButton.UseVisualStyleBackColor = true;
            // 
            // logDataGridView
            // 
            logDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            logDataGridView.Location = new Point(414, 418);
            logDataGridView.Name = "logDataGridView";
            logDataGridView.RowTemplate.Height = 25;
            logDataGridView.Size = new Size(240, 150);
            logDataGridView.TabIndex = 7;
            // 
            // logButton
            // 
            logButton.Location = new Point(741, 486);
            logButton.Name = "logButton";
            logButton.Size = new Size(75, 23);
            logButton.TabIndex = 8;
            logButton.Text = "查询log表";
            logButton.UseVisualStyleBackColor = true;
            logButton.Click += logButton_Click;
            // 
            // studentNameTextBox
            // 
            studentNameTextBox.Location = new Point(187, 337);
            studentNameTextBox.Name = "studentNameTextBox";
            studentNameTextBox.Size = new Size(100, 23);
            studentNameTextBox.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1059, 606);
            Controls.Add(studentNameTextBox);
            Controls.Add(logButton);
            Controls.Add(logDataGridView);
            Controls.Add(deleteButton);
            Controls.Add(addButton);
            Controls.Add(label2);
            Controls.Add(lable1);
            Controls.Add(classComboBox);
            Controls.Add(schoolComboBox);
            Controls.Add(studentDataGridView);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            ((System.ComponentModel.ISupportInitialize)studentDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)logDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView studentDataGridView;
        private ComboBox schoolComboBox;
        private ComboBox classComboBox;
        private Label lable1;
        private Label label2;
        private Button addButton;
        private Button deleteButton;
        private DataGridView logDataGridView;
        private Button logButton;
        private TextBox studentNameTextBox;
    }
}