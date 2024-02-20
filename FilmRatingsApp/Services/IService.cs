using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmRatingsApp.Models;

namespace FilmRatingsApp.Services
{
    public interface IService
    {
        Task<List<Utilisateur>> GetUtilisateursAsync(string nomControleur);
        Task<Utilisateur> GetUtilisateurAsync(string nomControleur, string email);
        Task<bool> PostUtilisateurAsync(string nomControleur, Utilisateur user);
        Task<bool> PutUtilisateurAsync(string nomControleur, Utilisateur user);
        Task<bool> DeleteUtilisateurAsync(string nomControleur, Utilisateur user);
    }
}
