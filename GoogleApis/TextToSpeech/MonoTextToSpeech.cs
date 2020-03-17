using UnityEngine;
using Zenject;

namespace Vrlife.Core
{
    public class MonoTextToSpeech : MonoBehaviour
    {
        [Inject] private IGoogleTextToSpeechService _googleText;

        public string text;
        public GoogleVoiceType voiceType;
        [SerializeField] private AudioSource _audio;
        public void TriggerSay()
        {
            StartCoroutine(_googleText.Say(text, voiceType, clip => _audio.PlayOneShot(clip),
                Debug.LogException));
        }
    }
}