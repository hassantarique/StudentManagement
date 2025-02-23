using Microsoft.Data.SqlClient;
using StudentManagement.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.ADODAL
{
    public class GenderDA
    {
        public List<Gender> GetAllGenders()
        {
            List<Gender> genders = new List<Gender>();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetAllGenders", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Gender gender = new Gender
                            {
                                GenderID = (int)reader["GenderID"],
                                GenderDescription = reader["GenderDescription"].ToString()
                            };

                            genders.Add(gender);
                        }
                    }
                }
            }

            return genders;
        }

        public List<Gender> GetGenderByID(int genderID)
        {
            List<Gender> gender = new List<Gender>();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetGenderByID", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    //Add the parameter
                    command.Parameters.Add(new SqlParameter("GenderId", System.Data.SqlDbType.Int)
                    {
                        Value = genderID
                    });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                            }
                        }
                    }
                }

            }
            return gender;
        }
    }
}
