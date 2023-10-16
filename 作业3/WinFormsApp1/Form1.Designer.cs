namespace SimpleFileBrowser
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeView = new System.Windows.Forms.TreeView();
            this.listView = new System.Windows.Forms.ListView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();

            // 设置treeView
            this.treeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);

            // 设置listView
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);

            // 设置MenuStrip
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            this.menuStrip.Items.Add(this.openFileToolStripMenuItem);
            this.MainMenuStrip = this.menuStrip;

            // 设置ToolStrip
            this.toolStrip.Items.Add("Open File");
            this.toolStrip.Items[0].Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);

            // Form1
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.toolStrip);
        }
    }
}
