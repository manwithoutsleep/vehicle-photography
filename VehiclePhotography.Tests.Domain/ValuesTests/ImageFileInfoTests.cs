using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehiclePhotography.App.Domain.Values;

namespace VehiclePhotography.Tests.Domain.ValuesTests
{
    [TestClass()]
    public class ImageFileInfoTests
    {
        [TestMethod]
        public void GivenValidWidthAndHeight_ReturnStringRepresentation()
        {
            // Arrange
            var width = 100;
            var height = 200;
            var imageFileInfo = new ImageFileInfo("irrelevant name", "irrelevant type", "irrelelvant path", "irrelevant size", "irrelevant date", width, height);

            // Act
            var actual = imageFileInfo.ImageDimensions;

            // Assert
            Assert.AreEqual($"{width} x {height}", actual);
        }
    }
}
