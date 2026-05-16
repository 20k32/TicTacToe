using CommunityToolkit.Mvvm.DependencyInjection;
using Core.Interfaces.Presentation;
using System.Drawing;

namespace Core.Services
{
    public class ServiceLocator
    {
        public static IMainViewModel MainViewModel => Ioc.Default.GetRequiredService<IMainViewModel>();
    }
}
