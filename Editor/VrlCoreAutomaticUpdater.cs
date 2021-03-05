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
                if (Application.productName == "Unity Core Package") return;
                Client.Add("https://github.com/virtual-real-life/Unity-Core-Package.git");
            }
        }
    }
}
