using System.IO;
using System.Threading.Tasks;

public class FileReader
{
    public async Task<Response<string>> Read(string filePath)
    {
        return new Response<string>()
        {
            Data = await File.ReadAllTextAsync(filePath)
        };
    }
}