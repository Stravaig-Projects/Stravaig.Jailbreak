using System;
using System.Dynamic;
using System.Reflection;

namespace Stravaig.Jailbreak
{
    public abstract class Jailbreak : DynamicObject
    {
        private const MemberTypes IsPropertyOrField = MemberTypes.Property | MemberTypes.Field;
        private const MemberTypes IsMethod = MemberTypes.Method;
        protected virtual BindingFlags AccessModifiers => BindingFlags.Public | BindingFlags.NonPublic;

        private readonly Type _targetType;

        protected Jailbreak(Type targetType)
        {
            _targetType = targetType;
        }
        
        protected MemberInfo GetPropertyOrFieldInfo(string name)
        {
            var accessModifiers = AccessModifiers | BindingFlags.GetField | BindingFlags.GetProperty;
            MemberInfo[] members = _targetType.GetMember(name, IsPropertyOrField,
                accessModifiers);
            if (members.Length == 0)
            {
                throw new JailerException(
                    $"Unable to find field or property with the name {name}.",
                    GetAcceptedMembers(accessModifiers, IsPropertyOrField));
            }

            if (members.Length > 1)
            {
                throw new AmbiguousMatchException($"Found {members.Length} matches for {name}.");
            }

            var member = members[0];
            return member;
        }
        
        protected MethodInfo GetMethodInfo(string name)
        {
            var bindingAttr = AccessModifiers | BindingFlags.InvokeMethod;
            MemberInfo[] members = _targetType.GetMember(name, IsMethod, bindingAttr);
            if (members.Length == 0)
            {
                throw new JailerException(
                    $"Unable to find field or property with the name {name}.",
                    GetAcceptedMembers(bindingAttr, IsMethod));
            }

            if (members.Length > 1)
            {
                throw new AmbiguousMatchException($"Found {members.Length} matches for {name}.");
            }

            var member = members[0];
            return (MethodInfo)member;
        }
        
        private MemberInfo[] GetAcceptedMembers(BindingFlags accessModifiers, MemberTypes memberTypes)
        {
            var members = _targetType.GetMembers(accessModifiers);
            return Array.FindAll(members, m => (m.MemberType & memberTypes) != 0);
        }
        
        protected static bool InvokeMember(MemberInfo member, object obj, out object result)
        {
            result = null;
            if (ProcessField(member, obj, ref result)) return true;

            if (ProcessProperty(member, obj, ref result)) return true;

            if (ProcessMethod(member, obj, ref result)) return true;

            throw new InvalidOperationException($"{member} is not an understood member type.");
        }

        private static bool ProcessMethod(MemberInfo member, object obj, ref object result)
        {
            if (!(member is MethodInfo method)) return false;
            
            if (method.GetParameters().Length > 0)
                throw new InvalidOperationException("Does not yet handle method parameters");
            result = method.Invoke(obj, Array.Empty<object>());
            return true;
        }

        private static bool ProcessProperty(MemberInfo member, object obj, ref object result)
        {
            if (!(member is PropertyInfo property)) return false;
            
            var method = property.GetMethod;
            if (method == null)
            {
                throw new InvalidOperationException($"Property {member} does not have a getter.");
            }

            result = method.Invoke(obj, Array.Empty<object>());
            return true;
        }

        private static bool ProcessField(MemberInfo member, object obj, ref object result)
        {
            if (!(member is FieldInfo field)) return false;
            
            result = field.GetValue(obj);
            return true;
        }
    }
}