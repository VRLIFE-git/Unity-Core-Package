using System.Collections.Generic;
using System.Linq;

namespace Vrlife.Core
{
    public class SequentialCommandBuffer : ICommandBuffer
    {
        private List<Command> _commands;

        private bool _disposed;

        public bool IsCompleted { get; private set; }

        public IReadOnlyCollection<Command> Commands => _commands;

        public SequentialCommandBuffer()
        {
            _commands = new List<Command>();
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


        public void RefreshBuffer(float deltaTime)
        {
            if (IsCompleted) return;

            var command = _commands.FirstOrDefault(x => !x.IsComplete);

            if (command == null)
            {
                IsCompleted = true;

                Dispose();
                
                return;
            }

            command.Lifetime -= deltaTime;

            if (command.Lifetime <= 0 && !command.IsComplete)
            {
                command.Lifetime = 0;
                
                command.IsComplete = true;
                
                command?.Completed?.Invoke();
            }
        }
    }
}