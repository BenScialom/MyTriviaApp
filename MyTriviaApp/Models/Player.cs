using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyTriviaApp.Models;

public partial class Player
{
   public int PlayerId { get; set; }

  
    public string Mail { get; set; } = null!;

    
    public string Name { get; set; } = null!;

    public int RankId { get; set; }

    public int Points { get; set; }

   
    public string Password { get; set; } = null!;

    
    public virtual ICollection<Question> Questions { get; } = new List<Question>();

   
    public virtual Rank Rank { get; set; } = null!;
    public int GetPlayerId(int PlayerId) { return PlayerId; }
}
