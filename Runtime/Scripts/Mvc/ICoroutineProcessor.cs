using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vrlife.Core.Mvc
{
    public interface ICoroutineProcessor
    {
        Coroutine Process(IEnumerator logic, Action onCompleted);
        Coroutine Process(IEnumerable<IEnumerator> logic, Action onCompleted);
        void Stop(Coroutine coroutine);
    }
}