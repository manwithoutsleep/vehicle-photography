// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using System;
using System.Collections.ObjectModel;
using VehiclePhotography.App.Domain.Values;
using VehiclePhotography.App.Domain.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace VehiclePhotography.App.WinUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private ObservableCollection<VehicleInfo> _vehicles = new ObservableCollection<VehicleInfo>();

        public MainWindow(MainWindowViewModel viewModel)
        {
            this.InitializeComponent();
            _vehicles = viewModel.GetVehicleList();
            VehicleGridView.ItemsSource = _vehicles;
        }
    }
}
