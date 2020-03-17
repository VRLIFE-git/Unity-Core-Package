using UnityEngine;

namespace Vrlife.Core
{
    [CreateAssetMenu(fileName = "ScreenPlay", menuName = "Director/Screen Play")]
    public class ScreenPlay : ScriptableObject, IDialog
    {
        [SerializeField] private string id;

        public string Id => id;

        public ScreenPlayLine[] lines;
    }
}