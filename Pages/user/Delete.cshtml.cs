using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shows4AllMicaela.Data;
using Shows4AllMicaela.Data.Context;
using Shows4AllMicaela.Data.Repositories;

namespace Shows4AllMicaela.Pages.user
{
    public class DeleteModel : PageModel
    {
        private readonly UserRepository _userRepository;

        public DeleteModel(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _userRepository.GetAsync(id.Value);

            if (User == null)
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

            _ = await _userRepository.DeleteUserAsync(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
