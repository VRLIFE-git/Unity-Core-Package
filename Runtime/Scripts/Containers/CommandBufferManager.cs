using UnityEngine;

namespace Vrlife.Core
{
    public abstract class CommandBufferManager : MonoBehaviour
    {
        private ICommandBuffer _commandBuffer;


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
    }
}