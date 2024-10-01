using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StudentManagementSystem.Logic;
using StudentManagementSystem.Data;
using System.EnterpriseServices;

namespace StudentManagementSystem.Web.Students
{
    public partial class Table : System.Web.UI.Page
    {
        public string ConnectionString = "Server=MS-NB0006\\MSSQLSERVER15; Database=ADO; User Id=sa; Password=password-123;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StudentDataGrid();
            }
        }

        protected void StudentDataGrid()
        {
            StudentService studentService = new StudentService();
            DataTable Students = studentService.GetAllStudents();   
            StudentsTable.DataSource = Students;
            StudentsTable.DataBind();
        }

        protected void StudentsTable_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (e.NewEditIndex >= 0 && e.NewEditIndex < StudentsTable.Rows.Count)
            {
                int studentId = Convert.ToInt32(StudentsTable.DataKeys[e.NewEditIndex].Value);
                StudentService studentService = new StudentService();
                Student student = studentService.GetStudentById(studentId);

                if (student != null)
                {
                    Session["CurrentStudent"] = student;
                    StudentsTable.EditIndex = e.NewEditIndex;
                    LoadStudentDetails();
                    StudentDataGrid();
                }
            }
        }


        private void LoadStudentDetails()
        {

            Student student = Session["CurrentStudent"] as Student;

            if (student != null)
            {
               
                int editIndex = StudentsTable.EditIndex;

                if (editIndex >= 0 && editIndex < StudentsTable.Rows.Count)
                {
                    GridViewRow row = StudentsTable.Rows[editIndex];

                    TextBox studentNameInput = row.FindControl("StudentNameInput") as TextBox;
                    TextBox studentIDInput = row.FindControl("StudentIDInput") as TextBox;
                    TextBox studentClassInput = row.FindControl("StudentClassInput") as TextBox;
                    TextBox studentAddressInput = row.FindControl("StudentAddressInput") as TextBox;
                }
            }
            else
            {
                
            }
        }

        protected void StudentsTable_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Student student = Session["CurrentStudent"] as Student;

            if (student != null)
            {

                TextBox txtName = (TextBox)StudentsTable.Rows[e.RowIndex].FindControl("StudentNameINput");
                TextBox txtClass = (TextBox)StudentsTable.Rows[e.RowIndex].FindControl("StudentClassInput");
                TextBox txtAddress = (TextBox)StudentsTable.Rows[e.RowIndex].FindControl("StudentAddressInput");


                student.strStudentName = txtName.Text;
                student.strClass = txtClass.Text;
                student.strAddress = txtAddress.Text;

                StudentService studentService = new StudentService();
                studentService.UpdateStudent(student.nStudentId, student.strStudentName, student.strClass, student.strAddress);

                StudentsTable.EditIndex = -1;
                Session.Remove("CurrentStudent");
                StudentDataGrid();
            }
        }


        protected void StudentsTable_RowCancelingEdit(object sender,GridViewCancelEditEventArgs e)
        {
            StudentsTable.EditIndex = -1;
            StudentDataGrid();
        }

        protected void StudentsTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int nId = (int)StudentsTable.DataKeys[e.RowIndex].Value;
            DeleteStudent(nId);
            StudentDataGrid();

        }
    }
}