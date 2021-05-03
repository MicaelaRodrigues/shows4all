using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shows4AllMicaela.Data
{
    public class Season
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int NumberOfSeason { get; set; }

        public Episode Episode { get; set; }
        [ForeignKey("Episode")]
        public int IdEpisode { get; set; }

    }
}
