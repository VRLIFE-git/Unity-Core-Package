using UnityEngine;

namespace Vrlife.Core
{
    public abstract class CommandBufferManager : MonoBehaviour
    {
        private ICommandBuffer _commandBuffer;

        
        public void BufferCommands(params Command[] commands)
        {
            if (commands == null)
                return;

            _commandBuffer = new CommandBuffer(commands);
        }

        protected void UpdateCommandBuffer()
        {
            if (_commandBuffer == null || _commandBuffer.IsCompleted)
                return;

            _commandBuffer.RefreshBuffer(Time.deltaTime);
        }
    }
}