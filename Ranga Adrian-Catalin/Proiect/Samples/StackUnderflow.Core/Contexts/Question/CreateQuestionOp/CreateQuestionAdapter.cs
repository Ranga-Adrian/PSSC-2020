using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Access.Primitives.IO;
using LanguageExt;
using StackUnderflow.Domain.Schema.Backoffice.CreateTenantOp;
using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO.Attributes;
using Access.Primitives.IO.Mocking;
using StackUnderflow.Domain.Core.Contexts;
using StackUnderflow.EF.Models;
using StackUnderflow.Domain.Schema.Backoffice;
using StackUnderflow.Domain.Core.Contexts.Question;
using static StackUnderflow.Domain.Schema.Backoffice.CreateQuestionOp.CreateQuestionResult;
using StackUnderflow.DatabaseModel.Models;
using StackUnderflow.Domain.Schema.Backoffice.CreateQuestionOp;

namespace StackUnderflow.Backoffice.Adapters.CreateTenant
{
    public partial class CreateQuestionAdapter : Adapter<CreateQuestionCmd, ICreateQuestionResult, QuestionContext, QuestionDepend>
    {
        private readonly IExecutionContext _ex;

        public CreateQuestionAdapter(IExecutionContext ex)
        {
            _ex = ex;
        }

        public override async Task<ICreateQuestionResult> Work(CreateQuestionCmd command, QuestionContext state, QuestionDepend dependencies)
        {
            var workflow = from valid in command.TryValidate()
                           let t = AddQuestionIfMissing(state, CreateQuestionFromCommand(command))
                           select t;


            var result = await workflow.Match(
                Succ: r => r,
                Fail: ex => new InvalidRequest(ex.ToString()));

            return result;
        }

        public ICreateQuestionResult AddQuestionIfMissing(QuestionContext state, Question tenant)
        {
           // if (state.Questions.Any(p => p.Name.Equals(tenant.Name)))
             //   return new QuestionNotCreated();

            if (state.Questions.All(p => p.QuestionID != tenant.QuestionID))
                state.Questions.Add(tenant);
            return new QuestionCreated(tenant);
        }

        private Question CreateQuestionFromCommand(CreateQuestionCmd cmd)
        {
            var question = new Question()
            {
                QuestionID = cmd.QuestionID,
                Title = cmd.Title,
                Description = cmd.Description,
                QuestionTag = cmd.QuestionTag
                
                
            };
           
            return question;
        }

        public override Task PostConditions(CreateQuestionCmd op, CreateQuestionResult.ICreateQuestionResult result, QuestionContext state)
        {
            return Task.CompletedTask;
        }
    }
}
