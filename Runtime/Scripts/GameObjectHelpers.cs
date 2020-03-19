using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Vrlife.Core
{
    public static class GameObjectHelpers
    {
        public static void ClearChildren(this Transform transform, bool destroyImmediate = false)
        {
            var count = transform.childCount;

            for (int i = 0; i < count; i++)
            {
                var child = transform.GetChild(i);

                if (destroyImmediate)
                {
                    Object.DestroyImmediate(child.gameObject);
                }
                else
                {
                    Object.Destroy(child.gameObject);
                }
            }
        }
    }
}