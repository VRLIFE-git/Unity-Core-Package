using System.Collections.Generic;

namespace Vrlife.Core
{
    class CommandBuffer : ICommandBuffer
    {
        private List<Command> _commands;
        private bool _disposed = false;

        public CommandBuffer(IEnumerable<Command> commands)
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

            IsCompleted = true;
            _commands.Clear();

            _commands = null;
        }
    }
}