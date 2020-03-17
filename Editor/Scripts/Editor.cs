using System;
using UnityEngine;

namespace Vrlife.Core.Editor
{
    public abstract class Editor<TType> : UnityEditor.Editor where TType : class
    {
        protected TType Target { get; private set; }

        private void OnEnable()
        {
            Target = target as TType;
        }

        protected IDisposable BeginHorizontal()
        {
            return new GUILayout.HorizontalScope();
        }

        protected IDisposable BeginVertical()
        {
            return new GUILayout.VerticalScope();
        }
    }
    
}