using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyTriviaApp.Models;

public partial class Rank
{
    [Key]
    public int RankId { get; set; }
    public int GetRankId(int id) {  return RankId; }
    public void SetRankId() { this.RankId = RankId; }

    [StringLength(150)]
    public string RankName { get; set; } = null!;

    [InverseProperty("Rank")]
    public virtual ICollection<Player> Players { get; } = new List<Player>();
}
