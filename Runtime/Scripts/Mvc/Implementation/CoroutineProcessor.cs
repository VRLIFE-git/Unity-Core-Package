using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vrlife.Core.Mvc.Implementations
{
    public static class CoroutineProcessorHelpers
    {
        public static CoroutineBuilder Build(this ICoroutineProcessor processor, IEnumerator logic)
        {
            var result = new CoroutineBuilder(processor);

            result.Then(logic);

            return result;
        } 
        
        public static CoroutineBuilder Build(this ICoroutineProcessor processor, Action logic)
        {
            var result = new CoroutineBuilder(processor);

            result.Then(logic);

            return result;
        }
    }

    public class CoroutineCompletion : IEnumerator
    {
        private readonly Action _onComplete;

        public CoroutineCompletion(Action onComplete)
        {
            _onComplete = onComplete;
        }

        public bool MoveNext()
        {
            _onComplete?.Invoke();
            return false;
        }

        public void Reset()
        {
        }

        public object Current => null;
    }

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

        public Coroutine Process(IEnumerable<IEnumerator> logic, Action onCompleted)
        {
            var coroutine = StartCoroutine(CoroutineProcessing(logic, onCompleted));

            return coroutine;
        }

        public void Stop(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }

        private IEnumerator CoroutineProcessing(IEnumerable<IEnumerator> logic, Action onCompleted)
        {
            foreach (var func in logic)
            {
                yield return func;
            }
            
            onCompleted?.Invoke();
        }


        public void Dispose()
        {
            StopAllCoroutines();
        }
    }
}