﻿using ClientConvertisseurV1.Services;
using ClientConvertisseurV1.Views;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientConvertisseurV1
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();

            Frame rootFrame = new Frame();
            this.m_window.Content = rootFrame;
            m_window.Activate();
            this.UnhandledException += App_UnhandledException;
            rootFrame.Navigate(typeof(ConvertisseurEuroPage));
        }

        private Window m_window;
        private async void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            await DialogService.OpenDialog(m_window.Content.XamlRoot, "Erreur", e.Message, "OK");
        }
    }
}
