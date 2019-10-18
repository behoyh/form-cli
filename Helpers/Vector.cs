using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

public static class Vector
{
    public static async Task<Response<string>> CreateGenesisBlock(this string[] filenames) {

        var jsonArray = new JArray();

        foreach(var file in filenames)
        {
            var result = await FileReader.Read(file);

            if (!result.Success)
            {
                return new Response<string>()
                {
                    Success = false,
                    Message = result.Message
                };
            }

            jsonArray.Add(result.Data);
        }

        var jsonString = JsonConvert.SerializeObject(jsonArray);

        var hash = Hasher.Hash(jsonString);

        if (!hash.Success)
        {
            return new Response<string>
            {
                Success = false,
                Message = "Failed to hash block."
            };
        }

        var s = new Struct {
            Date = DateTime.Now,
            Hash = hash.Data,
            PreviousHash = null,
            Data = jsonString
        };

        return new Response<string>
        {
            Data = JsonConvert.SerializeObject(s)
        };
    }
}