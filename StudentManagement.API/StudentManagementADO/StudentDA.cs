using Microsoft.Data.SqlClient;
using StudentManagement.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.ADODAL
{
    public class StudentDA
    {
        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetAllStudents", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student student = new Student
                            {
                                ID = (int)reader["ID"],
                                Name = reader["Name"].ToString(),
                                GenderID = (int)reader["GenderID"],
                                DateOfBirth = (DateTime)reader["DateOfBirth"],
                                Height = (decimal)reader["Height"],
                                Weight = (int)reader["Weight"]
                            };
                            students.Add(student);
                        }
                    }
                }
            }
            return students;
        }


        public Student GetStudentByID(int StudentID)
        {
            Student student = null;
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetStudentByID", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    //Add Input Parameter
                    command.Parameters.Add(new SqlParameter("@StudentID", System.Data.SqlDbType.Int)
                    {
                        Value = StudentID
                    });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            student = new Student
                            {
                                Name = reader["Name"].ToString(),
                                GenderID = (int)reader["GenderID"],
                                DateOfBirth = (DateTime)reader["DateOfBirth"],
                                Height = (decimal)reader["Height"],
                                Weight = (int)reader["Weight"]
                            };
                        }
                    }
                }
            }
            return student;
        }
    }
}
