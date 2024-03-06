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
       
        public ObservableCollection<Question> questions { get; set; }
        public Subject SelectedSubject { get; set; }
        private int selectedIndex;
        public int SelectedIndex { get => selectedIndex; set { selectedIndex = value; OnPropertyChanged(); } }
       
        public ICommand ApproveQuestionComman { get; private set; }
      public ICommand DisallowCoomand {  get; private set; }
        public ICommand LoadQuestionsCommand { get; private set; }
        public ICommand FilterCommand { get; private set; }
    
        private List<Question> fullList;
        public ApproveQuestionsPageViewModel(Service s)
        {
            service = s;
            questions = new ObservableCollection<Question>();
            questions.Clear();
            
            questions=new ObservableCollection<Question>(service.GetPendingQuestion());
            LoadQuestionsCommand = new Command(async () => await ApproveQuestions());
        
           DisallowCoomand=new Command((object obj) => { Question qu = (Question)obj; questions.Remove(qu); fullList.Remove(qu); });

            FilterCommand = new Command(() =>
            {
                try
                {
                    var SelectedSubject = fullList.Where(x => x.Subject == SelectedSubject.ToList());
                    questions.Clear();
                    foreach (var question in SelectedSubject)
                    {
                        questions.Add(question);
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            });
        }

    
        private async Task ApproveQuestions()
        {
            //var list = await service.GetPendingQuestion();
            //questions.Clear();
            //foreach (var question in list)
            //{
            //    questions.Add(question);
            //}
            
            foreach(Question question in service.GetPendingQuestion())
            {
                questions.Add(question);
            }
        }
    }
}
