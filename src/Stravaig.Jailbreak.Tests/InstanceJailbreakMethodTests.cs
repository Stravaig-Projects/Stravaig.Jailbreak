using System;
using System.Linq;
using NUnit.Framework;
using Shouldly;
using Stravaig.Jailbreak.Tests.Targets;

namespace Stravaig.Jailbreak.Tests
{
    [TestFixture]
    public class InstanceJailbreakMethodTests
    {
        [Test]
        public void GetNonExistentMethod()
        {
            InstanceMethods instance = new InstanceMethods();
            dynamic cracked = instance.Jailbreak();
            var ex = Should.Throw<JailerException>(() => cracked.AMethodThatDoesNotExist());
            Console.WriteLine(ex);
            ex.AcceptedMembers.Length.ShouldBeGreaterThanOrEqualTo(1);
            ex.AcceptedMembers.FirstOrDefault(m => m.Name == "PrivateMethodWithNoParameters").ShouldNotBeNull();
        }
        
        [Test]
        public void InvokeMethodWithNoParameters()
        {
            InstanceMethods instance = new InstanceMethods();
            dynamic cracked = instance.Jailbreak();
            ((string) cracked.PrivateMethodWithNoParameters()).ShouldBe("A fixed value");
        }
        
        [Test]
        public void InvokeVoidMethodWithNoParameters()
        {
            InstanceMethods instance = new InstanceMethods();
            dynamic cracked = instance.Jailbreak();
            cracked.PrivateVoidMethodWithNoParameters();
            instance.VoidMethodCallCount.ShouldBe(1);
        }
    }
}