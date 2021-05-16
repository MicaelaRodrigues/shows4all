using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shows4AllMicaela.Data;
using Shows4AllMicaela.Data.Repositories;

namespace Shows4AllMicaela.Pages.ator
{
    public class CreateModel : PageModel
    {
        private readonly AtorRepository _actorRepository;

        public CreateModel(AtorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Actor Actor { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _actorRepository.AddActorAsync(Actor);

            return RedirectToPage("./Index");
        }

    }
}
