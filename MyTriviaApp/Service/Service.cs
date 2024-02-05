using MyTriviaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyTriviaApp.Service
{
    public class Service
    {
       List<User> users = new List<User>();
        public Service()
        {
           this.users=new List<User>();
            FillList();
        }

        private void FillList()
        {
            users.Add(new User());
            users.Add(new User { Password = "1234", UserName = "Ben" });
        }
       private bool CheckUsername(string username)
        {
            for(int i = 0;i< users.Count; i++)
            {
                if (users[i].UserName == username)
                {
                    return true;
                }
            }
            return false;
        }
        private bool CheckPassword(string password)
        {
            for(int i = 0;i< users.Count; i++)
            {
                if (users[i].Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckLogin(User user)
        {
            return (CheckUsername(user.UserName)&&CheckPassword(user.Password));
        }

    }
}
