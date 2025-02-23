using Microsoft.Data.SqlClient;
using StudentManagement.DomainObjects;

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

        public Gender GetGenderByID(int GenderID)
        {
            Gender gender = null;

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetGenderByID", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    //Add Input Parameter
                    command.Parameters.Add(new SqlParameter("@GenderId", System.Data.SqlDbType.Int)
                    {
                        Value = GenderID
                    });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            gender = new Gender
                            {
                                GenderID = (int)reader["GenderID"],
                                GenderDescription = reader["GenderDescription"].ToString()
                            };
                        }
                    }
                }
            }
            return gender;
        }
    }
}
