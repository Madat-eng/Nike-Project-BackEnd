using DAL;
using DAL.DTOs;
using System;
using System.Collections.Generic;

namespace BAL
{
    public class BasketBusiness
    {
        public static DTOBasket GetBasketByID(int basketID)
        {
            try
            {
                var basket = BasketData.GetBasketByID(basketID);
                if (basket == null)
                    throw new Exception($"Basket with ID {basketID} not found.");
                return basket;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Service error while fetching basket.", ex);
            }
        }

        public static List<DTOBasket> GetAllBaskets()
        {
            try
            {
                return BasketData.GetAllBaskets();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Service error while fetching baskets.", ex);
            }
        }

        public static (bool success, int basketID) CreateBasket(DTOBasket_CreatBasket basket)
        {
            try
            {
                return BasketData.CreateBasket(basket);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Service error while creating basket.", ex);
            }
        }

        public static bool UpdateBasket(DTOBasket basket)
        {
            try
            {
                return BasketData.UpdateBasket(basket);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Service error while updating basket.", ex);
            }
        }

        public static bool DeleteBasket(int basketID)
        {
            try
            {
                return BasketData.DeleteBasket(basketID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Service error while deleting basket.", ex);
            }
        }

        public static List<DTOBasketItemDetails> GetBasketItems(int userID)
        {
            try
            {
                return BasketData.GetBasketItems(userID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Service error while fetching basket items for user {userID}.", ex);
            }
        }
    }
}
