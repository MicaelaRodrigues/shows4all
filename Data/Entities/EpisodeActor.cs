using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shows4AllMicaela.Data
{
    public class EpisodeActor
    {
        public int Id { get; set; }

        public Actor Actor { get; set; }
        [ForeignKey("Actor")]
        public int IdActor { get; set; }

        public Episode Episode { get; set; }
        [ForeignKey("Episode")]
        public int IdEpisode { get; set; }

    }
}
