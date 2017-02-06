using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServices;
using IServices.SubIntefac;
using DataModel;
using Services.Models;

namespace Services
{
    class RegisterServices : IRegisterServices
    {
    public    void Register(string userName, string password)
        {
            string HashPw = Security.instance.GetHashString(password);
            string salt = Security.instance.getSalt();
            using (var db = new DataContext())
            {
                User user = new User()
            {
                   UserName = userName,
                  Password = salt + HashPw,
                 Salt = salt
                     };
                         db.Users.Add(user);
                         db.SaveChanges();
            }
        }
    }
}
