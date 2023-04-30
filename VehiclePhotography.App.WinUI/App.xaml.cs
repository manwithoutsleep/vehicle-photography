// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using System;
using VehiclePhotography.App.DAO.Interfaces;
using VehiclePhotography.App.DAO.Services;
using VehiclePhotography.App.Domain.ViewModels;
using VehiclePhotography.App.WinUI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        private Window m_window;
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            Services = ConfigureServices();
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            var viewModel = Services.GetService<MainWindowViewModel>();
            m_window = new MainWindow(viewModel);
            m_window.Activate();
        }

        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<IVehicleInfoDao, NhtsaVehicleApiDao>();


            return services.BuildServiceProvider();
        }
    }
}
