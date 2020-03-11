
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Vrlife.Core
{
    public class VideoControl : MonoBehaviour
    {
        public VideoPlayer videoPlayer;
        public Loading loadingPrefab;
        private Loading _loading;
        private GameObject loader;
        private void Start()
        {
            _loading = GameObject.Instantiate(loadingPrefab);
            _loading.transform.SetParent(videoPlayer.transform, false);
            _loading.loadingType = LoadingType.Infinite;
            _loading.percentText.gameObject.SetActive(false);
            loader = _loading.loader;
            loader.transform.localPosition = new Vector3(0f, -270f, 0f);
            loader.gameObject.GetComponent<Image>().color = Color.black;


            videoPlayer.prepareCompleted += DisableLoader;
        }

        private void Update()
        {
            if (!videoPlayer.isPrepared)
            {
                loader.transform.eulerAngles = new Vector3(0f, 0f,-(Time.time * 100));
            }
        }

        private bool paused = false;
    
        public void PauseUnpause()
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

        public void DisableLoader(VideoPlayer localVideoPlayer)
        {
            _loading.gameObject.SetActive(false);
        }
        
    }
}

