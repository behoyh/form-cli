using System.IO;
using System.Threading.Tasks;

public static class FileWriter
{
    public static async Task Write(string path, string text)
    {
        await File.WriteAllTextAsync(path,text);
    }
}