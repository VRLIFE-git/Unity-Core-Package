using UnityEngine;

namespace Vrlife.Core.Mvc
{
    public interface IAudioSourceComponent : IViewComponent
    {
        void PlayOneShot(AudioClip clip);
        void PlayOneShot(AudioClip clip, float volumeScale);
    }
}