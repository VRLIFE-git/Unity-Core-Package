using System;
using System.Collections.Generic;

namespace Vrlife.Core.Editor
{
    [Serializable]
    public class DependencyJson
    {
        public Dictionary<string, string> dependencies;
        public Dictionary<string, LockedPackage> @lock;
    }
}