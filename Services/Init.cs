using System.Threading.Tasks;

public static class Init
{
    public static async Task<Response> Create(string[] filenames)
    {

        var block = await filenames.CreateGenesisBlock();

        if (!block.Success)
        {
            return new Response()
            {
                Success = true,
                Message = block.Message
            };
        }

        await FileWriter.Write("./Formfile", "{}");
        await FileWriter.Write("genesis-block", block.Data, "deploy-ledger");

        return new Response();
    }
}