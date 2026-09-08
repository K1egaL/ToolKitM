using System.Net;
using System.Net.NetworkInformation;
using ToolKitM.UI;

namespace ToolKitM.Diagnostics;

public static class PcDiagnostics
{
    public static void Show()
    {
        while (true)
        {
            ConsoleUI.Clear();

            ConsoleUI.Header(
                "PC DIAGNOSTICS",
                "Network tools");

            ConsoleUI.MenuItem("1", "Network Adapters");
            ConsoleUI.MenuItem("2", "DNS Information");
            ConsoleUI.MenuItem("3", "Active Connections");
            ConsoleUI.MenuItem("4", "Ping Test");
            ConsoleUI.MenuItem("5", "Full Network Check");

            Console.WriteLine();

            ConsoleUI.MenuItem("0", "Back");

            Console.WriteLine();
            ConsoleUI.Prompt("select option: ");
            ConsoleUI.Prompt("> ");

            string? option = Console.ReadLine()?.Trim().ToLowerInvariant();

            switch (option)
            {
                case "1":
                    ShowNetworkAdapters();
                    break;

                case "2":
                    ShowDnsInformation();
                    break;

                case "3":
                    ShowActiveConnections();
                    break;

                case "4":
                    RunPingTest();
                    break;

                case "5":
                    RunFullNetworkCheck();
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

    private static void ShowNetworkAdapters()
    {
        ConsoleUI.Clear();

        ConsoleUI.Header(
            "NETWORK ADAPTERS",
            "Available network interfaces");

        NetworkInterface[] adapters =
            NetworkInterface.GetAllNetworkInterfaces();

        if (adapters.Length == 0)
        {
            ConsoleUI.WriteWarning("No network adapters found.");
            ConsoleUI.Pause();
            return;
        }

        foreach (NetworkInterface adapter in adapters)
        {
            Console.ForegroundColor = ConsoleUI.AccentColor;
            Console.WriteLine(adapter.Name);
            Console.ForegroundColor = ConsoleUI.TextColor;

            Console.WriteLine($"Type:   {adapter.NetworkInterfaceType}");
            Console.WriteLine($"Status: {adapter.OperationalStatus}");

            ConsoleUI.Separator();
        }

        ConsoleUI.Pause();
    }

    private static void ShowDnsInformation()
    {
        ConsoleUI.Clear();

        ConsoleUI.Header(
            "DNS INFORMATION",
            "Configured DNS servers");

        NetworkInterface[] adapters =
            NetworkInterface.GetAllNetworkInterfaces();

        bool foundDns = false;

        foreach (NetworkInterface adapter in adapters)
        {
            IPInterfaceProperties properties =
                adapter.GetIPProperties();

            IPAddressCollection dnsServers =
                properties.DnsAddresses;

            if (dnsServers.Count == 0)
                continue;

            foundDns = true;

            Console.ForegroundColor = ConsoleUI.AccentColor;
            Console.WriteLine(adapter.Name);
            Console.ForegroundColor = ConsoleUI.TextColor;

            Console.WriteLine($"Status: {adapter.OperationalStatus}");
            Console.WriteLine();
            Console.WriteLine("DNS Servers:");

            foreach (IPAddress dns in dnsServers)
            {
                Console.WriteLine($"  {dns}");
            }

            Console.WriteLine();
            ConsoleUI.Separator();
        }

        if (!foundDns)
        {
            ConsoleUI.WriteWarning("No DNS servers were found.");
        }

        Console.WriteLine();
        Console.ForegroundColor = ConsoleUI.AccentColor;
        Console.WriteLine("DNS RESOLUTION TEST");
        Console.ForegroundColor = ConsoleUI.TextColor;

        ConsoleUI.Separator();

        string[] testHosts =
        {
            "google.com",
            "github.com",
            "microsoft.com"
        };

        foreach (string host in testHosts)
        {
            try
            {
                IPAddress[] addresses =
                    Dns.GetHostAddresses(host);

                if (addresses.Length > 0)
                {
                    ConsoleUI.WriteSuccess($"{host}");
                }
                else
                {
                    ConsoleUI.WriteError($"{host}");
                }
            }
            catch
            {
                ConsoleUI.WriteError($"{host}");
            }
        }

        ConsoleUI.Pause();
    }

    private static void ShowActiveConnections()
    {
        ConsoleUI.Clear();

        ConsoleUI.Header(
            "ACTIVE CONNECTIONS",
            "Current TCP connections");

        IPGlobalProperties properties =
            IPGlobalProperties.GetIPGlobalProperties();

        TcpConnectionInformation[] connections =
            properties.GetActiveTcpConnections();

        if (connections.Length == 0)
        {
            ConsoleUI.WriteInfo("No active TCP connections found.");
            ConsoleUI.Pause();
            return;
        }

        ConsoleUI.WriteInfo(
            $"Active TCP connections: {connections.Length}");

        Console.WriteLine();

        foreach (TcpConnectionInformation connection in connections)
        {
            Console.ForegroundColor = ConsoleUI.AccentColor;
            Console.WriteLine("Connection");
            Console.ForegroundColor = ConsoleUI.TextColor;

            Console.WriteLine(
                $"Local:  {connection.LocalEndPoint}");

            Console.WriteLine(
                $"Remote: {connection.RemoteEndPoint}");

            Console.WriteLine(
                $"State:  {connection.State}");

            ConsoleUI.Separator();
        }

        ConsoleUI.Pause();
    }

    private static void RunPingTest()
    {
        ConsoleUI.Clear();

        ConsoleUI.Header(
            "PING TEST",
            "Test host connectivity, on TCP");

        ConsoleUI.Prompt("Enter host: ");
        string? host = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(host))
        {
            ConsoleUI.WriteWarning("Host cannot be empty.");
            ConsoleUI.Pause();
            return;
        }

        using Ping ping = new();

        try
        {
            PingReply reply = ping.Send(host, 3000);

            Console.WriteLine();

            if (reply.Status == IPStatus.Success)
            {
                ConsoleUI.WriteSuccess(
                    $"Reply from {host}");

                Console.WriteLine(
                    $"Time: {reply.RoundtripTime} ms");

                if (reply.Address is not null)
                {
                    Console.WriteLine(
                        $"Address: {reply.Address}");
                }
            }
            else
            {
                ConsoleUI.WriteError(
                    $"Ping failed: {reply.Status}");
            }
        }
        catch (Exception ex)
        {
            ConsoleUI.WriteError(ex.Message);
        }

        ConsoleUI.Pause();
    }

    private static void RunFullNetworkCheck()
    {
        ConsoleUI.Clear();

        ConsoleUI.Header(
            "FULL NETWORK CHECK",
            "Quick connection test");

        bool networkOk = false;
        bool dnsOk = false;
        bool internetOk = false;

        ConsoleUI.WriteInfo("Checking network adapter...");

        NetworkInterface[] adapters =
            NetworkInterface.GetAllNetworkInterfaces();

        foreach (NetworkInterface adapter in adapters)
        {
            if (adapter.OperationalStatus == OperationalStatus.Up &&
                adapter.NetworkInterfaceType != NetworkInterfaceType.Loopback)
            {
                networkOk = true;
                break;
            }
        }

        if (networkOk)
            ConsoleUI.WriteSuccess("Network adapter is active.");
        else
            ConsoleUI.WriteError("No active network adapter found.");

        ConsoleUI.WriteInfo("Checking DNS resolution...");

        try
        {
            IPAddress[] addresses =
                Dns.GetHostAddresses("google.com");

            dnsOk = addresses.Length > 0;
        }
        catch
        {
            dnsOk = false;
        }

        if (dnsOk)
            ConsoleUI.WriteSuccess("DNS resolution is working.");
        else
            ConsoleUI.WriteError("DNS resolution failed.");

        ConsoleUI.WriteInfo("Checking Internet connection...");

        using Ping ping = new();

        try
        {
            PingReply reply =
                ping.Send("1.1.1.1", 3000);

            internetOk =
                reply.Status == IPStatus.Success;
        }
        catch
        {
            internetOk = false;
        }

        if (internetOk)
            ConsoleUI.WriteSuccess("Internet connection is working.");
        else
            ConsoleUI.WriteError("Internet connection failed.");

        Console.WriteLine();
        ConsoleUI.Separator();

        if (networkOk && dnsOk && internetOk)
        {
            ConsoleUI.WriteSuccess(
                "NETWORK STATUS: OK");
        }
        else
        {
            ConsoleUI.WriteWarning(
                "NETWORK STATUS: PROBLEM");
        }

        ConsoleUI.Pause();
    }
}