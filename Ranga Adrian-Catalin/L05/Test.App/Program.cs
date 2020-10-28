﻿using LanguageExt;
using LanguageExt.Common;
using Profile.Domain.CreateProfileWorkflow;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using static Profile.Domain.CreateProfileWorkflow.CreateProfileResult;
using static Profile.Domain.CreateProfileWorkflow.EmailAddress;
using static Question.Domain.Question;
using Question.Domain.CreateQuestionWorkflow;

namespace Test.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var emailResult = UnverifiedEmail.Create("exemplu@2.com");
            var questionResult = UnverifiedQuestion.Create("How to create an array of objects in C++?", "I am trying to create an array of objects of my class in c++. When I print the objects, it skips the first element of array (a[0]). I have read many forums, but I can't find the problem. Who can see it?.","c++");


            emailResult.Match(
                    Succ: email =>
                    {
                        SendResetPasswordLink(email);

                        Console.WriteLine("Email address is valid.");
                        return Unit.Default;
                    },
                    Fail: ex =>
                    {
                        Console.WriteLine($"Invalid email address. Reason: {ex.Message}");
                        return Unit.Default;
                    }
                );
            emailResult.Match(
                    Succ: question =>
                    {
                        SendResetPasswordLink(question);

                        Console.WriteLine("Question is valid.");
                        return Unit.Default;
                    },
                    Fail: ex =>
                    {
                        Console.WriteLine($"Invalid question. Reason: {ex.Message}");
                        return Unit.Default;
                    }
                );


            Console.ReadLine();
        }

        private static void SendResetPasswordLink(UnverifiedEmail email)
        {
            var verifiedEmailResult = new VerifyEmailService().VerifyEmail(email);
            verifiedEmailResult.Match(
                    verifiedEmail =>
                    {
                        new RestPasswordService().SendRestPasswordLink(verifiedEmail).Wait();
                        return Unit.Default;
                    },
                    ex =>
                    {
                        Console.WriteLine("Email address could not be verified");
                        return Unit.Default;
                    }
                );
        }


        private static void EnableVoteQuestion(UnverifiedQuestion question)
        {
            var verifiedQuestionResult = new VerifyQuestionService().VerifyQuestion(question);
            verifiedQuestionResult.Match(
                    EnableVoteQuestion =>
                    {
                        new VerifyVotesService().Vote(EnableVoteQuestion).Wait();
                        return Unit.Default;
                    },
                    ex =>
                    {
                        Console.WriteLine("This question can't be voted");
                        return Unit.Default;
                    }
                );
        }

    }
}