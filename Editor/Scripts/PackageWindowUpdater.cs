using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEditor;

namespace Vrlife.Core.Editor
{
    public class GuiHorizontalHelpers : IDisposable
    {
        public GuiHorizontalHelpers()
        {
            EditorGUILayout.BeginHorizontal();
        }
        public void Dispose()
        {
            EditorGUILayout.EndHorizontal();
        }
    }

    public static class EditorWindowHelpers
    {
        public static GuiHorizontalHelpers Horizontal(this EditorWindow window)
        {
            return new GuiHorizontalHelpers();
        }

        public static bool Button(this EditorWindow window, string name, params GUILayoutOption[] options)
        {
            return GUILayout.Button(name, options);
        }
        
        public static void Label(this EditorWindow window, string name, params GUILayoutOption[] options)
        {
             GUILayout.Label(name, options);
        }
    }
    
    public class PackageWindowUpdater : EditorWindow
    {
       
        // Add menu item named "My Window" to the Window menu
        [MenuItem("Window/VRLIFE - Package updater")]
        public static void ShowWindow()
        {
            //Show existing window instance. If one doesn't exist, make one.
            GetWindow(typeof(PackageWindowUpdater), true, "VRLIFE - Package Updater", true);
        }

        private void OnEnable()
        {
            this.minSize = new Vector2(300, 300);
            this.maxSize = new Vector2(300, 300);
        }

        void OnGUI()
        {
        
            
            var path = Path.Combine(Application.dataPath, "../Packages/manifest.json");
            GUILayout.Label("Packages in " + path);
            EditorGUILayout.Separator();

            var text = File.ReadAllText(path);

            var obj = JsonConvert.DeserializeObject<DependencyJson>(text);
            
            foreach (var keyValuePair in obj.@lock)
            {
                using (this.Horizontal())
                {
                    this.Label(keyValuePair.Key);
                    
                    if (this.Button("Import", GUILayout.Width(50)))
                    {
                        obj.@lock.Remove(keyValuePair.Key);
                        var manifest = JsonConvert.SerializeObject(obj, Formatting.Indented);
                    
                        File.WriteAllText(path, manifest);
                        AssetDatabase.Refresh();
                        break;
                    }
                }
                
            }
        }
    }
}