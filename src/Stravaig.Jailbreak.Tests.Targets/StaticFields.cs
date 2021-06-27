namespace Stravaig.Jailbreak.Tests.Targets
{
    public static class StaticFields
    {
        private static int _privateInt;
        internal static int _internalInt;
        
        public static int GetPrivateInt() => _privateInt;
        public static void SetPrivateInt(int value) => _privateInt = value;
    }
}