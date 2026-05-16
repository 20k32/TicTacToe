using CommunityToolkit.Mvvm.DependencyInjection;
using Core.Services;
using Presentation.ViewModels.MainPage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Presentation
{
    public static class ServiceInitializer
    {
        public static void Initialize()
        {
            Core.Services.ServiceInitializer.Initialize(new MainViewModel());
        }
    }
}
