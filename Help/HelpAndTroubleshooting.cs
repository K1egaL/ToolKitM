using ToolKitM.UI;

namespace ToolKitM.Help;

public static class HelpAndTroubleshooting
{
    public static void Show()
    {
        while (true)
        {
            ConsoleUI.Clear();

            ConsoleUI.Header(
                "HELP & TROUBLESHOOTING",
                "Useful guides and solutions");

            ConsoleUI.MenuItem("1", "Internet Problems");
            ConsoleUI.MenuItem("2", "PC Is Slow");
            ConsoleUI.MenuItem("3", "Wi-Fi Problems");
            ConsoleUI.MenuItem("4", "Browser Problems");
            ConsoleUI.MenuItem("5", "Windows Problems");
            ConsoleUI.MenuItem("6", "MAaI. Warning! Don't open");

            Console.WriteLine();

            ConsoleUI.MenuItem("0", "Back");

            Console.WriteLine();
            ConsoleUI.Prompt("select option: ");
            ConsoleUI.Prompt("> ");

            string? option =
                Console.ReadLine()?.Trim().ToLowerInvariant();

            switch (option)
            {
                case "1":
                    ShowInternetProblems();
                    break;

                case "2":
                    ShowSlowPc();
                    break;

                case "3":
                    ShowWifiProblems();
                    break;

                case "4":
                    ShowBrowserProblems();
                    break;

                case "5":
                    ShowWindowsProblems();
                    break;

                case "6":
                    ShowMainApps();
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

    private static void ShowInternetProblems()
    {
        ConsoleUI.Clear();

        ConsoleUI.Header(
            "PROBLEM: INTERNET",
            "Wired connection troubleshooting");

        Console.WriteLine(
            "что делать при проблемах с интернетом (относится к проводным).");
        Console.WriteLine();

        Console.WriteLine(
            "проверьте свой ethernet кабель. вдруг он порвался или не до конца вставлен.");

        Console.WriteLine(
            "если норм это, то проверьте что вы устанавливали драйвера WinDivert и службы, например amneizavpn-service или happ.service");

        Console.WriteLine(
            "если выяснится что все норм и вина этих служб (или других. ВНИМАНИЕ - УДАЛИТЕ ЛИШНИЕ СЛУЖБЫ, БУДУТ ПРОБЛЕМЫ С ВИНДОЙ), удалить: в zapret остановить в меню службы. остальное: ");

        Console.WriteLine(
            "Stop-Service -Name двойныекавычки НАЗВАНИЕ СЕРВИСА двойныекавычки -Force");

        Console.WriteLine(
            "можно узнать службу через команду в powershell: ");

        Console.WriteLine(
            " Get-Service | Where-Object {$_.Status -eq кавычкиRunningкавычки} | Where-Object {$_.Name -match кавычкиxray|sing|happ|incy|vpn|wire|tun|divertкавычки} | Format-Table -Auto Name,DisplayName,Status ");

        Console.WriteLine(
            "где xray, incy и тому подобное - укажите возможные названия служб, которые могли вызвать проблему. Но - это могли быть вирусы, не факт");

        ConsoleUI.Pause();
    }

    private static void ShowSlowPc()
    {
        ConsoleUI.Clear();

        ConsoleUI.Header(
            "PC SLOW?",
            "Performance troubleshooting");

        Console.WriteLine(
            "замедление пк /// топ причина ");
        Console.WriteLine();

        Console.WriteLine(
            "вы качали супер оптимизаторы, cleaner, или же какие то browser 2026 pro max super, или же какую то программу (например Pro Max Antivirus 2026 NOW)? ");

        Console.WriteLine(
            "если да, то это 1 причина замедления работы винды. например - скачали opera, yandex, chrome, и тому подобное");

        Console.WriteLine(
            "сами то браузеры норм, главное их настроить нормально");

        Console.WriteLine(
            "если какие то другие штуки, применяется правило: не качайте что попало, что есть в интернете, и подозрительное. вам кажется что это странный файл? не кажется.");

        Console.WriteLine(
            "лучше не качать, чем смотреть на экран где полный хаос происходит");

        ConsoleUI.Pause();
    }

    private static void ShowWifiProblems()
    {
        ConsoleUI.Clear();

        ConsoleUI.Header(
            "WI-FI PROBLEMS",
            "Wireless connection troubleshooting");

        Console.WriteLine(
            "проблема с wlan(wifi) ");
        Console.WriteLine();

        Console.WriteLine(
            "чек internet problems, пункт тут. возможно это поможет. возможно нестабильный/кривой/не рабочий драйвер для wlan, переустановить и/или установить новый стабильный драйвер на WLAN");

        ConsoleUI.Pause();
    }

    private static void ShowBrowserProblems()
    {
        ConsoleUI.Clear();

        ConsoleUI.Header(
            "BROWSERS PROBLEM",
            "Browser troubleshooting");

        Console.WriteLine(
            "проблема: не открывается что то, или плохо работает?");
        Console.WriteLine();

        Console.WriteLine(
            "проверьте, может вы dns сменили, чаще проблема в нем. если все сайты не открывает - скорее всего настройки безопасности");

        Console.WriteLine(
            "по скольку блокинг всех cookie может нарушить работу всех сайтов, в том числе расширения по типу Super Cleaner Max Pro");

        Console.WriteLine(
            "но, могут вызвать проблему и noscript расширение. оно норм, главное норм настроить.");

        ConsoleUI.Pause();
    }

    private static void ShowWindowsProblems()
    {
        ConsoleUI.Clear();

        ConsoleUI.Header(
            "WINDOWS PROBLEMS",
            "Windows troubleshooting");

        Console.WriteLine(
            "серьезно, винда лагает? онет");
        Console.WriteLine();

        Console.WriteLine(
            "возможно вы, устанавливая кастом сборку какой то файл удалили (критический, например для работы .NET приложений. лучше обычную windows, стабильную, с autounatted.xml файлом кастом");

        Console.WriteLine(
            "также если норм со сборкой, попробуйте подключится к интернету, и проверить (и если возможно, установить обновления), да и попробовать sfc /scannow или dism ниже:");

        Console.WriteLine(
            "чекает сост: DISM /Online /Cleanup-Image /CheckHealth . глубокая проверка: DISM /Online /Cleanup-Image /ScanHealth . чинит: DISM /Online /Cleanup-Image /RestoreHealth ");

        ConsoleUI.Pause();
    }
    private static void ShowMainApps()
    {
        ConsoleUI.Clear();

        ConsoleUI.Header(
            "Main Apps",
            "Windows apps");

        Console.WriteLine("основные приложения: Clash Verge, Happ, Firefox, CrystalDiskMark/CrystalDiskInfo, HWiNFO, Git, Uninstall Tool, Python >3.12, VSC, а также:");
        Console.WriteLine("Visual C++ Redistributable, DirectX, Microsoft WebView2 Runtime, .NET Desktop Runtime 8/9/10, DirectPlay, актуальные сертификаты безопасности.");
        Console.WriteLine("Несмотря на отозвание сертификатов доверенных издателей GlobalSign и других на сайтах РУ-банков, не стоит устанавливать неизвестные сертификаты, например: сертификат МинЦифры.");
        Console.WriteLine("По скольку может случится неприятная ситуация...");

        ConsoleUI.Pause();
    }
}