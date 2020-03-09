using System;
using System.Collections;
using TMPro;
using UnityEngine;

[SerializeField]
public enum LoadingType
{
    Infinite,
    Percentage
}
public class Loading : MonoBehaviour
{
    [Header("Required objects")]
    public GameObject loader;
    public TextMeshProUGUI percentText;
    [Tooltip("Can be null, if loading type is set to Infinite")]
    private AsyncOperation _asyncOperation;
    
    [Header("Settings")]
    public LoadingType loadingType = LoadingType.Infinite;
    [Tooltip("Speed of the loading animation, default 1")]
    public float loadingSpeed = 1f;
    
    private void Update()
    {
        loader.transform.eulerAngles = new Vector3(0f, 0f,-(Time.time * loadingSpeed * 100));
        percentText.text = Math.Round(_asyncOperation.progress * 100 , 2) + " %";
        if (_asyncOperation.progress > .89)
        {
            _asyncOperation.allowSceneActivation = true;
        }
    }

    IEnumerator spinner(AsyncOperation asyncOperation)
    {
            yield return asyncOperation;
    }

    public void StartLoading(AsyncOperation asyncOperation)
    {
        _asyncOperation = asyncOperation;
        _asyncOperation.allowSceneActivation = false;
        StartCoroutine(spinner(asyncOperation));
        loadingType = LoadingType.Percentage;
    }

    public void StartLoadingInfinite(AsyncOperation asyncOperation)
    {
        _asyncOperation = asyncOperation;
        percentText.gameObject.SetActive(false);
        StartCoroutine(spinner(asyncOperation));
    }
}