using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTriviaApp.Models;


public partial class Status
{
    
    public int StatusId { get; set; }

    public string Status1 { get; set; } = null!;

  
    public virtual ICollection<Question> Questions { get; } = new List<Question>();
    public int GetStatusId(int StatusId) { return StatusId; }
}
