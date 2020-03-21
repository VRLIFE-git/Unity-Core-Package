using System.Linq;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Vrlife.Core.Editor
{
    [CustomEditor(typeof(ActorManager))]
    public class ActorManagerEditor : Editor<ActorManager>
    {
        protected override void OnEnable()
        {
            base.OnEnable();
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("onLineComplete"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("onCommandsBuffered"));

            var screenPlaysProp = serializedObject.FindProperty("screenPlays");

            var size = screenPlaysProp.arraySize;

            if (size == 0)
            {
                screenPlaysProp.InsertArrayElementAtIndex(0);

                serializedObject.ApplyModifiedProperties();
            }

            for (int i = 0; i < size; i++)
            {
                var element = screenPlaysProp.GetArrayElementAtIndex(i);

                if (!element.objectReferenceValue)
                {
                    element.objectReferenceValue = CreateInstance<ScreenPlaysPlaceholder>();

                    serializedObject.ApplyModifiedProperties();
                }

                var elementSerialized = new SerializedObject(element.objectReferenceValue);

                var screenPlay = elementSerialized.FindProperty("screenPlay");

                EditorGUILayout.PropertyField(screenPlay);


                var lines = elementSerialized.FindProperty("lines");

                if (lines.arraySize == 0)
                {
                    lines.InsertArrayElementAtIndex(0);

                    var line = ScriptableObject.CreateInstance<ActorScreenPlayLine>();


                    lines.GetArrayElementAtIndex(0).objectReferenceValue = line;

                    serializedObject.ApplyModifiedProperties();
                }

                for (int j = 0; j < lines.arraySize; j++)
                {
                    var prop = lines.GetArrayElementAtIndex(j).objectReferenceValue;

                    var so = new SerializedObject(prop);

                    var o = prop as ActorScreenPlayLine;


                    GUILayout.Label(so.FindProperty("Id").stringValue ?? "Id");
                    
                    var value = GUILayout.TextField(so.FindProperty("Id").stringValue);
                    
                    if (value != o.Id)
                        so.FindProperty("Id").stringValue = value;

                    so.ApplyModifiedProperties();

                    EditorGUILayout.PropertyField(so.FindProperty("onLineExecute"));
                }
            }
        }
    }
}