using UnityEngine;
using Vrlife.Core.Mvc;
using Vrlife.Core.Mvc.Implementations;
using Zenject;

namespace Vrlife.Core
{
    public class CoroutineProcessorTest : MonoBehaviour
    {
        [Inject] private ICoroutineProcessor processor;

        private void Start()
        {
            processor.Build(() => print("Good")).WaitForSeconds(3).Then(() => print("Very good")).Execute();
        }
    }
}