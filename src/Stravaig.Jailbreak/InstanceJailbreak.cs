using System;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace Stravaig.Jailbreak
{
    public class InstanceJailbreak : Jailbreak
    {
        private const MemberTypes IsPropertyOrField = MemberTypes.Property | MemberTypes.Field;
        private const BindingFlags AllAccessModifiers = BindingFlags.Public | BindingFlags.NonPublic;
        
        private readonly object _object;

        public InstanceJailbreak(object obj)
            : base(obj.GetType())
        {
            _object = obj;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            MemberInfo[] members = _type.GetMember(binder.Name, IsPropertyOrField, AllAccessModifiers | BindingFlags.Instance | BindingFlags.GetField | BindingFlags.GetProperty);
            if (members.Length == 0)
            {
                throw new JailerException(
                    $"Unable to find member with the name {binder.Name}.",
                    GetAcceptedMembers());
            }

            if (members.Length > 1)
            {
                throw new AmbiguousMatchException($"Found {members.Length} matches for {binder.Name}.");
            }

            var member = members[0];
            if (member is FieldInfo field)
            {
                result = field.GetValue(_object);
                return true;
            }
            
            if (member is PropertyInfo property)
            {
                var method = property.GetMethod;
                if (method == null)
                {
                    result = null;
                    return false;
                }

                result = method.Invoke(_object, Array.Empty<object>());
                return true;
            }
            
            throw new InvalidOperationException($"{member} is not a property or field.");
        }

        private MemberInfo[] GetAcceptedMembers()
        {
            var members = _type.GetMembers(AllAccessModifiers | BindingFlags.Instance | BindingFlags.GetField |
                                           BindingFlags.GetProperty);
            return members
                .Where(m => (m.MemberType & IsPropertyOrField) != 0)
                .ToArray();

        }
    }
}