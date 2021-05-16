using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shows4AllMicaela.Data;
using Shows4AllMicaela.Data.Repositories;

namespace Shows4AllMicaela.Pages.episode
{
    public class DeleteModel : PageModel
    {
        private readonly EpisodeRepository _episodeRepository;

        public DeleteModel(EpisodeRepository episodeRepository)
        {
            _episodeRepository = episodeRepository;
        }

        [BindProperty]
        public Episode Episode { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Episode = await _episodeRepository.GetAsync(id.Value);

            if (Episode == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _ = await _episodeRepository.DeleteEpisodeAsync(id.Value);

            return RedirectToPage("./Index");
        }

    }
}
