using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    /// <summary>  
    /// Represents a Data Transfer Object (DTO) for a User.  
    /// </summary>  
    public class DTOUser
    {
        /// <summary>  
        /// Initializes a new instance of the <see cref="DTOUser"/> class.  
        /// </summary>  
        /// <param name="userID">The unique identifier for the user.</param>  
        /// <param name="person">The associated person details of the user.</param>  
        /// <param name="password">The password of the user.</param>  
        /// <param name="isAdmin">Indicates whether the user has administrative privileges.</param>  
        public DTOUser(int userID, DTOPerson person, string password, bool isAdmin)
        {
            UserID = userID;
            Person = person;
            Password = password;
            IsAdmin = isAdmin;
        }

        /// <summary>  
        /// Gets or sets the unique identifier for the user.  
        /// </summary>  
        public int UserID { get; set; } = 0;

        /// <summary>  
        /// Gets or sets the associated person details of the user.  
        /// </summary>  
        public DTOPerson Person { get; set; }

        /// <summary>  
        /// Gets or sets the password of the user.  
        /// </summary>  
        public string Password { get; set; }

        /// <summary>  
        /// Gets or sets a value indicating whether the user has administrative privileges.  
        /// </summary>  
        public bool IsAdmin { get; set; }
    }
}
