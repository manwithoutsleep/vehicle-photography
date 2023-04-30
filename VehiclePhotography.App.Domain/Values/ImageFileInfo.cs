using Windows.Storage.FileProperties;

namespace VehiclePhotography.App.Domain.Values
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
        public string ImageDimensions => string.Empty; // $"{FileWidth} x {FileHeight}";

        public ImageFileInfo(string fileName, string fileType, string filePath, string fileSize, string fileDate, int fileWidth, int fileHeight)
        {
            FileName = fileName;
            FileType = fileType;
            FilePath = filePath;
            FileSize = fileSize;
            FileDate = fileDate;
            FileWidth = fileWidth;
            FileHeight = fileHeight;
        }
    }
}
