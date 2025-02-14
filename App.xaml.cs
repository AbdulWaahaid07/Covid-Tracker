﻿using CovidAnalysis.Services.API;
using CovidAnalysis.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CovidAnalysis
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override async void OnStartup(StartupEventArgs e)
        {

            MainWindow mainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()
            };

            mainWindow.Show();

            base.OnStartup(e);
        }

    }
}
