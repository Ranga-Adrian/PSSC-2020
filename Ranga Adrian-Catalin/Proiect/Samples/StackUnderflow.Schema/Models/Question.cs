using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StackUnderflow.DatabaseModel.Models
{
    [Table("Question")]
    public partial class Question
    {
        public int QuestionID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string QuestionTag { get; set; }
        public Question() { }
        public Question(int questionID, string title, string description, string questionTag)
        {
            QuestionID = questionID;
            Title = title;
            Description = description;
            QuestionTag = questionTag;
        }
    }
}
