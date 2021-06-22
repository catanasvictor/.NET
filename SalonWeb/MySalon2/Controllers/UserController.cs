using System;
using SalonWeb.BusinessLayer;


namespace SalonWeb.WebApplication
{
    public class UserController
    {

        private IUserService userService;

        public UserController(UserService appointmentService)
        {
            this.userService = appointmentService;
        }

        public void Login(String username, String password)
        {
            userService.Login(username, password);
        }

        public void Logout()
        {
            userService.Logout();
        }

    }
}
