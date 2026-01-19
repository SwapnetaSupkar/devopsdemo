using System;
using System.IO;
using System.Text.Json;

public class User
{
    public string Name { get; set; }
    public DateTime Joined { get; set; }
}

public class NewSerializer
{
    public static void SaveUser(User user)
    {
        string json = JsonSerializer.Serialize(user);
        File.WriteAllText("user.json", json);
    }
}
