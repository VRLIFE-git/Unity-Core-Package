using System;
using System.Collections;
using System.Collections.Generic;
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

        public Coroutine Process(IEnumerable<IEnumerator> logic, Action onCompleted)
        {
            var coroutine = StartCoroutine(CoroutineProcessing(logic, onCompleted));

            return coroutine;
        }

        public Coroutine Process<TContext>(IEnumerable<IEnumerator> logic, TContext context, Action onCompleted)
            where TContext : class
        {
            var coroutine = StartCoroutine(CoroutineProcessing(logic, context, onCompleted));

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

        private IEnumerator CoroutineProcessing<TContext>(IEnumerable<IEnumerator> logic, TContext context,
            Action onCompleted) where TContext : class
        {
            foreach (var func in logic)
            {
                if (func is LogicWrapper<TContext> wrapper)
                {
                    wrapper.ExecLogic(context);
                }
                
                yield return func;
            }

            onCompleted?.Invoke();
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        public void Dispose()
        {
        }
    }
}