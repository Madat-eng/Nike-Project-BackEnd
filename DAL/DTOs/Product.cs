using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    /// <summary>  
    /// Represents a Data Transfer Object (DTO) for a Product.  
    /// </summary>  
    public class DTOProduct(int productID, string name, decimal price, int availablePiece, string description, DTOCategory category, string imageURL, string title)
    {
        /// <summary>  
        /// Unique identifier for the product.  
        /// </summary>  
        public int ProductID { get; set; } = productID;

        /// <summary>  
        /// Name of the product.  
        /// </summary>  
        public string Name { get; set; } = name;

        /// <summary>  
        /// Price of the product.  
        /// </summary>  
        public decimal Price { get; set; } = price;

        /// <summary>  
        /// Number of pieces available in stock.  
        /// </summary>  
        public int AvailablePiece { get; set; } = availablePiece;

        /// <summary>  
        /// Description of the product.  
        /// </summary>  
        public string Description { get; set; } = description;

        /// <summary>  
        /// Category to which the product belongs.  
        /// </summary>  
        public DTOCategory Category { get; set; } = category;

        /// <summary>  
        /// URL of the product's image.  
        /// </summary>  
        public string ImageURL { get; set; } = imageURL;

        /// <summary>  
        /// Title of the product.  
        /// </summary>  
        public string Title { get; set; } = title;
    }
}
