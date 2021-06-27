namespace Stravaig.Jailbreak.Tests.Targets
{
    public class InstanceMethods
    {
        public int VoidMethodCallCount { get; private set; }

        private void PrivateVoidMethodWithNoParameters()
        {
            VoidMethodCallCount++;
        }
        
        private string PrivateMethodWithNoParameters()
        {
            return "A fixed value";
        }
        
        
    }
}