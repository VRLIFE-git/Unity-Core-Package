using System;
using System.Linq;
using UnityEngine;

namespace Vrlife.Core
{
    public abstract class CommandBufferManager : MonoBehaviour, IDisposable
    {
        private ICommandBuffer _commandBuffer;

        public void ForceCommandComplete<TCommandType>() where TCommandType : Command
        {
            ForceCommandComplete(typeof(TCommandType));
        }

        public void ForceCommandComplete(Type type)
        {
            if (!type.IsSubclassOf(typeof(Command)))
            {
                Debug.LogError("Type " + type + " doesn't inherits " + nameof(Command));
                return;
            }

            var command = _commandBuffer?.Commands?.Where(x => x.GetType() == type).FirstOrDefault();

            if (command != null)
            {
                command.IsComplete = true;
            }
        }

        protected abstract void OnBufferCompleted();

        public void BufferCommands(params Command[] commands)
        {
            if (commands == null)
                return;

            _commandBuffer = new CommandBuffer(commands);
        }

        protected void UpdateCommandBuffer()
        {
            if (_commandBuffer == null)
                return;

            if (_commandBuffer.IsCompleted)
            {
                _commandBuffer.Dispose();
                _commandBuffer = null;
                OnBufferCompleted();
                return;
            }

            _commandBuffer.RefreshBuffer(Time.deltaTime);
        }

        protected virtual void OnDestroy()
        {
            Dispose();
        }

        public void Dispose()
        {
            _commandBuffer?.Dispose();
        }
    }
}