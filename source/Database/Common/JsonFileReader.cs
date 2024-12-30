using System.Text.Json;

namespace TMS.Database.Common;

public class JsonFileReader
{
    public static async Task<T> ReadJsonFileAsync<T>(string filePath)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true, // Allow case-insensitive matching
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase // Set camelCase naming policy
            };

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                return await JsonSerializer.DeserializeAsync<T>(fs , options);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            throw;
        }
    }

    // Synchronous method to read JSON file and deserialize it to a C# object
    public static T ReadJsonFile<T>(string filePath)
    {
        try
        {

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true, // Allow case-insensitive matching
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase // Set camelCase naming policy
            };

            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(jsonString , options);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            throw;
        }
    }
}
