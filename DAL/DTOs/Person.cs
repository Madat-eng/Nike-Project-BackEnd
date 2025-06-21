using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    /// <summary>  
    /// Represents a Data Transfer Object (DTO) for a person.  
    /// </summary>  
    public class DTOPerson
    {
        /// <summary>  
        /// Initializes a new instance of the <see cref="DTOPerson"/> class.  
        /// </summary>  
        /// <param name="personID">The unique identifier for the person.</param>  
        /// <param name="firstName">The first name of the person.</param>  
        /// <param name="lastName">The last name of the person.</param>  
        /// <param name="address">The address of the person.</param>  
        /// <param name="birthDate">The birth date of the person.</param>  
        /// <param name="email">The email address of the person.</param>  
        /// <param name="country">The country associated with the person.</param>  
        public DTOPerson(int personID, string firstName, string lastName, string address, DateTime birthDate, string email, DTOCountry country)
        {
            PersonID = personID;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            BirthDate = birthDate;
            Email = email;
            Country = country;
        }

        /// <summary>  
        /// Gets or sets the unique identifier for the person.  
        /// </summary>  
        public int PersonID { get; set; }

        /// <summary>  
        /// Gets or sets the first name of the person.  
        /// </summary>  
        public string FirstName { get; set; }

        /// <summary>  
        /// Gets or sets the last name of the person.  
        /// </summary>  
        public string LastName { get; set; }

        /// <summary>  
        /// Gets or sets the address of the person.  
        /// </summary>  
        public string Address { get; set; }

        /// <summary>  
        /// Gets or sets the birth date of the person.  
        /// </summary>  
        public DateTime BirthDate { get; set; }

        /// <summary>  
        /// Gets or sets the email address of the person.  
        /// </summary>  
        public string Email { get; set; }

        /// <summary>  
        /// Gets or sets the country associated with the person.  
        /// </summary>  
        public DTOCountry Country { get; set; }
    }
}
