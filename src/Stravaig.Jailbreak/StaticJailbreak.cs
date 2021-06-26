using System;
using System.Dynamic;
using System.Reflection;

namespace Stravaig.Jailbreak
{
    public class StaticJailbreak : Jailbreak
    {
        public StaticJailbreak(Type targetType) : base(targetType)
        {
        }
        
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var member = GetMemberInfo(binder);
            return InvokeMember(member, null, out result);
        }

        protected override BindingFlags AllAccessModifiers => base.AllAccessModifiers | BindingFlags.Static;
    }
}