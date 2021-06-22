using System;


namespace SalonWeb.BusinessLayer
{
    public interface IUserService
    {
        void Login(String username, String password);
        void Logout();
    }
}
