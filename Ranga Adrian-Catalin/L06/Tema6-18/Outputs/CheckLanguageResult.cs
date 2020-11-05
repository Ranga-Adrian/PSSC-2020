using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices;

namespace Tema6_18.Outputs
{
    [AsChoice]
    public static partial class CheckLanguageResult
    {
        public interface ICheckLanguageResult { }

        public class TextChecked
        {
            public int Certainty { get; }

            public TextChecked(int certainty)
            {
                Certainty = certainty;
            }
        }

        public class CheckFailed
        {
            public string ErrorMessage { get; }

            public CheckFailed(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
        }
    }
}
