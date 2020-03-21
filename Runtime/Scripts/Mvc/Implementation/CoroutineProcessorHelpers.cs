using System;
using System.Collections;

namespace Vrlife.Core.Mvc.Implementations
{
    public static class CoroutineProcessorHelpers
    {
        public static CoroutineBuilder BuildDelayed(this ICoroutineProcessor processor, float delaySeconds)
        {
            var result = new CoroutineBuilder(processor);

            result.WaitForSeconds(delaySeconds);

            return result;
        }
        
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
}