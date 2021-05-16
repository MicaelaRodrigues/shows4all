using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shows4AllMicaela.Data;
using Shows4AllMicaela.Data.Repositories;

namespace Shows4AllMicaela.Pages.ator
{
    public class DeleteModel : PageModel
    {
        private readonly AtorRepository _actorRepository;

        public DeleteModel(AtorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        [BindProperty]
        public Actor Actor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Actor = await _actorRepository.GetAsync(id.Value);

            if (Actor == null)
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

            _ = await _actorRepository.DeleteActorAsync(id.Value);

            return RedirectToPage("./Index");
        }

    }
}
