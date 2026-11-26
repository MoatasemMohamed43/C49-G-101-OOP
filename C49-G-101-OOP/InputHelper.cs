namespace C49_G_101_OOP;

public static class InputHelper
{
    public static int ReadInt(string prompt, int min, int max)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                return value;
            Console.WriteLine("Invalid,try again: ");
        }
    }

    public static string ReadString(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string? text = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(text))
                return text.Trim();
            Console.WriteLine("  can't be empty ");
        }
    }

    public static bool ReadYesNo(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string? s = Console.ReadLine()?.Trim().ToUpper();
            if (s == "Y") return true;
            if (s == "N") return false;
            Console.WriteLine(" Y / N");

        }
    }
}
