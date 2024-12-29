using System.Text;

namespace Shared.Generator;

public static class RandomGenerator
{
    public static string RandomNumeric(int count)
    {
        if (count <= 0)
        {
            throw new ArgumentException("Count must be greater than zero");
        }

        Random random = new Random();
        StringBuilder result = new StringBuilder(count);

        for (int i = 0; i < count; i++)
        {
            // Append a random digit (0-9)
            result.Append(random.Next(0, 10));
        }

        return result.ToString();
    }
}
