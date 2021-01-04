using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Access.Primitives.IO;
using EarlyPay.Primitives.ValidationAttributes;

namespace StackUnderflow.Domain.Core.Contexts.Question
{
    public struct  CreateQuestionCmd
    {
       [Key]
        public int QuestionID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string QuestionTag { get; set; }
        public CreateQuestionCmd(int questionID, string title, string description, string questionTag)
        {
            QuestionID = questionID;
            Title = title;
            Description = description;
            QuestionTag = questionTag;
        }
    }
}
