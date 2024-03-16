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
        //Ben
    private Service service;
        
        private bool isRefreshing;
        public bool IsRefreshing { get { return isRefreshing; } set { isRefreshing = value; OnPropertyChanged(); } }
        public ObservableCollection<Question> questions { get; set; }
        
        private Subject selectedsubject;
        public Subject SelectedSubject { get { return selectedsubject; } set { selectedsubject = value; OnPropertyChanged(); } }
        private int selectedIndex;
        public int SelectedIndex { get => selectedIndex; set { selectedIndex = value; OnPropertyChanged(); } }
       
        public ICommand ApproveQuestionCommand { get; private set; }
      public ICommand RejectCommand {  get; private set; }
        
        public ICommand FilterCommand { get; private set; }
      public ICommand RefreashCommand { get; private set; } 
        private List<Question> fullList;
        public List<Subject> subjects { get; set; }
        public ApproveQuestionsPageViewModel(Service s)
        {
            service = s;
            questions = new ObservableCollection<Question>();
            questions.Clear();
            fullList=new List<Question>();
            subjects = new List<Subject>(service.subjects);
            questions=new ObservableCollection<Question>(service.GetPendingQuestion());
            ApproveQuestionCommand = new Command(async () => await ApproveQuestions());
            RefreashCommand = new Command(async (object obj) => Refresh());
           RejectCommand=new Command((object obj) => { Question qu = (Question)obj; questions.Remove(qu); fullList.Remove(qu); });
            FilterCommand = new Command(async () => await FilterQuestions());
          
        }

        private async Task FilterQuestions()
        {
            if (selectedsubject != null)
            {
                var filteredQuestions = fullList.Where(x => x.Status.StatusId == 3 && x.Subject.SubjectId == SelectedSubject.SubjectId).ToList();
                questions.Clear();
                foreach (var question in filteredQuestions)
                {
                    questions.Add(question);
                }
            }
        }
        private async Task ApproveQuestions()
        {
            
            
            foreach(Question question in service.GetPendingQuestion())
            {
                questions.Add(question);
                service.ApproveQuestion(question);
                Refresh();
            }
        }
        private async void DeclineQuestion(object obj)
        {
            service.DeclineQuestion(((Question)obj));
            Refresh();
        }

        private async void Refresh()
        {
           IsRefreshing = true;
            SelectedSubject = null;
            questions=new ObservableCollection<Question>(service.GetPendingQuestion());
        }
    }
}
