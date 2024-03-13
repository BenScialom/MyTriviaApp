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
        //private Question question;
        private bool isRefreshing;
        public bool IsRefreshing { get { return isRefreshing; } set { isRefreshing = value; OnPropertyChanged(); } }
        public ObservableCollection<Question> questions { get; set; }
        private Subject selectedsubject;
        public Subject SelectedSubject { get { return selectedsubject; } set { selectedsubject = value; OnPropertyChanged(); } }
        private int selectedIndex;
        public int SelectedIndex { get => selectedIndex; set { selectedIndex = value; OnPropertyChanged(); } }
       
        public ICommand ApproveQuestionCommand { get; private set; }
      public ICommand RejectCommand {  get; private set; }
        //public ICommand LoadQuestionsCommand { get; private set; }
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
            //FilterCommand = new Command(() =>
            //{
            //    try
            //    {
            //        var SelectedSubjectsQuestions = fullList.Where(x => x.Subject == (Subject)SelectedSubject).ToList();
            //        questions.Clear();
            //        foreach (var question in SelectedSubjectsQuestions)
            //        {
            //            questions.Add(question);
            //        }
            //    }
            //    catch (Exception ex) { Console.WriteLine(ex.Message); }
            //}, () => fullList != null && fullList.Count > 0);
        }

        private async Task FilterQuestions()
        {
            if (selectedsubject != null)
            {
                foreach (var question in fullList.Where(x => x.Status.StatusId == 3 && x.Subject.SubjectId == ((Subject)SelectedSubject).SubjectId).ToList()) ;
                questions.Clear();
            }
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
