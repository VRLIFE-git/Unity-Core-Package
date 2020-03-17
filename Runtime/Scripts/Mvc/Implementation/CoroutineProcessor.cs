using System;
using System.Collections;
using UnityEngine;

namespace Vrlife.Core.Mvc.Implementations
{
    public class CoroutineProcessor : MonoBehaviour, ICoroutineProcessor, IDisposable
    {
        private IEnumerator CoroutineProcessing(IEnumerator logic, Action onCompleted)
        {
            yield return logic;
            
            onCompleted?.Invoke();
        }
        
        public Coroutine Process(IEnumerator logic, Action onCompleted)
        {
            var coroutine = StartCoroutine(CoroutineProcessing(logic, onCompleted));

            return coroutine;
        }

        public void Dispose()
        {
            StopAllCoroutines();
        }
    }
}