using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace StudentManagementSystem.Web.Students
{
    public partial class AddStudent : System.Web.UI.Page
    {
        public string ConnectionString = "Server=MS-NB0006\\MSSQLSERVER15; Database=ADO; User Id=sa; Password=password-123;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CreateTableIfNotExists();
            }
        }

        protected void CreateTableIfNotExists()
        {
            string strInitializeTable = @"IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='Students' AND xtype='U')
                                            Create Table Students(
                                            Name VARCHAR(100),
                                            StudentID int PRIMARY KEY,
                                            Class VARCHAR(10),
                                            AddressName VARCHAR(100))";
            using (SqlConnection Conn = new SqlConnection(ConnectionString))
            {
                SqlCommand Cmd = new SqlCommand(strInitializeTable, Conn);
                Conn.Open();
                Cmd.ExecuteNonQuery();
            }
        }

        protected void AddStudent_Click(object sender, EventArgs e)
        {
            using (SqlConnection Conn = new SqlConnection(ConnectionString))
            {
                string strInsertQuery = @"INSERT INTO Students(Name, StudentID, Class, AddressName)
                                          VALUES(@Name, @StudentID, @Class, @AddressName)";

                using (SqlCommand Command = new SqlCommand(strInsertQuery, Conn))
                {

                    Command.Parameters.AddWithValue("@Name", StudentNameINput.Text);
                    Command.Parameters.AddWithValue("@StudentID", StudentIDInput.Text);
                    Command.Parameters.AddWithValue("@Class", StudentClassInput.Text);
                    Command.Parameters.AddWithValue("@AddressName", StudentAddressInput.Text);

                    Conn.Open();
                    Command.ExecuteNonQuery();
                }

            }

            StudentNameINput.Text = string.Empty;
            StudentIDInput.Text = string.Empty;
            StudentClassInput.Text = string.Empty;   
            StudentAddressInput.Text = string.Empty;

        }


    }
}
