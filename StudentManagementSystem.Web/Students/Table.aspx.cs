using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

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

        private void StudentDataGrid()
        {
            using (SqlConnection Conn= new SqlConnection(ConnectionString))
            {
                string Query = "Select * From Students";
                SqlCommand Cmd = new SqlCommand(Query, Conn);

                SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);
                DataTable Table = new DataTable();
                Adapter.Fill(Table);
                StudentsTable.DataSource = Table;
                StudentsTable.DataBind();
            }
        }

        protected void StudentsTable_RowEditing(object sender,GridViewEditEventArgs e)
        {

        }
    }
}