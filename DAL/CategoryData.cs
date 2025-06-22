using DAL.DTOs;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class CategoryData
    {
        public static DTOCategory GetCategoryByID(int categoryID)
        {
            using SqlConnection conn = new SqlConnection(setting.Connection);
            using SqlCommand cmd = new SqlCommand("SP_GetCategoryByID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CategoryID", categoryID);

            try
            {
                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new DTOCategory(
                        categoryID: reader.GetInt32(reader.GetOrdinal("CategoryID")),
                        categoryName: reader.GetString(reader.GetOrdinal("CategoryName"))
                    );
                }
                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error while retrieving category.", ex);
            }
        }

        public static List<DTOCategory> GetAllCategories()
        {
            var categories = new List<DTOCategory>();

            using SqlConnection conn = new SqlConnection(setting.Connection);
            using SqlCommand cmd = new SqlCommand("SP_GetAllCategories", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    categories.Add(new DTOCategory(
                        categoryID: reader.GetInt32(reader.GetOrdinal("CategoryID")),
                        categoryName: reader.GetString(reader.GetOrdinal("CategoryName"))
                    ));
                }
                return categories;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error while retrieving all categories.", ex);
            }
        }

        public static (bool, int) CreateCategory(DTOCategory category)
        {
            using SqlConnection conn = new SqlConnection(setting.Connection);
            using SqlCommand cmd = new SqlCommand("SP_CreateCategory", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);

            SqlParameter outputId = new SqlParameter("@CategoryID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputId);

            try
            {
                conn.Open();
                bool success = cmd.ExecuteNonQuery() > 0;
                return (success, (int)outputId.Value);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error while creating category.", ex);
            }
        }

        public static bool UpdateCategory(DTOCategory category)
        {
            using SqlConnection conn = new SqlConnection(setting.Connection);
            using SqlCommand cmd = new SqlCommand("SP_UpdateCategory", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CategoryID", category.CategoryID);
            cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);

            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error while updating category.", ex);
            }
        }

        public static bool DeleteCategory(int categoryID)
        {
            using SqlConnection conn = new SqlConnection(setting.Connection);
            using SqlCommand cmd = new SqlCommand("SP_DeleteCategory", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CategoryID", categoryID);

            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error while deleting category.", ex);
            }
        }
    }
}
