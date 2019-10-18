using System.Threading.Tasks;

public static class Init
{
    public static async Task<Response> Create(string file)
    {
        await FileWriter.Write("./", file);

        return new Response();
    }
}