
namespace VehiclePhotography.App.Models.Values
{
    public class ImageFileInfo
    {
        public string FileName { get; }
        public string FileType { get; }
        public string FilePath { get; }
        public string FileSize { get; }
        public string FileDate { get; }
        public int FileWidth { get; }
        public int FileHeight { get; }
        public string ImageDimensions => $"{FileWidth} x {FileHeight}";

        public ImageFileInfo(string fileName, string fileType, string filePath, string fileSize, string fileDate, int fileWidth, int fileHeight)
        {
            FileName = fileName ?? string.Empty;
            FileType = fileType ?? string.Empty;
            FilePath = filePath ?? string.Empty;
            FileSize = fileSize ?? string.Empty;
            FileDate = fileDate ?? string.Empty;
            FileWidth = fileWidth;
            FileHeight = fileHeight;
        }
    }
}
