using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Vrlife.Core.Editor
{
    [CustomEditor(typeof(CommandCompletionTrigger))]
    public class CommandCompletionTriggerEditor : Editor<CommandCompletionTrigger>
    {
        private string[] options = new string[0];
        private int _selected;
        protected override void OnEnable()
        {
            base.OnEnable();

            var subclasses =
                from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetTypes()
                where type.IsSubclassOf(typeof(Command))
                select type;

            options = subclasses.Select(x => x.FullName).ToArray();

            _selected = options.GetIndex(x => x == Target.type);
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            using (BeginHorizontal())
            {
                GUILayout.Label("Command type ");
                
                var option = EditorGUILayout.Popup("Command ", _selected, options);

                Target.type = options[option];
            }
        }
    }
}