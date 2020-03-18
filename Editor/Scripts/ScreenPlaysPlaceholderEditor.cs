using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Vrlife.Core.Editor
{
    public class ArrayContext<TValueType> : IEnumerable<TValueType> where TValueType : ScriptableObject
    {
        private readonly string _propName;
        private readonly SerializedObject _context;
        private readonly SerializedProperty _serializedArray;

        public ArrayContext(SerializedObject context, string propName)
        {
            _context = context;
            _propName = propName;
            _serializedArray = _context.FindProperty(_propName);
            ;
        }

        public TValueType this[int index] =>
            _serializedArray.GetArrayElementAtIndex(index).objectReferenceValue as TValueType;

        public int Length => _serializedArray.arraySize;

        private TValueType[] GetArray()
        {
            var result = new TValueType[_serializedArray.arraySize];

            for (int i = 0; i < result.Length; i++)
            {
                var element = _serializedArray.GetArrayElementAtIndex(i);

                result[i] = element.objectReferenceValue as TValueType;
            }

            return result;
        }

        public void Append(TValueType item)
        {
            _serializedArray.InsertArrayElementAtIndex(_serializedArray.arraySize);
            var prop = _serializedArray.GetArrayElementAtIndex(_serializedArray.arraySize - 1);
            prop.objectReferenceValue = item;
        }

        public void Save()
        {
            _context.ApplyModifiedProperties();
        }

        public IEnumerator<TValueType> GetEnumerator()
        {
            var array = GetArray();

            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void SetAt(int i, TValueType value)
        {
            var element = _serializedArray.GetArrayElementAtIndex(i);
            element.objectReferenceValue = value;
        }

        public void Remove(TValueType screenPlaceHolder)
        {
            var array = GetArray();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == screenPlaceHolder)
                {
                    _serializedArray.DeleteArrayElementAtIndex(i);

                    break;
                }
            }
        }
    }

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