using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WSConvertisseur.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ClientConvertisseurV1.Services
{
    internal class WSService : IService
    {
        private HttpClient HttpClient { get; set; }
        private static WSService instance;
        private WSService(String uri)
        {
            HttpClient = new HttpClient();
            //http://localhost:7223/api/
            HttpClient.BaseAddress = new Uri(uri);
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Devise>> GetDevisesAsync(string nomControleur)
        {
            try
            {
                return await HttpClient.GetFromJsonAsync<List<Devise>>(nomControleur);
            }
            catch (Exception)
            {
                return null;

            }
        }

        public WSService GetInstance()
        {
            if (instance == null)
            {
                instance = new WSService("http://localhost:7223/api/");
                return instance;
            }
            return instance;
        }
    }
}
