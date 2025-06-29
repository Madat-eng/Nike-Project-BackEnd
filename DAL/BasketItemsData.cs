using DAL.DTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class BasketItemsData
    {
        public static DTOBasketItems GetBasketItemByID(int basketItemID)
        {
            using SqlConnection conn = new SqlConnection(setting.Connection);
            using SqlCommand cmd = new SqlCommand("SP_GetBasketItemByID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BasketItemID", basketItemID);

            try
            {
                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new DTOBasketItems(
                        basketItemID: reader.GetInt32(reader.GetOrdinal("BasketItemID")),
                        basket: new DTOBasket(
                            basketID: reader.GetInt32(reader.GetOrdinal("BasketID")),
                            user: null,
                            addedAt: reader.GetDateTime(reader.GetOrdinal("AddedAt"))
                        ),
                        product: new DTOProduct(
                            productID: reader.GetInt32(reader.GetOrdinal("ProductID")),
                            name: reader.GetString(reader.GetOrdinal("Name")),
                            price: reader.GetDecimal(reader.GetOrdinal("Price")),
                            availablePiece: reader.GetInt32(reader.GetOrdinal("AvailablePiece")),
                            description: reader.GetString(reader.GetOrdinal("Description")),
                            category: null,
                            imageURL: reader.GetString(reader.GetOrdinal("ImageURL")),
                            title: reader.GetString(reader.GetOrdinal("Title"))
                        ),
                        quantity: reader.GetInt32(reader.GetOrdinal("Quantity"))
                    );
                }
                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error while fetching basket item.", ex);
            }
        }

        public static List<DTOBasketItems> GetAllBasketItems()
        {
            List<DTOBasketItems> items = new();
            using SqlConnection conn = new SqlConnection(setting.Connection);
            using SqlCommand cmd = new SqlCommand("SP_GetAllBasketItems", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    items.Add(new DTOBasketItems(
                        basketItemID: reader.GetInt32(reader.GetOrdinal("BasketItemID")),
                        basket: new DTOBasket(
                            basketID: reader.GetInt32(reader.GetOrdinal("BasketID")),
                            user: null,
                            addedAt: reader.GetDateTime(reader.GetOrdinal("AddedAt"))
                        ),
                        product: new DTOProduct(
                            productID: reader.GetInt32(reader.GetOrdinal("ProductID")),
                            name: reader.GetString(reader.GetOrdinal("Name")),
                            price: reader.GetDecimal(reader.GetOrdinal("Price")),
                            availablePiece: reader.GetInt32(reader.GetOrdinal("AvailablePiece")),
                            description: reader.GetString(reader.GetOrdinal("Description")),
                            category: null,
                            imageURL: reader.GetString(reader.GetOrdinal("ImageURL")),
                            title: reader.GetString(reader.GetOrdinal("Title"))
                        ),
                        quantity: reader.GetInt32(reader.GetOrdinal("Quantity"))
                    ));
                }
                return items;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error while fetching basket items.", ex);
            }
        }

        public static (bool success, int basketItemID) CreateBasketItem(DTOBasketItems_Create item)
        {
            using SqlConnection conn = new SqlConnection(setting.Connection);
            using SqlCommand cmd = new SqlCommand("SP_CreateBasketItem", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BasketID", item.BasketID);
            cmd.Parameters.AddWithValue("@ProductID", item.ProductID);
            cmd.Parameters.AddWithValue("@Quantity", item.Quantity);

            SqlParameter outputParam = new SqlParameter("@BasketItemID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputParam);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                int basketItemID = Convert.ToInt32(outputParam.Value);
                return (true, basketItemID);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error while creating basket item.", ex);
            }
        }

        public static bool UpdateBasketItem(DTOBasketItems_Update item)
        {
            using SqlConnection conn = new SqlConnection(setting.Connection);
            using SqlCommand cmd = new SqlCommand("SP_UpdateBasketItem", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BasketItemID", item.BasketItemID);
            //cmd.Parameters.AddWithValue("@BasketID", item.Basket.BasketID);
            //cmd.Parameters.AddWithValue("@ProductID", item.Product.ProductID);
            cmd.Parameters.AddWithValue("@Quantity", item.Quantity);

            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error while updating basket item.", ex);
            }
        }

        public static bool DeleteBasketItem(int basketItemID)
        {
            using SqlConnection conn = new SqlConnection(setting.Connection);
            using SqlCommand cmd = new SqlCommand("SP_DeleteBasketItem", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BasketItemID", basketItemID);

            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error while deleting basket item.", ex);
            }
        }
    }
}
