using System.Management;
using ToolKitM.UI;

namespace ToolKitM.SystemInfo;

public static class SystemInformation
{
    public static void Show()
    {
        ConsoleUI.Clear();

        ConsoleUI.Header(
            "SYSTEM INFORMATION",
            "Computer and operating system details");

        ShowOperatingSystem();
        ShowComputerInfo();
        ShowCpuInfo();
        ShowMemoryInfo();
        ShowUptime();

        ConsoleUI.Pause();
    }

    private static void ShowOperatingSystem()
    {
        ConsoleUI.WriteAccent("OPERATING SYSTEM");
        ConsoleUI.Separator();

        Console.WriteLine(
            $"Name:         {Environment.OSVersion}");

        Console.WriteLine(
            $"Architecture: {GetArchitecture()}");

        Console.WriteLine();
    }

    private static void ShowComputerInfo()
    {
        ConsoleUI.WriteAccent("COMPUTER");
        ConsoleUI.Separator();

        Console.WriteLine(
            $"Name:         {Environment.MachineName}");

        Console.WriteLine(
            $"User:         {Environment.UserName}");

        Console.WriteLine();
    }

    private static void ShowCpuInfo()
    {
        ConsoleUI.WriteAccent("CPU");
        ConsoleUI.Separator();

        try
        {
            using ManagementObjectSearcher searcher = new(
                "SELECT Name, NumberOfCores, NumberOfLogicalProcessors " +
                "FROM Win32_Processor");

            bool found = false;

            foreach (ManagementObject processor in searcher.Get())
            {
                found = true;

                string cpuName =
                    processor["Name"]?.ToString()?.Trim()
                    ?? "Unknown";

                string cores =
                    processor["NumberOfCores"]?.ToString()
                    ?? "Unknown";

                string logicalProcessors =
                    processor["NumberOfLogicalProcessors"]?.ToString()
                    ?? "Unknown";

                Console.WriteLine($"Name:         {cpuName}");
                Console.WriteLine($"Cores:        {cores}");
                Console.WriteLine($"Logical CPUs: {logicalProcessors}");

                break;
            }

            if (!found)
            {
                ConsoleUI.WriteWarning(
                    "CPU information was not found.");
            }
        }
        catch
        {
            ConsoleUI.WriteWarning(
                "CPU information is unavailable.");
        }

        Console.WriteLine();
    }

    private static void ShowMemoryInfo()
    {
        ConsoleUI.WriteAccent("MEMORY");
        ConsoleUI.Separator();

        try
        {
            using ManagementObjectSearcher searcher = new(
                "SELECT TotalVisibleMemorySize, FreePhysicalMemory " +
                "FROM Win32_OperatingSystem");

            bool found = false;

            foreach (ManagementObject os in searcher.Get())
            {
                found = true;

                ulong totalKb =
                    Convert.ToUInt64(
                        os["TotalVisibleMemorySize"]);

                ulong freeKb =
                    Convert.ToUInt64(
                        os["FreePhysicalMemory"]);

                double totalGb =
                    totalKb / 1024.0 / 1024.0;

                double freeGb =
                    freeKb / 1024.0 / 1024.0;

                double usedGb =
                    totalGb - freeGb;

                Console.WriteLine(
                    $"Total:        {totalGb:F2} GB");

                Console.WriteLine(
                    $"Used:         {usedGb:F2} GB");

                Console.WriteLine(
                    $"Free:         {freeGb:F2} GB");

                break;
            }

            if (!found)
            {
                ConsoleUI.WriteWarning(
                    "Memory information was not found.");
            }
        }
        catch
        {
            ConsoleUI.WriteWarning(
                "Memory information is unavailable.");
        }

        Console.WriteLine();
    }

    private static void ShowUptime()
    {
        ConsoleUI.WriteAccent("UPTIME");
        ConsoleUI.Separator();

        TimeSpan uptime =
            TimeSpan.FromMilliseconds(
                Environment.TickCount64);

        Console.WriteLine(
            $"Uptime:       {uptime.Days}d " +
            $"{uptime.Hours}h " +
            $"{uptime.Minutes}m");

        Console.WriteLine();
    }

    private static string GetArchitecture()
    {
        return Environment.Is64BitOperatingSystem
            ? "64-bit"
            : "32-bit";
    }
}