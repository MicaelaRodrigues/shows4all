using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shows4AllMicaela.Data
{
    public class Rental
    {
        public int Id { get; set; }

        //[DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public double Price { get; set; }

        public User User { get; set; }
        [ForeignKey("User")]
        public int IdUser { get; set; }

        public Serie Serie { get; set; }
        [ForeignKey("Serie")]
        public int IdSerie { get; set; }







    }
}
