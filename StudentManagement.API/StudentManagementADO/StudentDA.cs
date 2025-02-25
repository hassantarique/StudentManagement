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
        public void InsertStudent(Student student)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertStudent", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Name", System.Data.SqlDbType.NVarChar) { Value = student.Name });

                    command.Parameters.Add(new SqlParameter("@GenderID", System.Data.SqlDbType.Int) { Value = student.GenderID });

                    command.Parameters.Add(new SqlParameter("@DateOfBirth", System.Data.SqlDbType.DateTime) { Value = student.DateOfBirth });

                    command.Parameters.Add(new SqlParameter("@Height", System.Data.SqlDbType.Decimal) { Value = student.Height });

                    command.Parameters.Add(new SqlParameter("@Weight", System.Data.SqlDbType.Int) { Value = student.Weight });

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateStudent(Student student)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UpdateStudent", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@StudentId", System.Data.SqlDbType.Int) { Value = student.ID });

                    command.Parameters.Add(new SqlParameter("@Name", System.Data.SqlDbType.NVarChar) { Value = student.Name });

                    command.Parameters.Add(new SqlParameter("@GenderID", System.Data.SqlDbType.Int) { Value = student.GenderID });

                    command.Parameters.Add(new SqlParameter("@DateOfBirth", System.Data.SqlDbType.DateTime) { Value = student.DateOfBirth });

                    command.Parameters.Add(new SqlParameter("@Height", System.Data.SqlDbType.Decimal) { Value = student.Height });

                    command.Parameters.Add(new SqlParameter("@Weight", System.Data.SqlDbType.Int) { Value = student.Weight });

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteStudent(int studentId)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DeleteStudent", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add parameter
                    command.Parameters.Add(new SqlParameter("@StudentId", System.Data.SqlDbType.Int)
                    {
                        Value = studentId
                    });

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
