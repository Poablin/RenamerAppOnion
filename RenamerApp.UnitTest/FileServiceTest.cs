using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using RenamerApp.Core.ApplicationServices;
using RenamerApp.Core.DomainModel;
using RenamerApp.Core.DomainServices;
using RenamerApp.Infrastructure;

namespace RenamerApp.UnitTest
{
    public class Tests
    {
        [Test]
        public void TestIfFileNameGetsLowerCased()
        {
            //var mock = new Mock<IFileRepository>();
            //var setup = mock.Setup(repo => repo.Create(It.IsAny<FileModel>())).Returns(Task.FromResult(true));
            var testInMemoryRepository = new InMemoryRepository();
            var testFileService = new FileService("Test", testInMemoryRepository);
            testFileService.CreateFileRepository();
            var test = testFileService.UpperCase(false);
            var result = test.Result;
            Assert.AreEqual("test", result);
        }
        [Test]
        public void TestIfFileNameGetsUpperCase()
        {
            var testInMemoryRepository = new InMemoryRepository();
            var testFileService = new FileService("Test", testInMemoryRepository);
            testFileService.CreateFileRepository();
            var test = testFileService.UpperCase(true);
            var result = test.Result;
            Assert.AreEqual("Test", result);
        }
    }
}