using System;
using System.Collections;
using UnityEngine;

namespace Vrlife.Core.Mvc
{
    public interface ICoroutineProcessor
    {
        Coroutine Process(IEnumerator logic, Action onCompleted);
    }
}