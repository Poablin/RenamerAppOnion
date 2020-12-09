using NUnit.Framework;
using RenamerApp.Core.ApplicationServices;

namespace RenamerApp.UnitTest
{
    public class Tests
    {
        [Test]
        public void TestIfFileNameGetsLowerCased()
        {
            var testFileService = new FileService("Test");
            Assert.AreEqual("test", testFileService.UpperCase(false));
        }
    }
}