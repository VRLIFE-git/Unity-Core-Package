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

        public static CoroutineBuilder BuildDelayed<TContext>(this ICoroutineProcessor processor, float delaySeconds,
            TContext context = null) where TContext : class, new()
        {
            if (context == null) context = new TContext();
            var result = new CoroutineBuilder<TContext>(processor, context);

            result.WaitForSeconds(delaySeconds);

            return result;
        }

        public static CoroutineBuilder Build<TContext>(this ICoroutineProcessor processor, IEnumerator logic,
            TContext context = null) where TContext : class, new()
        {
            if (context == null) context = new TContext();

            var result = new CoroutineBuilder<TContext>(processor, context);

            result.Then(logic);

            return result;
        }

        public static CoroutineBuilder Build<TContext>(this ICoroutineProcessor processor, Action logic,
            TContext context = null) where TContext : class, new()
        {
            if (context == null) context = new TContext();

            var result = new CoroutineBuilder<TContext>(processor, context);

            result.Then(logic);

            return result;
        }
    }
}