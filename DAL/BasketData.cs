using DAL.DTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class BasketData
    {
        public static DTOBasket GetBasketByID(int basketID)
        {
            using SqlConnection conn = new SqlConnection(setting.Connection);
            using SqlCommand cmd = new SqlCommand("SP_GetBasketByID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BasketID", basketID);

            try
            {
                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new DTOBasket(
                        basketID: reader.GetInt32(reader.GetOrdinal("BasketID")),
                        user: new DTOUser(
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
                        ),
                        addedAt: reader.GetDateTime(reader.GetOrdinal("AddedAt"))
                    );
                }
                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while retrieving the basket.", ex);
            }
        }

        public static List<DTOBasket> GetAllBaskets()
        {
            List<DTOBasket> baskets = new List<DTOBasket>();
            using SqlConnection conn = new SqlConnection(setting.Connection);
            using SqlCommand cmd = new SqlCommand("SP_GetAllBaskets", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    baskets.Add(new DTOBasket(
                        basketID: reader.GetInt32(reader.GetOrdinal("BasketID")),
                        user: new DTOUser(
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
                        ),
                        addedAt: reader.GetDateTime(reader.GetOrdinal("AddedAt"))
                    ));
                }
                return baskets;
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while retrieving baskets.", ex);
            }
        }

        public static (bool success, int basketID) CreateBasket(DTOBasket_CreatBasket basket)
        {
            using SqlConnection conn = new SqlConnection(setting.Connection);
            using SqlCommand cmd = new SqlCommand("SP_CreateBasket", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", basket.UserID);
            cmd.Parameters.AddWithValue("@AddedAt", basket.AddedAt);

            SqlParameter outputParam = new SqlParameter("@BasketID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputParam);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                int basketID = Convert.ToInt32(outputParam.Value);
                return (true, basketID);
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while creating the basket.", ex);
            }
        }

        public static bool UpdateBasket(DTOBasket basket)
        {
            using SqlConnection conn = new SqlConnection(setting.Connection);
            using SqlCommand cmd = new SqlCommand("SP_UpdateBasket", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BasketID", basket.BasketID);
            cmd.Parameters.AddWithValue("@UserID", basket.User.UserID);
            cmd.Parameters.AddWithValue("@AddedAt", basket.AddedAt);

            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while updating the basket.", ex);
            }
        }

        public static bool DeleteBasket(int basketID)
        {
            using SqlConnection conn = new SqlConnection(setting.Connection);
            using SqlCommand cmd = new SqlCommand("SP_DeleteBasket", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BasketID", basketID);

            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while deleting the basket.", ex);
            }
        }
    }
}
