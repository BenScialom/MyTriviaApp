using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyTriviaApp.Models;
using MyTriviaApp.Services;

namespace MyTriviaApp.ViewModels
{
        [QueryProperty(nameof(Question),"question")]
    public class ApproveQuestionsPageViewModel:ViewModel
    {
    private Service service;
        private Question question;
        public Question Question { get=> question; set { question = value; ((Command)SelectQuestionCommand).ChangeCanExecute(); } }
        public ObservableCollection<Question> questions { get; set; }
        public Subject SelectedSubject { get; set; }
        private int selectedIndex;
        public int SelectedIndex { get => selectedIndex; set { selectedIndex = value; OnPropertyChanged(); } }
        public ICommand SelectQuestionCommand { get; private set; }
        public ICommand ApproveQuestionComman { get; private set; }
        public ICommand DisallowQuestionCommand { get; private set; }
        public ICommand LoadQuestionsCommand { get; private set; }
        public ICommand FilterCommand { get; private set; }
        private List<Question> fullList;
        public ApproveQuestionsPageViewModel(Service s)
        {
            service = s;
            questions = new ObservableCollection<Question>();
            questions.Clear();
            

            LoadQuestionsCommand = new Command(async () => await LoadQuestions());
            DisallowQuestionCommand = new Command(ClearQuestions, () => questions.Count > 0);

            FilterCommand=new Command(() =>
            {
                try
                {
                    var SelectedSubject = fullList.Where(x => x.Subject == (SelectedSubject).ToList() );
                }
            }
        }

        private void ClearQuestions()
        {
           questions.Clear();
            ((Command)DisallowQuestionCommand).ChangeCanExecute();
        }

        private async Task LoadQuestions()
        {
            var list = await service.GetQuestion();
            questions.Clear();
            foreach (var question in list)
            {
                questions.Add(question);
            }
        }
    }
}
