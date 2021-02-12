namespace Stravaig.Jailbreak.Tests.Targets
{
    public class InstanceFields
    {
        private int _privateInt;
        protected int _protectedInt;
        internal int _internalInt;
        protected internal int _protectedInternalInt;
        
        public int GetPrivateInt() => _privateInt;
        public void SetPrivateInt(int value) => _privateInt = value;
    }
}