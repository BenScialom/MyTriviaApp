using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyTriviaApp.ViewModels
{
    internal class LoginPageViewModel:ViewModel
    {
       private string username;
        private string password;
        public string UserName { get { return username; } set { username = value;OnPropertyChanged(); ((Command)CheckUsername).ChangeCanExecute(); } }
        public string Password { get { return password; } set { password = value;OnPropertyChanged();((Command)CheckPassword).ChangeCanExecute(); } }
        public ICommand CheckPassword {  get; set; }
        public ICommand CheckUsername {  get; set; }
        
    }
}
