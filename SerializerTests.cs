using System;
using System.IO;
using System.Text.Json;
using NUnit.Framework;

[TestFixture]
public class SerializerTests
{
    private const string TestFilePath = "user.json";

    [TearDown]
    public void TearDown()
    {
        // Clean up the test file after each test
        if (File.Exists(TestFilePath))
        {
            File.Delete(TestFilePath);
        }
    }

    [Test]
    public void SaveUser_ShouldSerializeUserCorrectly()
    {
        // Arrange
        var testUser = new User
        {
            Name = "John Doe",
            Joined = new DateTime(2026, 1, 15, 10, 30, 0, DateTimeKind.Utc)
        };

        // Act
        Serializer.SaveUser(testUser);

        // Assert
        Assert.IsTrue(File.Exists(TestFilePath), "user.json file should be created");

        // Read and deserialize the file
        string jsonContent = File.ReadAllText(TestFilePath);
        var deserializedUser = JsonSerializer.Deserialize<User>(jsonContent);

        // Verify the deserialized data matches the original
        Assert.IsNotNull(deserializedUser, "Deserialized user should not be null");
        Assert.AreEqual(testUser.Name, deserializedUser.Name, "Name should match");
        Assert.AreEqual(testUser.Joined, deserializedUser.Joined, "Joined DateTime should match");

        // Verify ISO 8601 format in JSON
        Assert.IsTrue(jsonContent.Contains("2026-01-15T10:30:00"), 
            "DateTime should be in ISO 8601 format (YYYY-MM-DDTHH:mm:ss)");
    }

    [Test]
    public void SaveUser_ShouldCreateReadableJson()
    {
        // Arrange
        var testUser = new User
        {
            Name = "Jane Smith",
            Joined = DateTime.Now
        };

        // Act
        Serializer.SaveUser(testUser);

        // Assert
        string jsonContent = File.ReadAllText(TestFilePath);
        
        // Verify the JSON is indented (contains newlines)
        Assert.IsTrue(jsonContent.Contains("\n"), "JSON should be indented");
        Assert.IsTrue(jsonContent.Contains("Name"), "JSON should contain Name property");
        Assert.IsTrue(jsonContent.Contains("Joined"), "JSON should contain Joined property");
    }
}
