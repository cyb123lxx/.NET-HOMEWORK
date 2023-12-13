using System.Diagnostics;
using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;


namespace file_explorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadDrives();
        }
        private void LoadDrives()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                TreeNode driveNode = new TreeNode(drive.Name);
                driveNode.Tag = drive.RootDirectory;
                driveNode.Nodes.Add("*"); // 添加一个占位符节点，用于延迟加载子节点
                treeView.Nodes.Add(driveNode);
            }
        }
        private void treeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "*")
            {
                e.Node.Nodes.Clear();
                DirectoryInfo directory = (DirectoryInfo)e.Node.Tag;
                try
                {
                    foreach (DirectoryInfo subDir in directory.GetDirectories())
                    {
                        TreeNode subDirNode = new TreeNode(subDir.Name);
                        subDirNode.Tag = subDir;
                        subDirNode.Nodes.Add("*");
                        e.Node.Nodes.Add(subDirNode);
                    }
                    foreach (FileInfo file in directory.GetFiles())
                    {
                        TreeNode fileNode = new TreeNode(file.Name);
                        fileNode.Tag = file;
                        e.Node.Nodes.Add(fileNode);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("访问被拒绝");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag is DirectoryInfo)
            {
                DirectoryInfo directory = (DirectoryInfo)e.Node.Tag;
                listView.Items.Clear();
                try
                {
                    foreach (DirectoryInfo subDir in directory.GetDirectories())
                    {
                        ListViewItem item = new ListViewItem(subDir.Name);
                        item.SubItems.Add("文件夹");
                        item.SubItems.Add(subDir.LastWriteTime.ToString());
                        listView.Items.Add(item);
                    }
                    foreach (FileInfo file in directory.GetFiles())
                    {
                        ListViewItem item = new ListViewItem(file.Name);
                        item.SubItems.Add("文件");
                        item.SubItems.Add(file.LastWriteTime.ToString());
                        listView.Items.Add(item);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("访问被拒绝");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                if (selectedItem.SubItems[1].Text == "文件")
                {
                    FileInfo file = (FileInfo)selectedItem.Tag;
                    if (file.Extension.Equals(".exe", StringComparison.OrdinalIgnoreCase))
                    {
                        Process.Start(file.FullName);
                    }
                    else if (file.Extension.Equals(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        Process.Start("notepad.exe", file.FullName);
                    }
                }
            }
        }
    }
}