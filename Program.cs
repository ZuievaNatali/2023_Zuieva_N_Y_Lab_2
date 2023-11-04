using Lab2.Models;
using Lab2;
using Gtk;

internal class Program
{
    private static void Main(string[] args)
    {
        Application.Init ();
        var mainWindow = new MainWindow();
        mainWindow.ShowAll();
        Application.Run();
    }
}