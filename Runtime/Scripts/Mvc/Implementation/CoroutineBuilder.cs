using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vrlife.Core.Mvc.Implementations
{
    public class LogicWrapper : IEnumerator
    {
        private readonly Action logic;

        public LogicWrapper(Action logic)
        {
            this.logic = logic;
        }

        public bool MoveNext()
        {
            logic?.Invoke();
            return false;
        }

        public void Reset()
        {
        }

        public object Current => null;
    }
    
    public class CoroutineBuilder : IDisposable
    {
        private readonly List<IEnumerator> _coroutines;

        private readonly ICoroutineProcessor _processor;

        private Coroutine _coroutine;

        private bool _disposed;
        
        public IReadOnlyCollection<IEnumerator> Coroutines => _coroutines;

        public CoroutineBuilder(ICoroutineProcessor processor)
        {
            _coroutines = new List<IEnumerator>();
            _processor = processor;
        }

        public CoroutineBuilder WaitForSeconds(float seconds)
        {
            _coroutines.Add(WaitForSecondsInternal(seconds));

            return this;
        }

        public void OnComplete(Action action)
        {
            _coroutines.Add(new CoroutineCompletion(action));

            Execute();
        }

        public CoroutineBuilder Then(IEnumerator logic)
        {
            _coroutines.Add(logic);

            return this;
        }
        
        public CoroutineBuilder Then(Action logic)
        {
            _coroutines.Add(new LogicWrapper(logic));

            return this;
        }

        public void Execute()
        {
            var coroutines = _coroutines.ToArray();
            
             _coroutine =  _processor.Process(coroutines, Dispose);
        }

        private static IEnumerator WaitForSecondsInternal(float seconds)
        {
            yield return new WaitForSeconds(seconds);
        }

        public void Dispose()
        {
            if (_disposed) return;

            _disposed = true;

            if (_coroutine != null)
            {
                _processor.Stop(_coroutine);
            }
            
            _coroutines.Clear();
        }
    }
}