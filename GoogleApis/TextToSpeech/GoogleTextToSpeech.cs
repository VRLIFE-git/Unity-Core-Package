using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Vrlife.Core
{
    public class GoogleTextToSpeechService : IGoogleTextToSpeechService
    {
        private string url = "http://google.xrcloud.cz/TextToSpeech/Post";


        public IEnumerator Say(string text, GoogleVoiceType voiceType, Action<AudioClip> onsuccess, Action<Exception> onError = null, string filename = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                onError?.Invoke(new ArgumentNullException("text cannot be empty"));
                yield break;
            }
            
            var bodyJsonString = JsonConvert.SerializeObject(new TextToSpeechIndexModel
            {
                Text = text,
                FileName = filename,
                VoiceType = voiceType.ToString()
            });


            using (var unityWebRequest = new UnityWebRequest(url, "POST"))
            {
                byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
                unityWebRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
                unityWebRequest.downloadHandler = new DownloadHandlerAudioClip(url, AudioType.MPEG);
                unityWebRequest.SetRequestHeader("Content-Type", "application/json");

                yield return unityWebRequest.SendWebRequest();

                if (unityWebRequest.isHttpError || unityWebRequest.isNetworkError)
                {
                    onError?.Invoke(new Exception(unityWebRequest.responseCode + " " + unityWebRequest.error));
                    yield break;
                }

                try
                {
                    var clip = DownloadHandlerAudioClip.GetContent(unityWebRequest);
                    onsuccess?.Invoke(clip);
                }
                catch (Exception e)
                {
                    onError?.Invoke(e);
                    yield break;
                }
            }
        }
    }
}