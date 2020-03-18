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
            if (!serializedObject.GetBool(MonoKinematicAnimatorComponent.DrawGizmosName))
            {
                return;
            }
            
            
            if (Target.LookAtTarget)
            {
                CreateHandleFor(MonoKinematicAnimatorComponent.LookAtName);
            }

            if (Target.RightHandTarget)
            {
                CreateHandleFor(MonoKinematicAnimatorComponent.RightHandTargetName);
            }
            
            if (Target.LeftHandTarget)
            {
                CreateHandleFor(MonoKinematicAnimatorComponent.LeftHandTargetName);
            }
            
            if (Target.RightFootTarget)
            {
                CreateHandleFor(MonoKinematicAnimatorComponent.RightFootTargetName);
            }
            
            if (Target.LeftFootTarget)
            {
                CreateHandleFor(MonoKinematicAnimatorComponent.LeftFootTargetName);
            }
        }

        private void CreateHandleFor(string propName)
        {
            EditorGUI.BeginChangeCheck();
            var t = serializedObject.Get<Transform>(propName);
            
            var lookAt = Handles.PositionHandle(t.position, t.rotation);
            
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(Target, "Change Look At Target Position");


                t.position = lookAt;

                serializedObject.ApplyModifiedProperties();
            }
        }
    }

    public static class SerializedObjectHelpers
    {
        public static TValue Get<TValue>(this SerializedObject serializedObject, string name) where TValue : Object
        {
            return serializedObject.FindProperty(name).objectReferenceValue as TValue;
        } public static bool GetBool(this SerializedObject serializedObject, string name)
        {
            return serializedObject.FindProperty(name).boolValue;
        }
    }
}