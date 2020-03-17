using System;

namespace Vrlife.Core
{
    public interface ICommandBuffer : IDisposable
    {
        bool IsCompleted { get; }

        void RefreshBuffer(float deltaTime);
    }
}