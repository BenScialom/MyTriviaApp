using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyTriviaApp.Models;

public partial class Question
{
    [Key]
    public int QuestionId { get; set; }

    public int StatusId { get; set; }

    public int SubjectId { get; set; }

    public int PlayerId { get; set; }

    [Column("Question")]
    [StringLength(1000)]
    public string Question1 { get; set; } = null!;

    [StringLength(300)]
    public string RightA { get; set; } = null!;

    [StringLength(300)]
    public string WrongA1 { get; set; } = null!;

    [StringLength(300)]
    public string WrongA2 { get; set; } = null!;

    [StringLength(300)]
    public string WrongA3 { get; set; } = null!;

    [ForeignKey("PlayerId")]
    [InverseProperty("Questions")]
    public virtual Player Player { get; set; } = null!;

    [ForeignKey("StatusId")]
    [InverseProperty("Questions")]
    public virtual Status Status { get; set; } = null!;

    [ForeignKey("SubjectId")]
    [InverseProperty("Questions")]
    public virtual Subject Subject { get; set; } = null!;
}
