
using UnityEngine;
using UnityEngine.Video;

namespace Vrlife.Core
{
    public class VideoControl : MonoBehaviour
    {
        private bool paused = false;
    
        public void PauseUnpause(VideoPlayer videoPlayer)
        {
            if (paused)
            {
                videoPlayer.Play();
                paused = false;
            }
            else
            {
                videoPlayer.Pause();
                paused = true;
            }
        }
    }
}

