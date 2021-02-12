namespace Stravaig.Jailbreak.Tests.Targets
{
    public class InstanceProperties
    {
        private int PrivateInt { get; set; }
        protected int ProtectedInt { get; set; }
        internal int InternalInt { get; set; }
        protected internal int ProtectedInternalInt { get; set; }
        
        public int GetPrivateInt() => PrivateInt;
        public void SetPrivateInt(int value) => PrivateInt = value;
    }
}