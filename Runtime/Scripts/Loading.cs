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
    public AsyncOperation asyncOperation;
    
    [Header("Settings")]
    public LoadingType loadingType = LoadingType.Infinite;
    [Tooltip("Speed of the loading animation, default 1")]
    public float loadingSpeed = 1f;

    
    private void Start()
    {
        if (loadingType == LoadingType.Infinite)
        {
            percentText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        loader.transform.eulerAngles = new Vector3(0f, 0f,-(Time.time * loadingSpeed * 100));
        if (loadingType == LoadingType.Percentage && asyncOperation != null)
        {
            percentText.text = (asyncOperation.progress * 100) + " %";
        }
    }
}
