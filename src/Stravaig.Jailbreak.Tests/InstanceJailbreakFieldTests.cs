using System;
using System.Linq;
using NUnit.Framework;
using Shouldly;
using Stravaig.Jailbreak.Tests.Targets;

namespace Stravaig.Jailbreak.Tests
{
    [TestFixture]
    public class InstanceJailbreakFieldTests
    {
        [Test]
        public void GetNonExistentField()
        {
            var obj = new InstanceFields();
            dynamic cracked = obj.Jailbreak();
            var ex = Should.Throw<JailerException>(() => cracked._aFieldThatDoesNotExist);
            Console.WriteLine(ex);
            ex.AcceptedMembers.Length.ShouldBeGreaterThanOrEqualTo(1);
            ex.AcceptedMembers.FirstOrDefault(m => m.Name == "_privateInt").ShouldNotBeNull();
        }
        
        [Test]
        public void GetPrivateInt()
        {
            var obj = new InstanceFields();
            obj.SetPrivateInt(123);
            dynamic cracked = obj.Jailbreak();
            ((int) cracked._privateInt).ShouldBe(123);
        }
    }
}