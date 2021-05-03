using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shows4AllMicaela.Data
{
    //public enum Genre
    //{
    //    Comedy,
    //    Horror,
    //    Action,
    //    Thriller,
    //    Romance
    //}

    public class Serie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string SerieType { get; set; }

        public Season Season { get; set; }
        [ForeignKey("Season")]
        public int IdSeason { get; set; }

    }
}
