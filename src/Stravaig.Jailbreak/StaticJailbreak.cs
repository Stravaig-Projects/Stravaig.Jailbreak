using System;
using System.Dynamic;

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
    }
}