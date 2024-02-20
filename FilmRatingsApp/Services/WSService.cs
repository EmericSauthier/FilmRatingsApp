using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using FilmRatingsApp.Models;
using FilmRatingsApp.Services;

namespace FilmsRatingsApp.Services
{
    public class WSService : IService
    {
        private readonly HttpClient httpClient;

        public WSService(string uri)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(uri);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Utilisateur>> GetUtilisateursAsync(string nomControleur)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<List<Utilisateur>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Utilisateur> GetUtilisateurAsync(string nomControleur, string email)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<Utilisateur>(string.Concat(nomControleur, "/", email));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> PostUtilisateurAsync(string nomControleur, Utilisateur user)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<Utilisateur>(nomControleur, user);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> PutUtilisateurAsync(string nomControleur, Utilisateur user)
        {
            try
            {
                HttpResponseMessage response = await httpClient.PutAsJsonAsync(string.Concat(nomControleur, "/", user.UtilisateurId), user);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteUtilisateurAsync(string nomControleur, Utilisateur user)
        {
            try
            {
                HttpResponseMessage response = await httpClient.DeleteAsync(string.Concat(nomControleur, "/", user.UtilisateurId));
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
