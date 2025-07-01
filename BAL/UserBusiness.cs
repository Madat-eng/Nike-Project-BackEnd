using DAL;
using DAL.DTOs;
using Microsoft.Data.SqlClient;


namespace BAL
{
    public class UserBusiness
    {
        public static DTOUser GetUserById(int userId)
        {
            try
            {
                var user = UserData.GetUserByID(userId);
                if (user == null)
                    throw new Exception($"User with ID {userId} was not found.");

                return user;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Service error while fetching user by ID {userId}.", ex);
            }
        }

        public static (bool, int, int) CreateUser(DTOUser user)
        {
            try
            {
                return UserData.CreateUser(user);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Service error while creating user.", ex);
            }
        }

        public static bool UpdateUser(DTOUser user)
        {
            try
            {
                return UserData.UpdateUser(user);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Service error while updating user with ID {user.UserID}.", ex);
            }
        }

        public static bool DeleteUser(int userId)
        {
            try
            {
                return UserData.DeleteUser(userId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Service error while deleting user with ID {userId}.", ex);
            }
        }
        public static DTOUserCreated CreateUser(DTOUserSignUp user)
        {
            try
            {
                return UserData.CreateUser(user);
            }
            catch (SqlException ex) when (ex.Message.Contains("البريد الإلكتروني مستخدم"))
            {
                throw new ApplicationException("The email is already in use.");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Service error while creating user.", ex);
            }
        }


        public static DTOUserLoginResult Login(DTOUserLogin user)
        {
            try
            {
                return UserData.Login(user);
            }
            catch (SqlException ex) when (ex.Message.Contains("البريد الإلكتروني أو كلمة المرور غير صحيحة"))
            {
                throw new ApplicationException("Invalid email or password.");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Service error while logging in.", ex);
            }
        }
    }
}
