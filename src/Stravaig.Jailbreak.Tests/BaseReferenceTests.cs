using NUnit.Framework;
using Shouldly;
using Stravaig.Jailbreak.Tests.Targets;

namespace Stravaig.Jailbreak.Tests
{
    [TestFixture]
    public class BaseReferenceTests
    {
        [Test]
        public void CanAccessConcreteFieldFromBaseReference()
        {
            IReferenceInterface baseReference = new ConcreteClass("some value");

            dynamic cracked = baseReference.Jailbreak();
            string roundtripValue = cracked._someField;
            
            roundtripValue.ShouldBe("some value");
        }
    }
}