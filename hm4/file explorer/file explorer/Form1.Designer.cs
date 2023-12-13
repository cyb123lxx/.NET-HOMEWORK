namespace file_explorer
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
            treeView = new TreeView();
            listView = new ListView();
            name = new ColumnHeader();
            type = new ColumnHeader();
            time = new ColumnHeader();
            SuspendLayout();
            // 
            // treeView
            // 
            treeView.Location = new Point(0, 0);
            treeView.Name = "treeView";
            treeView.Size = new Size(229, 450);
            treeView.TabIndex = 0;
            treeView.BeforeExpand += treeView_BeforeExpand;
            treeView.NodeMouseDoubleClick += treeView_NodeMouseDoubleClick;
            // 
            // listView
            // 
            listView.Columns.AddRange(new ColumnHeader[] { name, type, time });
            listView.Location = new Point(235, 0);
            listView.Name = "listView";
            listView.Size = new Size(563, 450);
            listView.TabIndex = 1;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            listView.MouseDoubleClick += listView_MouseDoubleClick;
            // 
            // name
            // 
            name.Text = "文件名";
            name.Width = 200;
            // 
            // type
            // 
            type.Text = "类型";
            // 
            // time
            // 
            time.Text = "上次修改时间";
            time.Width = 200;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listView);
            Controls.Add(treeView);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeView;
        private ListView listView;
        private ColumnHeader name;
        private ColumnHeader type;
        private ColumnHeader time;
    }
}