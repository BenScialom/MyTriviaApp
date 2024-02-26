using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyTriviaApp.Models;

[Table("Subject")]
public partial class Subject
{
    [Key]
    public int SubjectId { get; set; }

    [StringLength(100)]
    public string SubjectName { get; set; } = null!;

    [InverseProperty("Subject")]
    public virtual ICollection<Question> Questions { get; } = new List<Question>();
}
