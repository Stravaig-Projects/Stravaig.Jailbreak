namespace Stravaig.Jailbreak.Tests.Targets
{
    public class StaticProperties
    {
        private static int PrivateInt { get; set; }
        internal static int InternalInt { get; set; }
        
        public static int GetPrivateInt() => PrivateInt;
        public static void SetPrivateInt(int value) => PrivateInt = value;
    }
}