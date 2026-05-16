using CommunityToolkit.Mvvm.DependencyInjection;
using Core.Interfaces.Presentation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public static class ServiceInitializer
    {
        private static void InitializeViewModels(IMainViewModel viewModel, ServiceCollection services)
        {
            services.AddSingleton(viewModel);
        }

        public static void Initialize(IMainViewModel mainViewModel)
        {
            Constants.InitializeConstantsOnUiThread();

            var serviceCollection = new ServiceCollection();

            InitializeViewModels(mainViewModel, serviceCollection);
            serviceCollection.AddSingleton<ServiceLocator>();

            var provider = serviceCollection.BuildServiceProvider();
            Ioc.Default.ConfigureServices(provider);
        }
    }
}
