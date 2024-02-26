using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTriviaApp.Models;

[Table("Status")]
public partial class Status
{
    [Key]
    public int StatusId { get; set; }

    [Column("Status")]
    [StringLength(200)]
    public string Status1 { get; set; } = null!;

    [InverseProperty("Status")]
    public virtual ICollection<Question> Questions { get; } = new List<Question>();
}
