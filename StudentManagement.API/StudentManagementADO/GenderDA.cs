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
    }
}
