using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vrlife.Core.Mvc.Implementations
{
    public class CoroutineBuilder<TContext> : CoroutineBuilder where TContext : class
    {
        private readonly TContext _context;
        
        public CoroutineBuilder(ICoroutineProcessor processor, TContext context) : base(processor)
        {
            _context = context;
        }
        
        public CoroutineBuilder Then(Action<TContext> logic)
        {
            _coroutines.Add(new LogicWrapper<TContext>(logic));

            return this;
        }

        public override void Execute()
        {
            var coroutines = _coroutines.ToArray();
            
            Processor.Process(coroutines, _context, Dispose);
        }
    }

    public class CoroutineBuilder : IDisposable
    {
        protected readonly List<IEnumerator> _coroutines;

        protected ICoroutineProcessor Processor { get; }

        private Coroutine _coroutine;

        private bool _disposed;

        public IReadOnlyCollection<IEnumerator> Coroutines => _coroutines;


        public CoroutineBuilder(ICoroutineProcessor processor)
        {
            _coroutines = new List<IEnumerator>();
            Processor = processor;
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

        public virtual void Execute()
        {
            var coroutines = _coroutines.ToArray();

            _coroutine = Processor.Process(coroutines, Dispose);
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
                Processor.Stop(_coroutine);
            }

            _coroutines.Clear();
        }
    }
}