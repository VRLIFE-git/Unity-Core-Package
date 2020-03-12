using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental;
using UnityEditor.PackageManager.UI;

namespace Vrlife.Core.Editor
{
    [Serializable]
    public class DependencyJson
    {
        public Dictionary<string, string> dependencies;
        public Dictionary<string, LockedPackage> @lock;
    }

    [Serializable]
    public class LockedPackage
    {
        public string revision;
        public string hash;
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
            
            foreach (var keyValuePair in obj.@lock)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(keyValuePair.Key);
                if (GUILayout.Button("Import"))
                {
                    obj.@lock.Remove(keyValuePair.Key);
                    var manifest = JsonConvert.SerializeObject(obj, Formatting.Indented);
                    
                    File.WriteAllText(path, manifest);
                    break;
                }
                GUILayout.EndHorizontal();
            }
        }
    }
}