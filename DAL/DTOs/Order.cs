// Required namespaces for DTO definitions and data types
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    /// <summary>
    /// Represents a Data Transfer Object (DTO) for an Order.
    /// </summary>
    public class DTOOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DTOOrder"/> class.
        /// </summary>
        /// <param name="orderID">The unique identifier for the order.</param>
        /// <param name="basket">The basket associated with the order.</param>
        /// <param name="user">The user who placed the order.</param>
        /// <param name="orderDate">The date and time when the order was placed.</param>
        /// <param name="totalAmount">The total amount for the order.</param>
        /// <param name="status">The status of the order (e.g., Pending, Completed, Cancelled).</param>
        /// <param name="paymentMethod">The payment method used for the order.</param>
        /// <param name="shoppingAddress">The shipping address for the order.</param>
        public DTOOrder(int orderID, DTOBasket basket, DTOUser user, DateTime orderDate, decimal totalAmount, string status, string shoppingAddress)
        {
            OrderID = orderID;                 // Unique identifier for the order
            Basket = basket;                   // The basket associated with the order
            User = user;                       // The user who placed the order
            OrderDate = orderDate;             // Date and time when the order was placed
            TotalAmount = totalAmount;         // Total amount for the order
            Status = status;                   // Status of the order
            ShoppingAddress = shoppingAddress; // Shipping address for the order
        }

        /// <summary>
        /// Gets or sets the unique identifier for the order.
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// Gets or sets the basket associated with the order.
        /// </summary>
        public DTOBasket Basket { get; set; }

        /// <summary>
        /// Gets or sets the user who placed the order.
        /// </summary>
        public DTOUser User { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the order was placed.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the total amount for the order.
        /// </summary>
        public Decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the status of the order (e.g., Pending, Completed, Cancelled).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the shipping address for the order.
        /// </summary>
        public string ShoppingAddress { get; set; }
    }
}
