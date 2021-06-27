namespace Stravaig.Jailbreak.Tests.Targets
{
    public static class StaticMethods
    {
        public static int VoidMethodCallCount { get; private set; }

        private static void PrivateVoidMethodWithNoParameters()
        {
            VoidMethodCallCount++;
        }
        
        private static string PrivateMethodWithNoParameters()
        {
            return "A fixed value";
        }
        
        
    }
}