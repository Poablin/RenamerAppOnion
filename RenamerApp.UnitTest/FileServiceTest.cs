using NUnit.Framework;
using Moq;
using RenamerApp.Core.ApplicationServices;
using RenamerApp.Core.DomainServices;
using RenamerApp.Core.DomainModel;
using System.Threading.Tasks;

namespace RenamerApp.UnitTest
{
    public class Tests
    {
        [Test]
        public void TestIfFileNameGetsLowerCased()
        {
            var mock = new Mock<IFileRepository>();
            var setup = mock.Setup(repo => repo.Create(It.IsAny<FileModel>())).Returns(Task.FromResult(true));
            var testFileService = new FileService("Test", mock.Object);
            Assert.AreEqual("test", testFileService.UpperCase(false));
        }
    }
}