using System.Collections.Generic;
using System.Linq;

namespace Vrlife.Core
{
    public class ParallelCommandBuffer : ICommandBuffer
    {
        private List<Command> _commands;

        private bool _disposed = false;

        public IReadOnlyCollection<Command> Commands => _commands;

        public ParallelCommandBuffer(IEnumerable<Command> commands)
        {
            _commands = new List<Command>(commands);
        }

        public bool IsCompleted { get; private set; }

        public void RefreshBuffer(float deltaTime)
        {
            if (IsCompleted) return;

            var completed = true;

            foreach (var command in _commands)
            {
                if (!command.IsComplete)
                    completed = false;

                if (command.IsComplete)
                    continue;

                command.Lifetime -= deltaTime;

                if (command.Lifetime <= 0)
                {
                    command.Lifetime = 0;
                    command.IsComplete = true;
                }
            }

            IsCompleted = completed;

            if (IsCompleted)
            {
                Dispose();
            }
        }


        public void Dispose()
        {
            if (_disposed) return;

            _disposed = true;

            foreach (var command in _commands.Where(x => !x.IsComplete))
            {
                command.Lifetime = 0;
                command.IsComplete = true;
            }

            IsCompleted = true;

            _commands.Clear();

            _commands = null;
        }
    }
}