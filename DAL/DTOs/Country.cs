using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    /// <summary>  
    /// Represents a Data Transfer Object (DTO) for a Country.  
    /// </summary>  
    public class DTOCountry
    {
        /// <summary>  
        /// Initializes a new instance of the <see cref="DTOCountry"/> class.  
        /// </summary>  
        /// <param name="countryID">The unique identifier for the country.</param>  
        /// <param name="countryName">The name of the country.</param>  
        public DTOCountry(int countryID, string countryName)
        {
            CountryID = countryID;
            CountryName = countryName;
        }

        /// <summary>  
        /// Gets or sets the unique identifier for the country.  
        /// </summary>  
        public int CountryID { get; set; }

        /// <summary>  
        /// Gets or sets the name of the country.  
        /// </summary>  
        public string CountryName { get; set; }
    }
}
