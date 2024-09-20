using ClientConvertisseurV1.Services;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WSConvertisseur.Models;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientConvertisseurV1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConvertisseurEuroPage : Page
    {
        private WSService wsService;
        public ConvertisseurEuroPage()
        {
            this.InitializeComponent();
            wsService = WSService.GetInstance();
            ActionGetDataAsync();
        }

        private async void ActionGetDataAsync()
        {
            var result = await wsService.GetDevisesAsync("devises");
            this.CbxDevise.DataContext = new List<Devise>(result);
        }

        private void BtnConvertir_Click(object sender, RoutedEventArgs e)
        {
            Devise devise = (Devise) this.CbxDevise.SelectedItem;
            var result = 0.0;
            try
            {
                result = Convert.ToDouble(this.Second.Text) * devise.Taux;
            } catch(FormatException ex)
            {
                Console.WriteLine(ex);
            }
            this.Seven.Text = Convert.ToString(result);
        }
    }
}
