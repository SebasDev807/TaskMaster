using System.Text.Json;

namespace App.Utils;

public class TaskUtils
{
    public static string GenerateId() =>
         Guid.NewGuid().ToString("N")[..7]; //guid[..7] → "d3b0738"   (desde el inicio hasta el índice 7)

    public static string ReadTaskValue(string message = "Ingrese el valor")
    {
        Write($"{message}: ");
        return ReadLine()!;
    }

}