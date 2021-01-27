using NUnit.Framework;
using Shouldly;
using Stravaig.Jailbreak.Tests.Targets;

namespace Stravaig.Jailbreak.Tests
{
    [TestFixture]
    public class InstanceJailbreakFieldTests
    {
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