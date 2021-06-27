using System;

namespace Stravaig.Jailbreak
{
    public static class JailbreakExtensions
    {
        public static InstanceJailbreak Jailbreak(this object obj)
        {
            return new InstanceJailbreak(obj);
        }

        public static StaticJailbreak Jailbreak(this Type type)
        {
            return new StaticJailbreak(type);
        }
    }
}