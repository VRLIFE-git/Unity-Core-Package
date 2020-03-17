using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Vrlife.Core
{
    [Serializable]
    public class AnimationCommand : Command
    {
        public AnimationCommand(params string[] watchedStates)
        {
            if (watchedStates != null)
            {
                WatchedStates = watchedStates.Select(Animator.StringToHash);
            }
        }
        
        public IEnumerable<int> WatchedStates { get; }
    }
}