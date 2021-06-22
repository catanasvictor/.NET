using System;

namespace SalonWeb.DomainModel
{
    public class User
    {
        private String name;
        private String username;
        private String password;

        public User(String name,String username, String password)
        {
            this.name = name;
            this.username = username;
            this.password = password;
        }

        public String GetName()
        {
            return this.name;
        }
        public void SetName(String name)
        {
            this.name = name;
        }
       
        public string GetUsername()
        {
            return this.username;
        }
        public void SetUsername(String username)
        {
            this.username = username;
        }

        public string GetPassword()
        {
            return this.password;
        }
        public void SetPassword(String password)
        {
            this.password = password;
        }

    }
}
