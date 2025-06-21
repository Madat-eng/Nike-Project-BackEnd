using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    /// <summary>  
    /// Represents a Data Transfer Object (DTO) for a category.  
    /// </summary>  
    public class DTOCategory
    {
        /// <summary>  
        /// Initializes a new instance of the <see cref="DTOCategory"/> class with the specified category ID and name.  
        /// </summary>  
        /// <param name="categoryID">The unique identifier for the category.</param>  
        /// <param name="categoryName">The name of the category.</param>  
        public DTOCategory(int categoryID, string categoryName)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
        }

        /// <summary>  
        /// Gets or sets the unique identifier for the category.  
        /// </summary>  
        public int CategoryID { get; set; }

        /// <summary>  
        /// Gets or sets the name of the category.  
        /// </summary>  
        public string CategoryName { get; set; }
    }
}
