using System;
using Tema6_18.Inputs;
using Tema6_18.Outputs;
namespace Tema6_18
{
    class Program
    {
        static void Main(string[] args)
        {
            var wf = from createReplyResult in Domain.ValidateReply(1, 1, "test")
                     let validReply = (CreateReplyResult.ReplyValid)createReplyResult
                     from checkLanguageResult in Domain.CheckLanguage(validReply.Reply.Answer)
                     from ownerAck in Domain.SendOwner(1, 1, "test")
                     from authorAck in Domain.SendAuthor(1, 1, "test")
                     select (validReply, checkLanguageResult, ownerAck, authorAck);

        }

    }
}
