using System.IO;
using System.Threading.Tasks;

public static class FileWriter
{
    public static async Task Write(string filename, string text, string path = null)
    {
        if (path != null)
        {
            var dir = Directory.CreateDirectory(path);
            await File.WriteAllTextAsync($"{dir.FullName}/{filename}", text);
            return;
        }
        else
        {
            await File.WriteAllTextAsync(filename, text);
        }
    }
}