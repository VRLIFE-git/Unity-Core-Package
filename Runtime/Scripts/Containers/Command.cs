using System;

namespace Vrlife.Core
{
    [Serializable]
    public abstract class Command
    {
        public float Lifetime { get; set; }

        public bool IsComplete { get; set; }

        public Action Completed { get; set; }
    }
}