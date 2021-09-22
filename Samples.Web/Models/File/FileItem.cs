namespace Samples.Web.Models.File
{
    public class FileItem
    {
        public FileItem(string name, long size)
        {
            Name = name;
            Size = (size < 1024) ? $"{size} B" : $"{size / 1000} KB";
        }
        public string Name { get; set; }
        public string Size { get; set; }
    }
}
