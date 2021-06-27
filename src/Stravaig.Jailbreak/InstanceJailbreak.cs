using System.Dynamic;
using System.Reflection;

namespace Stravaig.Jailbreak
{
    public class InstanceJailbreak : Jailbreak
    {
        private readonly object _object;

        public InstanceJailbreak(object obj)
            : base(obj.GetType())
        {
            _object = obj;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var member = GetPropertyOrFieldInfo(binder.Name);
            return InvokeMember(member, _object, out result);
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            var methodInfo = GetMethodInfo(binder.Name);
            return InvokeMember(methodInfo, _object, out result);
        }

        protected override BindingFlags AccessModifiers => base.AccessModifiers | BindingFlags.Instance;
    }
}