using UnityEditor;
using UnityEngine;
using Vrlife.Core.Mvc;

namespace Vrlife.Core.Editor
{
    [CustomEditor(typeof(MonoKinematicAnimatorComponent))]
    public class MonoKinematicAnimatorComponentEditor : Editor<MonoKinematicAnimatorComponent>
    {
        private void OnSceneGUI()
        {
            if (Target.LookAtTarget)
            {
                EditorGUI.BeginChangeCheck();
                var newTargetPosition =
                    Handles.PositionHandle(Target.LookAtTarget.position, Target.LookAtTarget.rotation);

                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(Target, "Change Look At Target Position");

                    var t = serializedObject.Get<Transform>(MonoKinematicAnimatorComponent.LookAtName);

                    t.position = newTargetPosition;

                    serializedObject.ApplyModifiedProperties();
                }
            }
        }
    }

    public static class SerializedObjectHelpers
    {
        public static TValue Get<TValue>(this SerializedObject serializedObject, string name) where TValue : Object
        {
            return serializedObject.FindProperty(name).objectReferenceValue as TValue;
        }
    }
}