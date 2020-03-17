using UnityEngine;
using Vrlife.Core.Mvc.Abstractions;

namespace Vrlife.Core.Mvc.Implementations
{
    [RequireComponent(typeof(AudioSource))]
    public class MonoAudioSourceComponent : AViewComponent, IAudioSourceComponent
    {
        [SerializeField] private AudioSource audioSource;
        protected override void OnAwoke()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayOneShot(AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }

        public void PlayOneShot(AudioClip clip, float volume)
        {
            audioSource.PlayOneShot(clip, volume);
        }
    }
}