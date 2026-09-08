using System.Diagnostics;
using System.Security.Cryptography;
using ToolKitM.UI;

namespace ToolKitM.Generator;

public static class ValueGenerator
{
    public static void Show()
    {
        while (true)
        {
            ConsoleUI.Clear();

            ConsoleUI.Header(
                "GENERATOR",
                "Random value generator");

            ConsoleUI.MenuItem("1", "Generate Value");

            Console.WriteLine();

            ConsoleUI.MenuItem("0", "Back");

            Console.WriteLine();
            ConsoleUI.Prompt("select option: ");
            ConsoleUI.Prompt("> ");

            string? option = Console.ReadLine()?.Trim().ToLowerInvariant();

            switch (option)
            {
                case "1":
                    Generate();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine();
                    ConsoleUI.WriteWarning("unknown option.");
                    ConsoleUI.Pause();
                    break;
            }
        }
    }

    private static void Generate()
    {
        ConsoleUI.Clear();

        ConsoleUI.Header(
            "VALUE GENERATOR",
            "Create a random value");

        int length = ReadLength();

        Console.WriteLine();

        bool useUppercase =
            ReadYesNo("use uppercase letters? [Y/N]: ");

        bool useLowercase =
            ReadYesNo("use lowercase letters? [Y/N]: ");

        bool useNumbers =
            ReadYesNo("use numbers?           [Y/N]: ");

        bool useSymbols =
            ReadYesNo("use special symbols?   [Y/N]: ");

        if (!useUppercase &&
            !useLowercase &&
            !useNumbers &&
            !useSymbols)
        {
            Console.WriteLine();
            ConsoleUI.WriteWarning(
                "At least one character type must be enabled.");

            ConsoleUI.Pause();
            return;
        }

        const string uppercase =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        const string lowercase =
            "abcdefghijklmnopqrstuvwxyz";

        const string numbers =
            "0123456789";

        const string symbols =
            "!@#$%^&*()-_=+[]{};:,.?/";

        string characters = string.Empty;

        if (useUppercase)
            characters += uppercase;

        if (useLowercase)
            characters += lowercase;

        if (useNumbers)
            characters += numbers;

        if (useSymbols)
            characters += symbols;

        int requiredTypes = GetRequiredCharacterCount(
            useUppercase,
            useLowercase,
            useNumbers,
            useSymbols);

        if (length < requiredTypes)
        {
            Console.WriteLine();

            ConsoleUI.WriteWarning(
                $"Length must be at least {requiredTypes}.");

            ConsoleUI.Pause();
            return;
        }

        List<char> result = new(length);

        if (useUppercase)
            result.Add(GetRandomCharacter(uppercase));

        if (useLowercase)
            result.Add(GetRandomCharacter(lowercase));

        if (useNumbers)
            result.Add(GetRandomCharacter(numbers));

        if (useSymbols)
            result.Add(GetRandomCharacter(symbols));

        while (result.Count < length)
        {
            result.Add(
                GetRandomCharacter(characters));
        }

        Shuffle(result);

        string value = new(result.ToArray());

        Console.WriteLine();

        ConsoleUI.WriteSuccess("Value generated.");

        Console.WriteLine();

        ConsoleUI.WriteAccent(value);

        Console.WriteLine();

        Console.WriteLine($"Length:   {value.Length}");
        Console.WriteLine(
            $"Strength: {GetStrength(length, characters.Length)}");

        Console.WriteLine();
        ConsoleUI.Separator();

        Console.WriteLine();

        ConsoleUI.Prompt("copy to clipboard? [Y/N]: ");

        string? copyAnswer =
            Console.ReadLine()?.Trim();

        if (string.Equals(
            copyAnswer,
            "y",
            StringComparison.OrdinalIgnoreCase))
        {
            CopyToClipboard(value);
        }
        else if (!string.Equals(
                     copyAnswer,
                     "n",
                     StringComparison.OrdinalIgnoreCase))
        {
            ConsoleUI.WriteWarning(
                "Unknown option. Value was not copied.");
        }

        ConsoleUI.Pause();
    }

    private static int GetRequiredCharacterCount(
        bool useUppercase,
        bool useLowercase,
        bool useNumbers,
        bool useSymbols)
    {
        int count = 0;

        if (useUppercase)
            count++;

        if (useLowercase)
            count++;

        if (useNumbers)
            count++;

        if (useSymbols)
            count++;

        return count;
    }

    private static char GetRandomCharacter(
        string characters)
    {
        if (string.IsNullOrEmpty(characters))
        {
            throw new ArgumentException(
                "Character set cannot be empty.",
                nameof(characters));
        }

        int index =
            RandomNumberGenerator.GetInt32(
                characters.Length);

        return characters[index];
    }

    private static void Shuffle(List<char> characters)
    {
        for (int i = characters.Count - 1; i > 0; i--)
        {
            int j =
                RandomNumberGenerator.GetInt32(i + 1);

            (characters[i], characters[j]) =
                (characters[j], characters[i]);
        }
    }

    private static string GetStrength(
        int length,
        int characterSetSize)
    {
        if (length <= 0 ||
            characterSetSize <= 1)
        {
            return "Weak";
        }

        double entropy =
            length * Math.Log2(characterSetSize);

        return entropy switch
        {
            < 40 => "Weak",
            < 60 => "Medium",
            < 80 => "Strong",
            _ => "Very Strong"
        };
    }

    private static int ReadLength()
    {
        while (true)
        {
            ConsoleUI.Prompt("length: ");

            string? input =
                Console.ReadLine();

            if (int.TryParse(
                    input,
                    out int length) &&
                length > 0)
            {
                return length;
            }

            ConsoleUI.WriteWarning(
                "Enter a valid positive number.");
        }
    }

    private static bool ReadYesNo(string message)
    {
        while (true)
        {
            ConsoleUI.Prompt(message);

            string? input =
                Console.ReadLine()?.Trim();

            if (string.Equals(
                input,
                "y",
                StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (string.Equals(
                input,
                "n",
                StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            ConsoleUI.WriteWarning(
                "Enter Y or N.");
        }
    }

    private static void CopyToClipboard(string value)
    {
        try
        {
            using Process process = new();

            process.StartInfo = new ProcessStartInfo
            {
                FileName = "clip.exe",
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            process.Start();

            process.StandardInput.Write(value);
            process.StandardInput.Close();

            process.WaitForExit();

            if (process.ExitCode == 0)
            {
                ConsoleUI.WriteSuccess(
                    "Value copied to clipboard.");
            }
            else
            {
                ConsoleUI.WriteError(
                    "Failed to copy value to clipboard.");
            }
        }
        catch
        {
            ConsoleUI.WriteError(
                "Failed to copy value to clipboard.");
        }
    }
}