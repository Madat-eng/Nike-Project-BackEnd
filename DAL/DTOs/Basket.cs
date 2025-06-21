// Required namespaces for DTO definitions and data types
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    /// <summary>
    /// Represents a Data Transfer Object (DTO) for a Basket.
    /// </summary>
    public class DTOBasket
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DTOBasket"/> class.
        /// </summary>
        /// <param name="basketID">The unique identifier for the basket.</param>
        /// <param name="user">The user associated with the basket.</param>
        /// <param name="addedAt">The date and time when the basket was added.</param>
        public DTOBasket(int basketID, DTOUser user, DateTime addedAt)
        {
            BasketID = basketID; // Unique identifier for the basket
            User = user;         // The user who owns the basket
            AddedAt = addedAt;   // Timestamp when the basket was created
        }

        /// <summary>
        /// Gets or sets the unique identifier for the basket.
        /// </summary>
        public int BasketID { get; set; }

        /// <summary>
        /// Gets or sets the user associated with the basket.
        /// </summary>
        public DTOUser User { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the basket was added.
        /// </summary>
        public DateTime AddedAt { get; set; }
    }
}
