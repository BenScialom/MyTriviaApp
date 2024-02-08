using MyTriviaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyTriviaApp.Services
{
    public class Service
    {
       List<User> users ;
        public Service()
        {
           this.users=new List<User>();
            FillList();
        }

        private void FillList()
        {
            users.Add(new User { Password = "1234", UserName = "Ben" });
        }
       
        public bool Login(string user, string pass)
        {

          return  users.Any((x) => x.UserName == user && x.Password == pass);
            //for(int i=0;i<user.Count();i++)
            //{
            //    User x= users[i];
            //    if (x.UserName == user && x.Password==pass)
            //        return true;
            //}
            //return false;
        }

    }
}
