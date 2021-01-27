namespace Stravaig.Jailbreak.Tests.Targets
{
    public class InstanceFields
    {
        private int _privateInt;
        protected int _protectedInt;
        internal int _internalInt;
        protected internal int _protectedInternalInt;

        public static int _publicStaticInt;
        private static int _privateStaticInt;
        protected static int _protectedStaticInt;
        internal static int _internalStaticInt;
        protected internal static int _protectedInternalStaticInt;

        public int GetPrivateInt() => _privateInt;
        public void SetPrivateInt(int value) => _privateInt = value;
    }
}