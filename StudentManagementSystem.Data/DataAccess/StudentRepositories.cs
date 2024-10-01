using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Data;


namespace StudentManagementSystem.Data
{
    public class StudentRepositories
    {
        public string ConnectionString = "Server=MS-NB0006\\MSSQLSERVER15; Database=ADO; User Id=sa; Password=password-123;";

        public void CreateTableIfNotExists()
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


        public void AddStudent_Click(Student Students)
        {
            using (SqlConnection Conn = new SqlConnection(ConnectionString))
            {
                string strInsertQuery = @"INSERT INTO Students(Name, StudentID, Class, AddressName)
                                          VALUES(@Name, @StudentID, @Class, @AddressName)";

                using (SqlCommand Command = new SqlCommand(strInsertQuery, Conn))
                {

                    Command.Parameters.AddWithValue("@Name", Students.strStudentName);
                    Command.Parameters.AddWithValue("@StudentID", Students.nStudentId);
                    Command.Parameters.AddWithValue("@Class", Students.strClass);
                    Command.Parameters.AddWithValue("@AddressName", Students.strAddress);

                    Conn.Open();
                    Command.ExecuteNonQuery();
                }

            }
        }

        public DataTable GetStudents()//represents data in in-memory
        {
            using (SqlConnection Conn = new SqlConnection(ConnectionString)) 
            {
                string strQuery = "SELECT * FROM Students";
                SqlCommand sqlCmd= new SqlCommand(strQuery, Conn);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                return Table;

            }
        }

        public void UpdateStudent(int StudentId, string strStudentName, string StudentClass, string strAddress)
        {
            using (SqlConnection Conn = new SqlConnection(ConnectionString))
            {
                string strQuery = "Update Students SET NAme=@Name,StudentID=@StudentID,Class=@Class,AddressName = @Address WHERE StudentID=@ORiginalID";
                SqlCommand sqlCmd= new SqlCommand(strQuery, Conn);
                sqlCmd.Parameters.AddWithValue("@Name", strStudentName);
                sqlCmd.Parameters.AddWithValue("@StudentID", StudentId);
                sqlCmd.Parameters.AddWithValue("@Class", StudentClass);
                sqlCmd.Parameters.AddWithValue("@Address", strAddress);
                sqlCmd.Parameters.AddWithValue("@OriginalID", StudentId);

                Conn.Open();
                sqlCmd.ExecuteNonQuery();
                Conn.Close();
            }
        }

        public Student GetStudentById(int studentId)
        {
            StudentRepositories repository = new StudentRepositories();

            DataTable dt = repository.GetStudents();
            foreach (DataRow row in dt.Rows)
            {
                if ((int)row["StudentID"] == studentId)
                {

                    return new Student
                    {
                        nStudentId = (int)row["StudentID"],
                        strStudentName = row["Name"].ToString(),
                        strClass = row["Class"].ToString(),
                        strAddress = row["AddressName"].ToString()
                    };
                }
            }
            return null;
        }

        public void DeleteBook(int nId)
        {
            using (SqlConnection Conn = new SqlConnection(ConnectionString))
            {
                string query = "Delete from Books WHERE Id = @ID";
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@Id", nId);
                Conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
