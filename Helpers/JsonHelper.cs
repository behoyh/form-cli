using Newtonsoft.Json;

public class JsonHelper {
    
    public Response<string> Serialize(object input){
        
        return new Response<string>() {
            Data = JsonConvert.SerializeObject(input)
        };
    }

    public Response<dynamic> Deserialize(string jsonObj)
    {
        dynamic obj = JsonConvert.DeserializeObject(jsonObj);

        return new Response<dynamic>() {
            Data = obj
        };
    }

}