using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    public class DTOBasketItemDetails
    {
        public DTOBasketItemDetails(int basketItemID, int basketID, int productID, string productName, int quantity, decimal price, decimal totalPrice,string imageURL)
        {
            BasketItemID = basketItemID;
            BasketID = basketID;
            ProductID = productID;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            TotalPrice = totalPrice;
            ImageURL = imageURL;


        }

        public int BasketItemID     { get; set; }
        public int BasketID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public string ImageURL { get; set; }
    }
}
