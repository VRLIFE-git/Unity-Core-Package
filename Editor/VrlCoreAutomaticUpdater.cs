using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;

namespace Plugins.com.vrlife.core.Editor
{
    public class VrlCoreAutomaticUpdater
    {
        [InitializeOnLoad]
        public class AutomaticUpdate
        {
            static AutomaticUpdate()
            {
                try
                {
                    Client.Add("https://github.com/virtual-real-life/Unity-Core-Package.git");
                }
                catch
                {
                    Debug.Log("VRL Core package already exists.");
                }
                
            }
        }
    }
}
