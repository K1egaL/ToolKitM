using ToolKitM.Diagnostics;
using ToolKitM.Generator;
using ToolKitM.Help;
using ToolKitM.SystemInfo;

namespace ToolKitM.UI;

public static class Menu
{
    public static void Show()
    {
        while (true)
        {
            ConsoleUI.Clear();

            ConsoleUI.Header(
                "                ToolKitM ",
                "               msu. Alpha ");

            Console.ForegroundColor = ConsoleUI.SecondaryColor;
            Console.WriteLine("warning: custom software. not commercial!");
            Console.ForegroundColor = ConsoleUI.TextColor;
            Console.WriteLine();

            ConsoleUI.MenuItem("1", "PC Diagnostics");
            ConsoleUI.MenuItem("2", "Generator");
            ConsoleUI.MenuItem("3", "System Information");
            ConsoleUI.MenuItem("4", "Help & Troubleshooting");

            Console.WriteLine();

            ConsoleUI.MenuItem("0", "Exit");

            Console.WriteLine();
            ConsoleUI.Prompt("select option: ");
            ConsoleUI.Prompt("> ");

            string? option = Console.ReadLine()?.Trim().ToLowerInvariant();

            switch (option)
            {
                case "1":
                    PcDiagnostics.Show();
                    break;

                case "2":
                    ValueGenerator.Show();
                    break;

                case "3":
                    SystemInformation.Show();
                    break;

                case "4":
                    HelpAndTroubleshooting.Show();
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
}