using System.Dynamic;

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
            var member = GetMemberInfo(binder);
            return InvokeMember(member, _object, out result);
        }

    }
}