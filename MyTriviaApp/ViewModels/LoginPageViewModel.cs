using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyTriviaApp.Services;

namespace MyTriviaApp.ViewModels
{
    public class LoginPageViewModel : ViewModel
    {

        private string username;
        private string password;
        public string UserName { get { return username; } set { username = value; OnPropertyChanged(); ((Command)LoginCommand).ChangeCanExecute(); } }
        public string Password { get { return password; } set { password = value; OnPropertyChanged(); ((Command)LoginCommand).ChangeCanExecute(); } }
        public ICommand LoginCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        private Service service;

        public LoginPageViewModel(Service service)
        {
            LoginCommand = new Command(Login, () => { return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password); });
            this.service = service;
        }

        private void Login()
        {

            bool result = service.Login(UserName, Password);

        }
    }
}