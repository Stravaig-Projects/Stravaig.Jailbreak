using System;
using System.Linq;
using NUnit.Framework;
using Shouldly;
using Stravaig.Jailbreak.Tests.Targets;

namespace Stravaig.Jailbreak.Tests
{
    [TestFixture]
    public class StaticJailbreakMethodTests
    {
        [Test]
        public void GetNonExistentMethod()
        {
            dynamic cracked = typeof(StaticMethods).Jailbreak();
            var ex = Should.Throw<JailerException>(() => cracked.AMethodThatDoesNotExist());
            Console.WriteLine(ex);
            ex.AcceptedMembers.Length.ShouldBeGreaterThanOrEqualTo(1);
            ex.AcceptedMembers.FirstOrDefault(m => m.Name == "PrivateMethodWithNoParameters").ShouldNotBeNull();
        }
        
        [Test]
        public void InvokeMethodWithNoParameters()
        {
            dynamic cracked = typeof(StaticMethods).Jailbreak();
            ((string) cracked.PrivateMethodWithNoParameters()).ShouldBe("A fixed value");
        }
        
        [Test]
        public void InvokeVoidMethodWithNoParameters()
        {
            int startCount = StaticMethods.VoidMethodCallCount;
            dynamic cracked = typeof(StaticMethods).Jailbreak();
            cracked.PrivateVoidMethodWithNoParameters();
            int endCount = StaticMethods.VoidMethodCallCount;
            endCount.ShouldBe(startCount + 1);
        }
    }
}