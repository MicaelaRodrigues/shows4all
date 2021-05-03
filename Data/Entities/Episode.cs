using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shows4AllMicaela.Data
{
    public class Episode
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int NumberOfEpisode { get; set; }

        public Actor Actor { get; set; }
        [ForeignKey("Actor")]
        public int IdActor { get; set; }



    }
}
