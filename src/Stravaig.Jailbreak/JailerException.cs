using System;
using System.Linq;
using System.Reflection;

namespace Stravaig.Jailbreak
{
    [Serializable]
    public class JailerException : Exception
    {
        public MemberInfo[] AcceptedMembers { get; } = Array.Empty<MemberInfo>();
        public JailerException()
        {
        }

        public JailerException(string message)
            : base(message)
        {
        }

        public JailerException(string message, MemberInfo[] acceptedMembers) 
            : base(Expand(message, acceptedMembers))
        {
            AcceptedMembers = acceptedMembers;
        }

        public JailerException(string message, Exception inner) : base(message, inner)
        {
        }

        private static string Expand(string message, MemberInfo[] members)
        {
            var memberNames = members
                .OrderBy(m => m.Name)
                .Select(m => $" * {m.Name} ({m.MemberType})");
            return $"{message}{Environment.NewLine}Accepted Members:{Environment.NewLine}{string.Join(Environment.NewLine, memberNames)}";
        }
    }
}