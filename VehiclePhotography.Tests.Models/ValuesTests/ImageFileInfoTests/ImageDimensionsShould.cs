using VehiclePhotography.App.Models.Values;

namespace VehiclePhotography.Tests.Models.ValuesTests.ImageFileInfoTests
{
    [TestClass()]
    public class ImageDimensionsShould
    {
        [TestMethod()]
        public void GivenValidWidthAndHeight_ReturnStringRepresentation()
        {
            // Arrange
            var width = 100;
            var height = 200;
            var imageFileInfo = new ImageFileInfo("irrelevant name", "irrelevant type", "irrelevant path", "irrelevant size", "irrelevant date", width, height);

            // Act
            var actual = imageFileInfo.ImageDimensions;

            // Assert
            Assert.AreEqual($"{width} x {height}", actual);
        }
    }
}
