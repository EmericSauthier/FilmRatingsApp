using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmRatingsApp.Models
{
    public partial class Notation
    {
        public int UtilisateurId
        {
            get; set;
        }
        public int FilmId
        {
            get; set;
        }
        public int Note
        {
            get; set;
        }
        public Film FilmNote
        {
            get; set;
        }
        public Utilisateur UtilisateurNotant
        {
            get; set;
        }
    }
}