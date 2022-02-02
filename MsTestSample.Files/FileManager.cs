namespace MsTestSample.Files
{
    public class FileManager
    {
        public bool FileExists(string filepath)
        {
            if (string.IsNullOrWhiteSpace(filepath))            
                throw new ArgumentNullException(nameof(filepath));
            
            return File.Exists(filepath);
        }       
    }
}