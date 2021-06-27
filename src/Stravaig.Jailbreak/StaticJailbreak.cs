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
            var member = GetPropertyOrFieldInfo(binder.Name);
            return InvokeMember(member, null, out result);
        }
        
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            var member = GetMethodInfo(binder.Name);
            return InvokeMember(member, null, out result);
        }

        protected override BindingFlags AccessModifiers => base.AccessModifiers | BindingFlags.Static;
    }
}