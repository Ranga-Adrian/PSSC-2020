using StackUnderflow.DatabaseModel.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace StackUnderflow.DatabaseModel.Models
{
    public class QuestionContext
    {
        public ICollection<Question> Questions { get; }

        public QuestionContext(ICollection<Question> question)
        {
            Questions = question ?? new List<Question>(0);
        }
        public QuestionContext() { }
      


    }
}
