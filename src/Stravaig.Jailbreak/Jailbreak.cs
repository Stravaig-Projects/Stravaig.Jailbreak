using System;
using System.Dynamic;

namespace Stravaig.Jailbreak
{
    public abstract class Jailbreak : DynamicObject
    {
        protected readonly Type _type;

        protected Jailbreak(Type type)
        {
            _type = type;
        }
    }
}