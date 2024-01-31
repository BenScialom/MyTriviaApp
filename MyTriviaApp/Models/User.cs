using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTriviaApp.Models
{
    public class User
    {
        private string username;
        private string password;
        public string UserName { get { return username; } set { password = value; } }
        public string Password { get { return password; } set { password = value; } }
       
    }
}
