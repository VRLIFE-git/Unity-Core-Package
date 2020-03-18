using System.Linq;
using UnityEditor;
using Object = UnityEngine.Object;

namespace Vrlife.Core.Editor
{
    [CustomEditor(typeof(ActorManager))]
    public class ActorManagerEditor : Editor<ActorManager>
    {

        protected override void OnEnable()
        {
            base.OnEnable();
        }

        public override void OnInspectorGUI()
        {
        }
    }
}