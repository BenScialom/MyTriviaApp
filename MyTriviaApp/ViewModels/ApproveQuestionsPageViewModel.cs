using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTriviaApp.Models;
using MyTriviaApp.Services;

namespace MyTriviaApp.ViewModels
{
        [QueryProperty(nameof(Question),"question")]
    public class ApproveQuestionsPageViewModel:ViewModel
    {
        private Question question;
        public Question Question { get=> question; set { question = value; OnPropertyChanged(); } }
    }
}
