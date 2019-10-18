using System.IO;
using System.Threading.Tasks;

public static class FileReader
{
    public static async Task<Response<string>> Read(string filePath)
    {
        return new Response<string>()
        {
            Data = await File.ReadAllTextAsync(filePath)
        };
    }
}