using DAL;
using DAL.DTOs;


namespace BAL
{
    public class UserBusiness
    {
        public static DTOUser GetUserByID(int userID)
        {
            return UserData.GetUserByID(userID);
        }
      

    }
}
