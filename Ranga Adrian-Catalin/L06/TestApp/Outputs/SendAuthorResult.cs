using System;
using System.Collections.Generic;
using System.Text;

namespace Tema6_18.Outputs
{
    public static partial class SendAuthorResult
    {
        public interface ISendAuthorResult { }
        public class Replay : ISendAuthorResult
        {
            public string text { get; private set; }
            public Replay(string text)
            {
                this.text = text;

            }
        }
        public class InvalidReplay : ISendAuthorResult
        {
            public string error { get; private set; }
            public InvalidReplay(string error)
            {
                this.error = error;
            }
        }
    }
}
