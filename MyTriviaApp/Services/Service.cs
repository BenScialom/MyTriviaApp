﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTriviaApp.Models;


namespace MyTriviaApp.Services
{
    public class Service
    {
       public List<Player> players ;
       public List<Question> questions ;
       public List<Rank> ranks;
       public List<Status> statuses ;
       public List<Subject> subjects ;
       
        public Service()
        {
           this.players=new List<Player>();
            this.questions = new List<Question>();
           
            this.ranks = new List<Rank>();
            this.statuses = new List<Status>();
            this.subjects = new List<Subject>();
            FillRank();
            FillSubject();
            FillStatus();
            FillPlayers();
            FillQuestions();
            

        }

        private void FillQuestions()
        {
            questions.Add(new Question() { QuestionId = 1, StatusId = statuses[1].GetStatusId(1),SubjectId = subjects[0].GetSubjectsId(0), PlayerId = players[0].GetPlayerId(0),Question1="Who won the UEFA champions league last season?",RightA="Munchester City",WrongA1="Real Madrid",WrongA2="Liverpool",WrongA3="Ac Milan", Player = players[0], Status = statuses[1], Subject = subjects[0] });
            questions.Add(new Question() { QuestionId = 2, StatusId = statuses[0].GetStatusId(0), SubjectId = subjects[1].GetSubjectsId(1), PlayerId = players[0].GetPlayerId(0), Question1 = "When was WW2 ended?", RightA = "1945", WrongA1 = "1333", WrongA2 = "1947", WrongA3 = "1939", Player = players[0], Status = statuses[0], Subject = subjects[1] });
            questions.Add(new Question() { QuestionId = 3, StatusId = statuses[1].GetStatusId(1), SubjectId = subjects[2].GetSubjectsId(2), PlayerId = players[0].GetPlayerId(0), Question1 = "Who is the president of the USA", RightA = "Joe Biden", WrongA1 = "Hilery Clinton", WrongA2 = "Donald Trump", WrongA3 = "Barak Obama", Player = players[0], Status = statuses[1], Subject = subjects[2] });
        }

        private void FillRank()
        {
            ranks.Add(new Rank() {RankId=0,RankName="Admin"});
            ranks.Add(new Rank() { RankId = 0, RankName = "Master" });
            ranks.Add(new Rank() { RankId = 0, RankName = "Rookie" });
        }
        private void FillSubject()
        {
            subjects.Add(new Subject() { SubjectId = 0, SubjectName = "Sport" });
            subjects.Add(new Subject() { SubjectId = 1, SubjectName = "History" });
            subjects.Add(new Subject() { SubjectId = 2, SubjectName = "Politics" });
        }
        private void FillStatus()
        {
            statuses.Add(new Status() { StatusId = 0, Status1 = "Approved" });
            statuses.Add(new Status() { StatusId = 1, Status1 = "Waiting" });
            statuses.Add(new Status() { StatusId = 2, Status1 = "Rejected" });
        }
        private void FillPlayers()
        {
            players.Add(new Player { PlayerId = 1, Mail = "Ben.Sha@gmail.com", Name = "Ben", RankId = ranks[0].GetRankId(0), Points = 0, Password = "123", Rank = ranks[0] });
            players.Add(new Player { PlayerId = 2, Mail = "itamar@gmail.com", Name = "Itamar", RankId = ranks[0].GetRankId(0), Points = 100, Password = "123", Rank = ranks[0] });
            players.Add(new Player { PlayerId = 3, Mail = "ran@gmail.com", Name = "Ran", RankId = ranks[1].GetRankId(1), Points = 15, Password = "123", Rank = ranks[1] });
        }

      
        public bool Login(string user, string pass)
        {

          return  players.Any((x) => x.Name == user && x.Password == pass);
            //for(int i=0;i<user.Count();i++)
            //{
            //    User x= players[i];
            //    if (x.UserName == user && x.Password==pass)
            //        return true;
            //}
            //return false;
        }
        public async Task<List<Question>> GetQuestion()
        {
            await Task.Delay(1000);
            return questions.ToList();
        }
        public List<Question> GetPendingQuestion()
        {
            return questions.Where(x=>x.Status.StatusId==1).ToList();   
        }
        public void ApproveQuestion(Question q)
        {
            q.Status=statuses.Where(x=>x.StatusId==2).FirstOrDefault();
        }
        public void DeclineQuestion(Question q)
        {
            q.Status=statuses.Where(x=>x.StatusId==3).FirstOrDefault();
        }
        public async Task<List<Player>> GetPlayersDeccending()
        {
            await Task.Delay(1000);
            return players.OrderByDescending(x => x.Points).ToList();
        }
        public async Task<List<Player>> GetPlayersAccending()
        {
            await Task.Delay(1000);
            return players.OrderBy(x => x.Points).ToList();
        }
        public async Task<List<Player>> GetPlayers()
        {
            await Task.Delay(1000);
            return players.ToList();
        }
        public async Task RemovePlayer(Player player)
        {
            await Task.Delay(2000);
            var p = players.Where(x => x.Name == player.Name).FirstOrDefault();
            if (p != null)
            {
                players.Remove(p);
            }
        }

        public void UpdatePlayer(Player player)
        {
            var p = players.Where(x => x.Mail == player.Mail).FirstOrDefault();
            p.Points = player.Points;
        }
        public async Task ResetPlayerPoints(Player p)
        {
            await Task.Delay(1000);
            foreach (Player player in players)
            {
                if (player == p)
                {
                    player.Points = 0;
                }
            }
        }
        public void AddPlayer(Player newPlayer)
        {
            players.Add(newPlayer);
        }
        public List<Player> GetPlayers1()
        {
            return players;
        }
        public List<Rank> GetRanks()
        {
            return ranks;
        }
    }
}
