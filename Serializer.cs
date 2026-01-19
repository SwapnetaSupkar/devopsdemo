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
        // Bug: Not specifying JsonSerializerOptions for DateTime handling
        // This can cause issues with DateTime Kind (Local/UTC/Unspecified)
        // and may serialize differently on different systems
        string json = JsonSerializer.Serialize(user);
        File.WriteAllText("user.json", json);
    }
}
