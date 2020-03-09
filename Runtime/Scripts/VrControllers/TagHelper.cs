using System;
using System.Linq;

namespace Vrlife.Core.Vr
{
    public static class TagHelper
    {
        public static bool Contains(this string[] tags, string tag, StringComparison stringComparison =  StringComparison.InvariantCultureIgnoreCase)
        {
            if (tags == null || string.IsNullOrEmpty(tag)) return false;

            return (tags.Where(x => !string.IsNullOrEmpty(x)).Any(x => x.Equals(tag, stringComparison)));
        }
    }
}