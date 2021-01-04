using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using Microsoft.AspNetCore.Mvc;
using StackUnderflow.Domain.Core;
using StackUnderflow.Domain.Core.Contexts;
using StackUnderflow.Domain.Schema.Backoffice.CreateTenantOp;
using StackUnderflow.EF.Models;
using Access.Primitives.EFCore;
using StackUnderflow.Domain.Schema.Backoffice.InviteTenantAdminOp;
using StackUnderflow.Domain.Schema.Backoffice;
using LanguageExt;
using StackUnderflow.EF;
using Microsoft.EntityFrameworkCore;
using Orleans;
using StackUnderflow.DatabaseModel.Models;
using StackUnderflow.Domain.Core.Contexts.Question;


namespace StackUnderflow.API.AspNetCore.Controllers
{
    [ApiController]
    [Route("Question")]
    
    public class QuestionController : ControllerBase
    {
        private readonly IInterpreterAsync _interpreter;
        private readonly StackUnderflowContext _dbContext;
      
        public QuestionController(IInterpreterAsync interpreter, StackUnderflowContext dbContext)
        {
            _interpreter = interpreter;
            _dbContext = dbContext;
           
        }
        [HttpPost("CreateQuestion")]
        public async Task<string> CreateQuestion1([FromBody] CreateQuestionCmd question)
        {
           
            QuestionContext ctx = new QuestionContext(
                  new EFList<Question>(_dbContext.Question));
            var dep = new QuestionDepend();
            var exp = from createQuestionResult in QuestionDomain.CreateQuestion(question)
                      select  new { createQuestionResult };


             var r = await _interpreter.Interpret(exp, ctx, dep);
          
           
            _dbContext.SaveChanges();

            return "adaugat";
        }
    }
}