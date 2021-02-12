using System;
using System.Linq;
using NUnit.Framework;
using Shouldly;
using Stravaig.Jailbreak.Tests.Targets;

namespace Stravaig.Jailbreak.Tests
{
    [TestFixture]
    public class InstanceJailbreakPropertyGetTests
    {
        [Test]
        public void GetNonExistentProperty()
        {
            var obj = new InstanceProperties();
            dynamic cracked = obj.Jailbreak();
            var ex = Should.Throw<JailerException>(() => cracked.APropertyThatDoesNotExist);
            Console.WriteLine(ex);
            ex.AcceptedMembers.Length.ShouldBeGreaterThanOrEqualTo(1);
            ex.AcceptedMembers.FirstOrDefault(m => m.Name == "PrivateInt").ShouldNotBeNull();
        }
        
        [Test]
        public void GetPrivateInt()
        {
            var obj = new InstanceProperties();
            obj.SetPrivateInt(123);
            dynamic cracked = obj.Jailbreak();
            ((int) cracked.PrivateInt).ShouldBe(123);
        }
    }
}