using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using RenamerApp.Core.ApplicationServices;
using RenamerApp.Core.DomainModel;
using RenamerApp.Core.DomainServices;

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