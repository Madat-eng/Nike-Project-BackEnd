using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    public class DTOBasketItems_Add
    {
        public DTOBasketItems_Add(int userID, int productID, int quantity)
        {
            UserID = userID;
            ProductID = productID;
            Quantity = quantity;
        }

        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
