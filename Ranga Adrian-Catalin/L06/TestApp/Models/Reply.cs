using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices;
using LanguageExt.Common;
using System.Runtime.Serialization;


namespace TestApp.Models
{
    public class Question
    {
        public string Title { get; }
        public string Body { get; }
        public string[] Tags { get; }

        public Question(string title, string body, string[] tags)
        {
            Title = title;
            Body = body;
            Tags = tags;
        }
    }
    public class Reply
    {
        public int ReplyId { get; }
        public int QuestionId { get; }
        public int AuthorId { get; }
        public string Answer { get; }

        public Reply(int replyId, int questionId, int authorId, string answer)
        {
            ReplyId = replyId;
            QuestionId = questionId;
            AuthorId = authorId;
            Answer = answer;
        }
        public static Result<Reply> Create(int replyId, int questionId, int authorId, string answer)
        {
            if(answer.Length>9 && answer.Length<501)
            {
                return new Reply(replyId,questionId,authorId,answer);

            }
            else
            {
                return new Result<Reply>(new InvalidReplay(answer));
            }
        }
    }
}
