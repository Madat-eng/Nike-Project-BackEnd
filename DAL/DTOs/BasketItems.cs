// Required namespaces for DTO definitions and data types
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    /// <summary>
    /// Represents a Data Transfer Object (DTO) for an item in a basket.
    /// </summary>
    public class DTOBasketItems
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DTOBasketItems"/> class.
        /// </summary>
        /// <param name="basketItemID">The unique identifier for the basket item.</param>
        /// <param name="basket">The basket to which this item belongs.</param>
        /// <param name="product">The product associated with this basket item.</param>
        /// <param name="quantity">The quantity of the product in the basket.</param>
        public DTOBasketItems(int basketItemID, DTOBasket basket, DTOProduct product, int quantity)
        {
            BasketItemID = basketItemID; // Unique identifier for the basket item
            Basket = basket;             // The basket this item belongs to
            Product = product;           // The product in the basket
            Quantity = quantity;         // Quantity of the product
        }

        /// <summary>
        /// Gets or sets the unique identifier for the basket item.
        /// </summary>
        public int BasketItemID { get; set; }

        /// <summary>
        /// Gets or sets the basket to which this item belongs.
        /// </summary>
        public DTOBasket Basket { get; set; }

        /// <summary>
        /// Gets or sets the product associated with this basket item.
        /// </summary>
        public DTOProduct Product { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product in the basket.
        /// </summary>
        public int Quantity { get; set; }
    }
}
