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
        public string UserName { get { return username; } set { username = value;OnPropertyChanged(); ((Command)CheckUsername).ChangeCanExecute(); } }

        public ICommand CheckUsername {  get; set; }
    }
}
