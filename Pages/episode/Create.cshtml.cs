using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shows4AllMicaela.Data;
using Shows4AllMicaela.Data.Context;

namespace Shows4AllMicaela.Pages.episode
{
    public class CreateModel : PageModel
    {
        private readonly Shows4AllContext _context;

        public CreateModel(Shows4AllContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Episode Episode { get; set; }

        [BindProperty]
        public EpisodeActor EpisodeActor { get; set; }

        [BindProperty]
        public Actor Actor { get; set; }

        [BindProperty]
        public int IdActor { get; set; }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           
            //_context.Episodes.Add(Episode);
            //await _context.SaveChangesAsync();

            // Assim nao duplica a gravaçºao do episódio
            EpisodeActor.Episode = Episode;
            EpisodeActor.IdEpisode = Episode.Id;
            _context.EpisodeActors.Add(EpisodeActor);
            await _context.SaveChangesAsync();



            return RedirectToPage("./Index");
        }
    }
}
