using System;

namespace Vrlife.Core
{
    [Serializable]
    public class SpeechCommand : Command
    {
        public string Text { get; set; }
    }
}