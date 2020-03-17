namespace Vrlife.Core
{
    public abstract class Command
    {
        public float Lifetime { get; set; }

        public bool IsComplete { get; set; }
    }
}