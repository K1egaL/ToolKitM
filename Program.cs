using ToolKitM.UI;

namespace ToolKitM;

class Program
{
    static void Main()
    {
        ConsoleUI.Initialize();
        Menu.Show();
        ConsoleUI.Reset();
    }
}