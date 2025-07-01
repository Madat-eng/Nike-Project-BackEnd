using DAL;
using DAL.DTOs;
using System;
using System.Collections.Generic;

namespace BAL
{
    public class BasketItemsBusiness
    {
        public static DTOBasketItems GetBasketItemByID(int basketItemID)
        {
            try
            {
                var item = BasketItemsData.GetBasketItemByID(basketItemID);
                if (item == null)
                    throw new Exception($"Basket item with ID {basketItemID} not found.");
                return item;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Service error while fetching basket item.", ex);
            }
        }

        public static List<DTOBasketItems> GetAllBasketItems()
        {
            try
            {
                return BasketItemsData.GetAllBasketItems();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Service error while fetching basket items.", ex);
            }
        }

        public static (bool success, int basketItemID) CreateBasketItem(DTOBasketItems_Create item)
        {
            try
            {
                return BasketItemsData.CreateBasketItem(item);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Service error while creating basket item.", ex);
            }
        }

        public static bool UpdateBasketItem(DTOBasketItems_Update item)
        {
            try
            {
                return BasketItemsData.UpdateBasketItem(item);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Service error while updating basket item.", ex);
            }
        }

        public static bool DeleteBasketItem(int basketItemID)
        {
            try
            {
                return BasketItemsData.DeleteBasketItem(basketItemID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Service error while deleting basket item.", ex);
            }
        }

        public static void AddItemToTheBasket(DTOBasketItems_Add item)
        {
            try
            {
                BasketItemsData.AddItemToTheBasket(item);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Service error while adding item to the basket.", ex);
            }
        }
    }
}
