// DAL (تم تعديله ليرفع الأخطاء)

using DAL.DTOs;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class UserData
    {
        public static DTOUser GetUserByID(int userID)
        {
            using SqlConnection conn = new SqlConnection(setting.Connection);
            using SqlCommand cmd = new SqlCommand("SP_GetUserByID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", userID);

            try
            {
                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new DTOUser(
                        userID: reader.GetInt32(reader.GetOrdinal("UserID")),
                        password: reader.GetString(reader.GetOrdinal("Password")),
                        isAdmin: reader.GetBoolean(reader.GetOrdinal("IsAdmin")),
                        person: new DTOPerson(
                            personID: reader.GetInt32(reader.GetOrdinal("PersonID")),
                            firstName: reader.GetString(reader.GetOrdinal("FirstName")),
                            lastName: reader.GetString(reader.GetOrdinal("LastName")),
                            address: reader.GetString(reader.GetOrdinal("Address")),
                            birthDate: reader.GetDateTime(reader.GetOrdinal("BirthDate")),
                            email: reader.GetString(reader.GetOrdinal("Email")),
                            country: new DTOCountry(
                                countryID: reader.GetInt32(reader.GetOrdinal("CountryID")),
                                countryName: reader.GetString(reader.GetOrdinal("CountryName"))
                            )
                        )
                    );
                }
                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while retrieving the user from the database.", ex);
            }
        }

        public static (bool,int, int) CreateUser(DTOUser user)
        {
            using SqlConnection conn = new SqlConnection(setting.Connection);
            using SqlCommand cmd = new SqlCommand("SP_CreateUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
            cmd.Parameters.AddWithValue("@FirstName", user.Person.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.Person.LastName);
            cmd.Parameters.AddWithValue("@Address", user.Person.Address);
            cmd.Parameters.AddWithValue("@BirthDate", user.Person.BirthDate);
            cmd.Parameters.AddWithValue("@Email", user.Person.Email);
            cmd.Parameters.AddWithValue("@CountryID", user.Person.Country.CountryID);

            // 🔴 هذا هو الحل الصحيح: تعريف البراميتر كمخرج
            SqlParameter outputParam_PersonID = new SqlParameter("@PersonID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter outputParam_UserID = new SqlParameter("@UserID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputParam_PersonID);
            cmd.Parameters.Add(outputParam_UserID);


            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                // لو حبيت ترجع الـ PersonID الجديد:
                int newPersonID = (int)outputParam_PersonID.Value;
                int newUserID = (int)outputParam_UserID.Value;

                user.Person.PersonID = newPersonID;
                user.UserID = newUserID;

                return (rowsAffected > 0,newPersonID ,newUserID);
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while creating the user.", ex);
            }
        }


        public static bool UpdateUser(DTOUser user)
        {
            using SqlConnection conn = new SqlConnection(setting.Connection);
            using SqlCommand cmd = new SqlCommand("SP_UpdateUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", user.UserID);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
            cmd.Parameters.AddWithValue("@PersonID", 0);
            cmd.Parameters.AddWithValue("@FirstName", user.Person.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.Person.LastName);
            cmd.Parameters.AddWithValue("@Address", user.Person.Address);
            cmd.Parameters.AddWithValue("@BirthDate", user.Person.BirthDate);
            cmd.Parameters.AddWithValue("@Email", user.Person.Email);
            cmd.Parameters.AddWithValue("@CountryID", user.Person.Country.CountryID);

            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while updating the user.", ex);
            }
        }

        public static bool DeleteUser(int userID)
        {
            using SqlConnection conn = new SqlConnection(setting.Connection);
            using SqlCommand cmd = new SqlCommand("SP_DeleteUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", userID);

            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while deleting the user.", ex);
            }
        }
    }
}
