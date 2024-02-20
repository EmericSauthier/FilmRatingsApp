﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmRatingsApp.Models
{
    public partial class Film
    {
        public Film()
        {
            NotesFilm = new HashSet<Notation>();
        }

        public int FilmId
        {
            get; set;
        }
        public string Titre
        {
            get; set;
        }
        public string? Resume
        {
            get; set;
        }
        public DateTime? DateSortie
        {
            get; set;
        }
        public decimal? Duree
        {
            get; set;
        }
        public string? Genre
        {
            get; set;
        }
        public virtual ICollection<Notation> NotesFilm
        {
            get; set;
        }
    }
}