using DAL.DTOs;
using Microsoft.Data.SqlClient;
using System.Data;


namespace DAL
{
    public class ProductData
    {
        public static DTOProduct GetProductByID(int productID)
        {
            using SqlConnection conn = new SqlConnection(setting.Connection);
            using SqlCommand cmd = new SqlCommand("SP_GetProductByID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductID", productID);

            try
            {
                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new DTOProduct(
                        productID: reader.GetInt32(reader.GetOrdinal("ProductID")),
                        name: reader.GetString(reader.GetOrdinal("Name")),
                        price: reader.GetDecimal(reader.GetOrdinal("Price")),
                        availablePiece: reader.GetInt32(reader.GetOrdinal("AvailablePiece")),
                        description: reader.GetString(reader.GetOrdinal("Description")),
                        category: new DTOCategory(
                            categoryID: reader.GetInt32(reader.GetOrdinal("CategoryID")),
                            categoryName: reader.GetString(reader.GetOrdinal("CategoryName"))
                        ),
                        imageURL: reader.GetString(reader.GetOrdinal("ImageURL")),
                        title: reader.GetString(reader.GetOrdinal("Title"))
                    );
                }
                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while retrieving the product.", ex);
            }
        }

        public static (bool success, int productId) CreateProduct(DTOProduct product)
        {
            using SqlConnection conn = new SqlConnection(setting.Connection);
            using SqlCommand cmd = new SqlCommand("SP_CreateProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@AvailablePiece", product.AvailablePiece);
            cmd.Parameters.AddWithValue("@Description", product.Description);
            cmd.Parameters.AddWithValue("@CategoryID", product.Category.CategoryID);
            cmd.Parameters.AddWithValue("@ImageURL", product.ImageURL);
            cmd.Parameters.AddWithValue("@Title", product.Title);

            SqlParameter outputParam = new SqlParameter("@ProductID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputParam);

            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return (rowsAffected > 0, (int)outputParam.Value);
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while creating the product.", ex);
            }
        }

        public static bool UpdateProduct(DTOProduct product)
        {
            using SqlConnection conn = new SqlConnection(setting.Connection);
            using SqlCommand cmd = new SqlCommand("SP_UpdateProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@AvailablePiece", product.AvailablePiece);
            cmd.Parameters.AddWithValue("@Description", product.Description);
            cmd.Parameters.AddWithValue("@CategoryID", product.Category.CategoryID);
            cmd.Parameters.AddWithValue("@ImageURL", product.ImageURL);
            cmd.Parameters.AddWithValue("@Title", product.Title);

            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while updating the product.", ex);
            }
        }

        public static bool DeleteProduct(int productID)
        {
            using SqlConnection conn = new SqlConnection(setting.Connection);
            using SqlCommand cmd = new SqlCommand("SP_DeleteProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductID", productID);

            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while deleting the product.", ex);
            }
        }
    }
}

