using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shows4AllMicaela.Data
{
    public class Rating
    {
        public int Id { get; set; }

        [Range(0,5)]
        public int Stars { get; set; }
        public string Description { get; set; }

        public User User { get; set; }
        [ForeignKey("User")]
        public int IdUser { get; set; }

        public Serie Serie { get; set; }
        [ForeignKey("Serie")]
        public int IdSerie { get; set; }




    }
}
