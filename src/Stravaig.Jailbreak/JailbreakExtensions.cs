namespace Stravaig.Jailbreak
{
    public static class JailbreakExtensions
    {
        public static InstanceJailbreak<T> Jailbreak<T>(this T obj)
        {
            return new InstanceJailbreak<T>(obj);
        }
    }
}