using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyTriviaApp.ViewModels
{
    public class MenuPageViewModel:ViewModel
    {
        public ICommand GoToPage { get; private set; }
        public MenuPageViewModel() 
        {
            GoToPage = new Command<string>(async (x) => { await NavigateToPage(x); });
        }

        private async Task NavigateToPage(string x)
        {
           await AppShell.Current.GoToAsync(x);
        }
    }
}
