using System;
using System.IO;
using System.Text.Json;

public class User
{
    public string Name { get; set; }
    public DateTime Joined { get; set; }
}

public static class Serializer
{
    public static void SaveUser(User user)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
            // DateTime is serialized in ISO 8601 format by default in System.Text.Json
        };
        
        string json = JsonSerializer.Serialize(user, options);
        File.WriteAllText("user.json", json);
    }
}
