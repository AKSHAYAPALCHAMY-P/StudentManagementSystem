using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Data;

namespace StudentManagementSystem.Logic
{
    public class StudentService
    {
        private StudentRepositories StudentRepositories = new StudentRepositories();

        public void InitializeDataBase()
        {
            StudentRepositories.CreateTableIfNotExists();
        }

        public void AddStudent(Student Students)
        {
            StudentRepositories.AddStudent_Click(Students);
        }

        public DataTable GetAllStudents()
        {
            return StudentRepositories.GetStudents();
        }
        public void UpdateStudent(int StudentId, string strStudentName, string StudentClass, string strAddress)
        {
            StudentRepositories.UpdateStudent(StudentId, strStudentName, StudentClass, strAddress);
        }
        public Student GetStudentById(int studentId)
        {
            return StudentRepositories.GetStudentById(studentId);
        }

        public void DeleteStudent(int nId) 
        {
            StudentRepositories.DeleteBook(nId);
        }

    }
}
