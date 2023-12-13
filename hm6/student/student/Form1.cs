using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
namespace student
{
    public partial class Form1 : Form
    {
        private SQLiteConnection connection;
        private SQLiteDataAdapter dataAdapter;
        private DataSet dataSet;
        public Form1()
        {
            InitializeComponent();
            MainForm_Load();
        }
        private void MainForm_Load()
        {
            // 创建数据库连接
            connection = new SQLiteConnection("Data Source=student.db");
            connection.Open();

            // 创建学校、班级、学生表
            string createSchoolTableQuery = "CREATE TABLE IF NOT EXISTS School (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT)";
            string createClassTableQuery = "CREATE TABLE IF NOT EXISTS Class (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, SchoolId INTEGER)";
            string createStudentTableQuery = "CREATE TABLE IF NOT EXISTS Student (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, ClassId INTEGER)";
            string createLogTableQuery = "CREATE TABLE IF NOT EXISTS log (Id INTEGER PRIMARY KEY AUTOINCREMENT, Operation TEXT)";

            ExecuteQuery(createSchoolTableQuery);
            ExecuteQuery(createClassTableQuery);
            ExecuteQuery(createStudentTableQuery);
            ExecuteQuery(createLogTableQuery);

            string sql = "insert into  School (Name) values(WuHan University);";
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            cmd.ExecuteNonQuery();

            sql = "insert into  Class (Name) values(ruangong1ban);";
            cmd = new SQLiteCommand(sql, connection);
            cmd.ExecuteNonQuery();

            // 加载学校列表
            LoadSchools();
        }

        private void LoadSchools()
        {
            string query = "SELECT * FROM School";
            dataAdapter = new SQLiteDataAdapter(query, connection);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "School");

            schoolComboBox.DisplayMember = "Name";
            schoolComboBox.ValueMember = "Id";
            schoolComboBox.DataSource = dataSet.Tables["School"];
        }

        private void schoolComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 加载班级列表
            int schoolId = Convert.ToInt32(schoolComboBox.SelectedValue);
            string query = $"SELECT * FROM Class WHERE SchoolId = {schoolId}";
            dataAdapter = new SQLiteDataAdapter(query, connection);
            dataSet.Tables["Class"].Clear();
            dataAdapter.Fill(dataSet, "Class");

            classComboBox.DisplayMember = "Name";
            classComboBox.ValueMember = "Id";
            classComboBox.DataSource = dataSet.Tables["Class"];
        }

        private void classComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 加载学生列表
            int classId = Convert.ToInt32(classComboBox.SelectedValue);
            string query = $"SELECT * FROM Student WHERE ClassId = {classId}";
            dataAdapter = new SQLiteDataAdapter(query, connection);
            dataSet.Tables["Student"].Clear();
            dataAdapter.Fill(dataSet, "Student");

            studentDataGridView.DataSource = dataSet.Tables["Student"];
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // 添加学生
            int classId = Convert.ToInt32(classComboBox.SelectedValue);
            string studentName = studentNameTextBox.Text;

            string query = $"INSERT INTO Student (Name, ClassId) VALUES ('{studentName}', {classId})";
            ExecuteQuery(query);

            // 刷新学生列表
            classComboBox_SelectedIndexChanged(null, null);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // 删除选中的学生
            if (studentDataGridView.SelectedRows.Count > 0)
            {
                int studentId = Convert.ToInt32(studentDataGridView.SelectedRows[0].Cells["Id"].Value);
                string query = $"DELETE FROM Student WHERE Id = {studentId}";
                ExecuteQuery(query);

                // 刷新学生列表
                classComboBox_SelectedIndexChanged(null, null);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 关闭数据库连接
            connection.Close();
        }
        private void logButton_Click(object sender, EventArgs e)
        {
            // 查询log表并显示
            string query = "SELECT * FROM log";
            dataAdapter = new SQLiteDataAdapter(query, connection);
            dataSet.Tables["log"].Clear();
            dataAdapter.Fill(dataSet, "log");

            logDataGridView.DataSource = dataSet.Tables["log"];
        }
        private void ExecuteQuery(string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.ExecuteNonQuery();

            // 将操作记录插入log表
            string logQuery = $"INSERT INTO log (Operation) VALUES ('{query}')";
            ExecuteLogQuery(logQuery);
        }

        private void ExecuteLogQuery(string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.ExecuteNonQuery();
        }
    }
}