public class Response<T>{
    public bool Success {get;set;} = true;
    public string Message{get;set;}
    public T Data {get;set;}
}
public class Response{
    public bool Success {get;set;} = true;
    public string Message{get;set;}
}