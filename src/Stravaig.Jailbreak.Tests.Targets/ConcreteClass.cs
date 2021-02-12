namespace Stravaig.Jailbreak.Tests.Targets
{
    public class ConcreteClass : IReferenceInterface
    {
        private string _someField;

        public ConcreteClass(string fieldValue)
        {
            _someField = fieldValue;
        }
    }
}