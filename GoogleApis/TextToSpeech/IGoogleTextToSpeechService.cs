using System;
using System.Collections;
using UnityEngine;

namespace Vrlife.Core
{
    public interface IGoogleTextToSpeechService
    {
        IEnumerator Say(string text, GoogleVoiceType voiceType, Action<AudioClip> onsuccess,
            Action<Exception> onError = null, string filename = null);
    }
}