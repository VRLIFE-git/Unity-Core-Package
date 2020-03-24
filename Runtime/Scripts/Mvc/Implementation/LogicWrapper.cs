using System;
using System.Collections;

namespace Vrlife.Core.Mvc.Implementations
{
    public class LogicWrapper<TContext> : IDisposable, IEnumerator where TContext : class
    {
        private  Action<TContext> _logic;


        public LogicWrapper(Action<TContext> logic)
        {
            _logic = logic;
        }

        public bool MoveNext()
        {
            return false;
        }

        public void ExecLogic(TContext context)
        {
            _logic.Invoke(context);
        }
        
        public void Reset()
        {
        }

        public object Current => null;

        public void Dispose()
        {
            _logic = null;
        }
    }

    public class LogicWrapper : IEnumerator, IDisposable
    {
        private Action _logic;

        public LogicWrapper(Action logic)
        {
            _logic = logic;
        }

        public bool MoveNext()
        {
            _logic?.Invoke();
            return false;
        }

        public void Reset()
        {
        }

        public object Current => null;

        public void Dispose()
        {
            _logic = null;
        }
    }
}