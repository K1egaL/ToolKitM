namespace ToolKitM.UI;

public static class ConsoleUI
{
    public static readonly ConsoleColor AccentColor = ConsoleColor.Magenta;
    public static readonly ConsoleColor SecondaryColor = ConsoleColor.DarkGray;
    public static readonly ConsoleColor TextColor = ConsoleColor.Gray;
    public static readonly ConsoleColor SuccessColor = ConsoleColor.Green;
    public static readonly ConsoleColor WarningColor = ConsoleColor.Yellow;
    public static readonly ConsoleColor ErrorColor = ConsoleColor.Red;
    public static readonly ConsoleColor InfoColor = ConsoleColor.Cyan;

    public static void Initialize()
    {
        Console.Title = "ToolKitM";
        Console.CursorVisible = true;
    }

    public static void Clear()
    {
        Console.Clear();
        Console.ForegroundColor = TextColor;
    }

    public static void Header(string title, string? subtitle = null)
    {
        Console.ForegroundColor = AccentColor;

        Console.WriteLine("╔══════════════════════════════════════════════╗");
        Console.Write("║");

        WritePaddedRight(title, 44);

        Console.WriteLine(" ║");

        if (!string.IsNullOrWhiteSpace(subtitle))
        {
            Console.ForegroundColor = SecondaryColor;
            Console.Write("║");

            WritePaddedRight(subtitle, 44);

            Console.WriteLine(" ║");
        }

        Console.ForegroundColor = AccentColor;
        Console.WriteLine("╚══════════════════════════════════════════════╝");

        Console.ForegroundColor = TextColor;
        Console.WriteLine();
    }

    public static void MenuItem(string key, string text)
    {
        Console.ForegroundColor = AccentColor;
        Console.Write($"[{key}] ");

        Console.ForegroundColor = TextColor;
        Console.WriteLine(text);
    }

    public static void Prompt(string text)
    {
        Console.ForegroundColor = TextColor;
        Console.Write(text);
    }

    public static void WriteAccent(string text)
    {
        Console.ForegroundColor = AccentColor;
        Console.WriteLine(text);
        Console.ForegroundColor = TextColor;
    }

    public static void WriteInfo(string text)
    {
        Console.ForegroundColor = InfoColor;
        Console.WriteLine($"[INFO] {text}");
        Console.ForegroundColor = TextColor;
    }

    public static void WriteSuccess(string text)
    {
        Console.ForegroundColor = SuccessColor;
        Console.WriteLine($"[ OK ] {text}");
        Console.ForegroundColor = TextColor;
    }

    public static void WriteWarning(string text)
    {
        Console.ForegroundColor = WarningColor;
        Console.WriteLine($"[WARN] {text}");
        Console.ForegroundColor = TextColor;
    }

    public static void WriteError(string text)
    {
        Console.ForegroundColor = ErrorColor;
        Console.WriteLine($"[ERR ] {text}");
        Console.ForegroundColor = TextColor;
    }

    public static void Separator()
    {
        Console.ForegroundColor = SecondaryColor;
        Console.WriteLine("────────────────────────────────────────────────");
        Console.ForegroundColor = TextColor;
    }

    public static void Pause()
    {
        Console.WriteLine();
        Console.ForegroundColor = SecondaryColor;
        Console.Write("press any key to return...");
        Console.ForegroundColor = TextColor;

        Console.ReadKey(true);
    }

    public static void Reset()
    {
        Console.ResetColor();
    }

    private static void WritePaddedRight(string text, int width)
    {
        if (text.Length > width)
            text = text[..width];

        Console.Write(text.PadRight(width));
    }
}