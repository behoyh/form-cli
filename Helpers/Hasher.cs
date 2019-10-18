using System;
using System.Security.Cryptography;
using System.Text;

public static class Hasher
{
    public static Response<string> Hash(string toHash)
    {
        var hashString = "";
        using (var hash = SHA512.Create()){
            byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(toHash));  
            hashString = Convert.ToBase64String(bytes);
        }
        return new Response<string>()
        {
            Data = hashString
        };
    }
}