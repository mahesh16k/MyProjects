using StudentApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApplication.Repository
{
    public class StudentRepository : IStudentRepository
    {
        string connetionString = @"Data Source =YUVA\SQLEXPRESS;Initial Catalog = Student;User ID=sa;Password=yuva@123";
        
        /// <summary>
        /// CreateStudent Method
        /// </summary>
        /// <param name="student"></param>
        /// <returns>bool</returns>
        public bool CreateStudent(StudentDto student)
        {
            SqlConnection sqlconnection = new SqlConnection(connetionString);
            SqlCommand sqlCommand = new SqlCommand("[dbo].[Insert_Students]", sqlconnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@A_Name ", student.Name);
            sqlCommand.Parameters.AddWithValue("@A_RollNumber", student.RollNumber);
            sqlCommand.Parameters.AddWithValue("@A_Age", student.Age);
            sqlCommand.Parameters.AddWithValue("@A_Email", student.Email);
            sqlCommand.Parameters.AddWithValue("@A_Mobile", student.Mobile);
            sqlCommand.Parameters.AddWithValue("@A_City", student.City);

            sqlconnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlconnection.Close();
            return true;
        }

        /// <summary>
        /// Method to Update Student
        /// </summary>
        /// <param name="student"></param>
        /// <returns>bool</returns>
        public bool UpdateStudent(StudentDto student)
        {
            SqlConnection sqlconnection = new SqlConnection(connetionString);
            SqlCommand sqlCommand = new SqlCommand("[dbo].[UpdateStudent]", sqlconnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@A_Id", student.id);
            sqlCommand.Parameters.AddWithValue("@A_Name ", student.Name);
            sqlCommand.Parameters.AddWithValue("@A_RollNumber", student.RollNumber);
            sqlCommand.Parameters.AddWithValue("@A_Age", student.Age);
            sqlCommand.Parameters.AddWithValue("@A_Email", student.Email);
            sqlCommand.Parameters.AddWithValue("@A_Mobile", student.Mobile);
            sqlCommand.Parameters.AddWithValue("@A_City", student.City);
            sqlconnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlconnection.Close();
            return true;
        }

        /// <summary>
        /// Method to Get Studen By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>StudentDto</returns>
        public StudentDto GetStudentById(int id)
        {
            StudentDto dto = new StudentDto();
            SqlConnection connection = new SqlConnection(connetionString);
            SqlCommand command = new SqlCommand("[dbo].[GetStudentById]", connection);
            command.Parameters.AddWithValue("@Id", id);

            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                dto.id = Convert.ToInt32(dataReader["id"]);
                dto.Name = dataReader["Name"].ToString();
                dto.RollNumber = dataReader["RollNumber"].ToString();
                dto.Age = Convert.ToInt32(dataReader["Age"]);
                dto.Email = dataReader["Email"].ToString();
                dto.Mobile = Convert.ToInt64(dataReader["Mobile"]);
                dto.City = dataReader["City"].ToString();
            }

            return dto;
        }

        /// <summary>
        /// Delete Student By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteStudent(int id)
        {
            SqlConnection sqlconnection = new SqlConnection(connetionString);
            SqlCommand sqlCommand = new SqlCommand("[dbo].[DeleteStudent]", sqlconnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Id", id);
            sqlconnection.Open();
            int i = sqlCommand.ExecuteNonQuery();
            sqlconnection.Close();
            return true;
        }

        /// <summary>
        /// Get List Of Students
        /// </summary>
        /// <returns>List<StudentDto></returns>
        public List<StudentDto> GetStudents()
        {
            List<StudentDto> studentDtos = new List<StudentDto>();
            SqlConnection sqlConnection = new SqlConnection(connetionString);

            SqlCommand sqlCommand = new SqlCommand("[dbo].[GetStudents]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlConnection.Open();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                StudentDto student = new StudentDto();
                student.id = Convert.ToInt32(dataRow["id"]);
                student.Name = Convert.ToString(dataRow["Name"]);
                student.RollNumber = Convert.ToString(dataRow["RollNumber"]);
                student.Age = Convert.ToInt32(dataRow["Age"]);
                student.Mobile = Convert.ToInt64(dataRow["Mobile"]);
                student.City =Convert.ToString(dataRow["City"]);
                studentDtos.Add(student);
            }
            return studentDtos;
        }
    }
}
