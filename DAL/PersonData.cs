//using DAL.DTOs;
//using Microsoft.Data.SqlClient;
//using System.Data;

//namespace DAL
//{
//    public class PersonData
//    {
//        public static DTOPerson GetPersonByID(int personID)
//        {
//            using SqlConnection conn = new SqlConnection(setting.Connection);
//            using SqlCommand cmd = new SqlCommand("SP_GetPersonByID", conn);
//            cmd.CommandType = CommandType.StoredProcedure;
//            cmd.Parameters.AddWithValue("@PersonID", personID);

//            try
//            {
//                conn.Open();
//                using SqlDataReader reader = cmd.ExecuteReader();
//                if (reader.Read())
//                {
//                    return new DTOPerson(
//                        personID: reader.GetInt32(reader.GetOrdinal("PersonID")),
//                        firstName: reader.GetString(reader.GetOrdinal("FirstName")),
//                        lastName: reader.GetString(reader.GetOrdinal("LastName")),
//                        address: reader.GetString(reader.GetOrdinal("Address")),
//                        birthDate: reader.GetDateTime(reader.GetOrdinal("BirthDate")),
//                        email: reader.GetString(reader.GetOrdinal("Email")),
//                        country: new DTOCountry(
//                            countryID: reader.GetInt32(reader.GetOrdinal("CountryID")),
//                            countryName: reader.GetString(reader.GetOrdinal("CountryName"))
//                        )
//                    );
//                }
//                return null;
//            }
//            catch (SqlException ex)
//            {
//                throw new Exception("An error occurred while retrieving the person from the database.", ex);
//            }
//        }

//        public static bool CreatePerson(DTOPerson person)
//        {
//            using SqlConnection conn = new SqlConnection(setting.Connection);
//            using SqlCommand cmd = new SqlCommand("SP_CreatePerson", conn);
//            cmd.CommandType = CommandType.StoredProcedure;

//            cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
//            cmd.Parameters.AddWithValue("@LastName", person.LastName);
//            cmd.Parameters.AddWithValue("@Address", person.Address);
//            cmd.Parameters.AddWithValue("@BirthDate", person.BirthDate);
//            cmd.Parameters.AddWithValue("@Email", person.Email);
//            cmd.Parameters.AddWithValue("@CountryID", person.Country.CountryID);

//            try
//            {
//                conn.Open();
//                int rowsAffected = cmd.ExecuteNonQuery();
//                return rowsAffected > 0;
//            }
//            catch (SqlException ex)
//            {
//                throw new Exception("An error occurred while creating the person.", ex);
//            }
//        }

//        public static bool UpdatePerson(DTOPerson person)
//        {
//            using SqlConnection conn = new SqlConnection(setting.Connection);
//            using SqlCommand cmd = new SqlCommand("SP_UpdatePerson", conn);
//            cmd.CommandType = CommandType.StoredProcedure;

//            cmd.Parameters.AddWithValue("@PersonID", person.PersonID);
//            cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
//            cmd.Parameters.AddWithValue("@LastName", person.LastName);
//            cmd.Parameters.AddWithValue("@Address", person.Address);
//            cmd.Parameters.AddWithValue("@BirthDate", person.BirthDate);
//            cmd.Parameters.AddWithValue("@Email", person.Email);
//            cmd.Parameters.AddWithValue("@CountryID", person.Country.CountryID);

//            try
//            {
//                conn.Open();
//                int rowsAffected = cmd.ExecuteNonQuery();
//                return rowsAffected > 0;
//            }
//            catch (SqlException ex)
//            {
//                throw new Exception("An error occurred while updating the person.", ex);
//            }
//        }
//        public static bool DeletePerson(int personID)
//        {
//            using SqlConnection conn = new SqlConnection(setting.Connection);
//            using SqlCommand cmd = new SqlCommand("SP_DeletePerson", conn);
//            cmd.CommandType = CommandType.StoredProcedure;
//            cmd.Parameters.AddWithValue("@PersonID", personID);

//            try
//            {
//                conn.Open();
//                int rowsAffected = cmd.ExecuteNonQuery();
//                return rowsAffected > 0;
//            }
//            catch (SqlException ex)
//            {
//                throw new Exception("An error occurred while deleting the Person.", ex);
//            }
//        }
//    }
//}
