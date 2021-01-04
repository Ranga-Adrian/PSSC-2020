using System;
using System.Collections.Generic;
using System.Text;
using Access.Primitives.IO;
using LanguageExt;
using StackUnderflow.Domain.Schema.Backoffice.CreateTenantOp;
using StackUnderflow.Domain.Schema.Backoffice.InviteTenantAdminOp;
using static PortExt;
using static StackUnderflow.Domain.Schema.Backoffice.CreateQuestionOp.CreateQuestionResult;


namespace StackUnderflow.Domain.Core.Contexts.Question
{
    public static  class QuestionDomain
    {

        public static Port<ICreateQuestionResult> CreateQuestion(CreateQuestionCmd command)
        {
            return NewPort<CreateQuestionCmd, ICreateQuestionResult>(command);
        }



    }
}
