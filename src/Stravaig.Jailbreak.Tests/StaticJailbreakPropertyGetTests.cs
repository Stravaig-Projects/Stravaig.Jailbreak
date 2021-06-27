using System;
using System.Linq;
using NUnit.Framework;
using Shouldly;
using Stravaig.Jailbreak.Tests.Targets;

namespace Stravaig.Jailbreak.Tests
{
    [TestFixture]
    public class StaticJailbreakPropertyGetTests
    {
        [Test]
        public void GetNonExistentProperty()
        {
            dynamic cracked = typeof(StaticProperties).Jailbreak();
            var ex = Should.Throw<JailerException>(() => cracked.APropertyThatDoesNotExist);
            Console.WriteLine(ex);
            ex.AcceptedMembers.Length.ShouldBeGreaterThanOrEqualTo(1);
            ex.AcceptedMembers.FirstOrDefault(m => m.Name == "PrivateInt").ShouldNotBeNull();
        }
        
        [Test]
        public void GetPrivateInt()
        {
            StaticProperties.SetPrivateInt(123);
            dynamic cracked = typeof(StaticProperties).Jailbreak();
            ((int) cracked.PrivateInt).ShouldBe(123);
        }
    }
}