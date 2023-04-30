using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehiclePhotography.App.Models.Values;

namespace VehiclePhotography.Tests.Models.ValuesTests.ImageFileInfoTests
{
    [TestClass()]
    public class ConstructorShould
    {
        [TestMethod]
        public void GivenValidValues_CreateValidObject()
        {
            // Act
            var actual = new ImageFileInfo("irrelevant name", "irrelevant type", "irrelevant path", "irrelevant size", "irrelevant date", 100, 200);

            // Assert
            Assert.AreEqual("irrelevant name", actual.FileName);
            Assert.AreEqual("irrelevant type", actual.FileType);
            Assert.AreEqual("irrelevant path", actual.FilePath);
            Assert.AreEqual("irrelevant size", actual.FileSize);
            Assert.AreEqual("irrelevant date", actual.FileDate);
            Assert.AreEqual(100, actual.FileWidth);
            Assert.AreEqual(200, actual.FileHeight);
        }

        [TestMethod]
        public void GivenNullValues_CreateValidObjectWithEmptyStrings()
        {
            // Act
            var actual = new ImageFileInfo(null!, null!, null!, null!, null!, 100, 200);

            // Assert
            Assert.AreEqual(string.Empty, actual.FileName);
            Assert.AreEqual(string.Empty, actual.FileType);
            Assert.AreEqual(string.Empty, actual.FilePath);
            Assert.AreEqual(string.Empty, actual.FileSize);
            Assert.AreEqual(string.Empty, actual.FileDate);
            Assert.AreEqual(100, actual.FileWidth);
            Assert.AreEqual(200, actual.FileHeight);
        }
    }
}
