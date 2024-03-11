using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyTriviaApp.Models;


public partial class Subject
{
  
    public int SubjectId { get; set; }

   
    public string SubjectName { get; set; } = null!;

   
    public virtual ICollection<Question> Questions { get; } = new List<Question>();
    public int GetSubjectsId(int SubjectId) { return SubjectId; }
}
