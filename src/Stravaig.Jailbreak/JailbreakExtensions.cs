namespace Stravaig.Jailbreak
{
    public static class JailbreakExtensions
    {
        public static InstanceJailbreak Jailbreak(this object obj)
        {
            return new InstanceJailbreak(obj);
        }
    }
}