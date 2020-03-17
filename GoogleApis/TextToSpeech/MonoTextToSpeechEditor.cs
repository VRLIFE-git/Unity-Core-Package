using UnityEngine;
using Vrlife.Core.GoogleApis.TextToSpeech;

namespace Vrlife.Core
{
#if UNITY_EDITOR
    [UnityEditor.CustomEditor(typeof(MonoTextToSpeech))]
    public class MonoTextToSpeechEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Trigger"))
            {
                (target as MonoTextToSpeech).TriggerSay();
            }
        }
    }
#endif
}