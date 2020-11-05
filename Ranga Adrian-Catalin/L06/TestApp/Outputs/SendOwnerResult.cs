using System;
using System.Collections.Generic;
using System.Text;

namespace Tema6_18.Outputs
{
    public static partial class SendOwnerResult
    {
        public interface ISentOwnerResult { }
        public class Replay: ISentOwnerResult
        {
            public string text;
            public Replay(string text)
            {
                this.text = text;
            }
        }
        public class InvalidReplay:ISentOwnerResult
        {
            public string error { get; }
            public InvalidReplay(string error)
            {
                this.error = error;
            }
        }

    }
}
