using System;
using System.Dynamic;
using System.Reflection;

namespace Stravaig.Jailbreak
{
    public abstract class Jailbreak : DynamicObject
    {
        protected const MemberTypes IsPropertyOrField = MemberTypes.Property | MemberTypes.Field;
        protected const BindingFlags AllAccessModifiers = BindingFlags.Public | BindingFlags.NonPublic;

        protected readonly Type TargetType;

        protected Jailbreak(Type targetType)
        {
            TargetType = targetType;
        }
        
        protected MemberInfo GetMemberInfo(GetMemberBinder binder)
        {
            MemberInfo[] members = TargetType.GetMember(binder.Name, IsPropertyOrField,
                AllAccessModifiers | BindingFlags.Instance | BindingFlags.GetField | BindingFlags.GetProperty);
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
            return member;
        }
        
        private MemberInfo[] GetAcceptedMembers()
        {
            var members = TargetType.GetMembers(AllAccessModifiers | BindingFlags.Instance | BindingFlags.GetField |
                                           BindingFlags.GetProperty);
            return Array.FindAll(members, m => (m.MemberType & IsPropertyOrField) != 0);
        }
        
        protected static bool InvokeMember(MemberInfo member, object obj, out object result)
        {
            if (member is FieldInfo field)
            {
                result = field.GetValue(obj);
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

                result = method.Invoke(obj, Array.Empty<object>());
                return true;
            }

            throw new InvalidOperationException($"{member} is not a property or field.");
        }

    }
}