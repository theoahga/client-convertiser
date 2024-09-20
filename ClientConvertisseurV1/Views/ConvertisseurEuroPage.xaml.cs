using ClientConvertisseurV1.Services;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
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
            var devises = new List<Devise>();
            try
            {
                devises = await wsService.GetDevisesAsync("devises");
            }
            catch(Exception ex)
            {
                throw new Exception("L'api n'est pas accessible !");
            }

            this.CbxDevise.DataContext = new List<Devise>(devises);
        }

        private void BtnConvertir_Click(object sender, RoutedEventArgs e)
        {
            Devise devise = (Devise) this.CbxDevise.SelectedItem;
            if (devise == null) {
                throw new Exception("Il faut choisir une devise vers laquelle convertir!");
            }

            var result = 0.0;
            try
            {
                result = Convert.ToDouble(this.Second.Text) * devise.Taux;
            } catch(FormatException ex)
            {
                throw new Exception("Le montant passé n'est pas un nombre décimal !");
            }

            this.Seven.Text = Convert.ToString(result);
        }
    }
}
