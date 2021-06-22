using SalonWeb.Data;
using SalonWeb.DataAccessLayer;
using System;


namespace SalonWeb.BusinessLayer
{
    public class UserService : IUserService
    {
        public IUnitOfWork unitOfWork;

        public UserService(ApplicationDbContext dbcontext)
        {
            this.unitOfWork = new UnitOfWork(dbcontext);
        }

        public void Login(String username, String password) {}

        public void Logout() { }
    }
}
