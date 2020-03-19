using System;
using System.Collections.Generic;

namespace Vrlife.Core
{
    public interface ICommandBuffer : IDisposable
    {
        bool IsCompleted { get; }

        void RefreshBuffer(float deltaTime);
        
        IReadOnlyCollection<Command> Commands { get; }
    }
}