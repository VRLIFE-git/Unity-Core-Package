using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using UnityEditor;

namespace Vrlife.Core.Editor
{
    [Serializable]
    public class DependencyJson
    {
        public Dictionary<string, string> dependencies;
    }


    public class PackageWindowUpdater : EditorWindow
    {
        string myString = "Hello World";
        bool groupEnabled;
        bool myBool = true;
        float myFloat = 1.23f;

        // Add menu item named "My Window" to the Window menu
        [MenuItem("Window/My Window")]
        public static void ShowWindow()
        {
            //Show existing window instance. If one doesn't exist, make one.
            EditorWindow.GetWindow(typeof(PackageWindowUpdater));
        }

        void OnGUI()
        {
            var path = Path.Combine(Application.dataPath, "../Packages/manifest.json");

            Debug.Log(File.Exists(path));

            var text = File.ReadAllText(path);

            var obj = JsonConvert.DeserializeObject<DependencyJson>(text);
            
            var vrlPackages = obj.dependencies.Where(x => x.Key.StartsWith("com.vrlife"));

            foreach (var keyValuePair in vrlPackages)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(keyValuePair.Key);
                if (GUILayout.Button("Import"))
                {
                    AssetDatabase.ImportPackage(keyValuePair.Value, false);
                }
                GUILayout.EndHorizontal();
            }
        }
    }
}