using Presentation.Miscellaneous;
using System.Configuration;
using System.Data;
using System.Windows;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Presentation.ServiceInitializer.Initialize();

            WindowHelper.MainWindow = new MainWindow();

            WindowHelper.MainWindow.Show();
        }
    }
}
