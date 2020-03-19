using System;
using System.Collections;

namespace Vrlife.Core.Mvc.Implementations
{
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
}