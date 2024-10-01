using System;
using System.Data.SqlClient;
using System.Web.Caching;
using System.Web.UI;
using StudentManagementSystem.Data;
using StudentManagementSystem.Logic;


namespace StudentManagementSystem.Web.Students
{
    public partial class AddStudent : System.Web.UI.Page
    {
        public string ConnectionString = "Server=MS-NB0006\\MSSQLSERVER15; Database=ADO; User Id=sa; Password=password-123;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["StuentID"]))
                {
                    int nStudentID = int.Parse(Request.QueryString["StuentID"]);
                    //LoadStudentData(nStudentID);
                }
            }
        }

        protected void AddStudent_Click(object sender, EventArgs e)
        {
            Student newStudent = new Student
            {
                strStudentName = StudentNameINput.Text,
                nStudentId = int.Parse(StudentIDInput.Text),
                strClass = StudentClassInput.Text,
                strAddress = StudentAddressInput.Text,
            };

            StudentService studentService = new StudentService();
            studentService.AddStudent(newStudent);

            StudentNameINput.Text = string.Empty;
            StudentIDInput.Text = string.Empty;
            StudentClassInput.Text = string.Empty;
            StudentAddressInput.Text = string.Empty;
        }
    }

    
 }

