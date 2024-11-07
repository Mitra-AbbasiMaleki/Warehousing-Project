using BaseBackend.Entities.Interfaces;
using BaseBackend.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseBackend.Entities
{
    public class UserLogin : IBaseEntity
    {
        private static int nextid = 1;
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }

        public UserLogin()
        {
            Id = nextid++;
        }
        public UserLogin(string username,string password,UserRole userRole)
        {
            UserName = username;
            Password = password;
            UserRole = userRole;
        }
    }
}
