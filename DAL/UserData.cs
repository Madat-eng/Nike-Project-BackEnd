using DAL.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DAL
{
    public class UserData
    {
        //      private readonly IConfiguration _configuration;
        //public string ConnectionString { get; }

        //public UserData()
        //{
        //    _configuration = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json")
        //        .Build();

        //    ConnectionString = _configuration.GetConnectionString("DefaultConnection")!;
        //}





        /*
         {
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=Nike;User Id=sa;Password=sa123456;Encrypt=False;TrustServerCertificate=True;Connection Timeout=30;"
  }
}

         */


        public static DTOUser GetUserByID(int userID)
    {
            string ConnectionString = "Server=localhost;Database=Nike;User Id=sa;Password=sa123456;Encrypt=False;TrustServerCertificate=True;Connection Timeout=30;";
        using SqlConnection conn = new SqlConnection(ConnectionString);
        using SqlCommand cmd = new SqlCommand("SP_Name", conn);//TODO: replace "SP_Name" with the actual stored procedure name
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
            Console.WriteLine("Database error: " + ex.Message);
            return null;
        }
    }
    }
}
