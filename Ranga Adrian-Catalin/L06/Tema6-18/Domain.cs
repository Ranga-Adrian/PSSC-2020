using System;
using System.Collections.Generic;
using System.Text;
using Tema6_18.Inputs;
using Tema6_18.Outputs;
using static PortExt;
using Access.Primitives.IO;

namespace Tema6_18
{
    public static class BoundedContext
    {
        public static Port<ValidateReplyResult.IValidateReplyResult> ValidateReply(int authorId, int questionId,
            string answer)
            => NewPort<ValidateReplyCmd, ValidateReplyResult.IValidateReplyResult>(
                new ValidateReplyCmd(authorId, questionId, answer));

        public static Port<CheckLanguageResult.ICheckLanguageResult> CheckLanguage(string text)
            => NewPort<CheckLanguageCmd, CheckLanguageResult.ICheckLanguageResult>(new CheckLanguageCmd(text));

        public static Port<SendAuthorResult.ISendAuthorResult> SendAuthor(int RId, int QId, string ans)
           => NewPort<SendAuthorCmd, SendAuthorResult.SendAuthorResult>(
               new SendAuthorCmd(RId,QId,ans));

        public static Port<SendOwnerResult.ISendOwnerResult> SendOwner(int RId, int QId, string ans)
            => NewPort<SendOwnerCmd, SendOwnerResult.SendOwnerResult>(new SendOwnerCmd(RId,QId,ans));

    }
}
