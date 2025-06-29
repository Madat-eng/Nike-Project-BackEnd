using DAL;
using DAL.DTOs;
using System;

namespace BAL
{
    public class ProductBusiness
    {
        public static DTOProduct GetProductById(int productId)
        {
            try
            {
                var product = ProductData.GetProductByID(productId);
                if (product == null)
                    throw new Exception($"Product with ID {productId} was not found.");
                return product;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Service error while fetching product with ID {productId}.", ex);
            }
        }

        public static (bool success, int productId) CreateProduct(DTOProduct product)
        {
            try
            {
                return ProductData.CreateProduct(product);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Service error while creating product.", ex);
            }
        }

        public static bool UpdateProduct(DTOProduct product)
        {
            try
            {
                return ProductData.UpdateProduct(product);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Service error while updating product with ID {product.ProductID}.", ex);
            }
        }

        public static bool DeleteProduct(int productId)
        {
            try
            {
                return ProductData.DeleteProduct(productId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Service error while deleting product with ID {productId}.", ex);
            }
        }

        public static List<DTOProduct> GetAllProducts()
        {
            try
            {
                var products = ProductData.GetAllProducts();
                return products;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Service error while fetching all products.", ex);
            }
        }
        public static List<DTOProduct> GetRandomProducts(int count)
        {
            try
            {
                var products = ProductData.GetRandomProducts(count);
                return products;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Service error while fetching {count} random products.", ex);
            }
        }

        public static List<DTOProduct> GetAllProductsByCategory(string categoryName)
        {
            try
            {
                var products = ProductData.GetAllProductsByCategory(categoryName);
                return products;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Service error while fetching products by category '{categoryName}'.", ex);
            }
        }
    }
}
