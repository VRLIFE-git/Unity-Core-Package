using System;
using UnityEditor;
using UnityEngine;

namespace Vrlife.Core.Editor
{
    public static class ArrayHelpers
    {
        public static ArrayContext<TArrayType> GetArray<TArrayType>(this SerializedObject context, string arrayPropName)
            where TArrayType : ScriptableObject
        {
            return new ArrayContext<TArrayType>(context, arrayPropName);
        }

        public static int GetIndex<T>(this T[] values, Func<T, bool> predicate)
        {
            for (var index = 0; index < values.Length; index++)
            {
                var value = values[index];
                if (predicate(value))
                {
                    return index;
                }
            }

            return -1;
        }
    }
}