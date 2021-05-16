using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shows4AllMicaela.Data;
using Shows4AllMicaela.Data.Context;
using Shows4AllMicaela.Data.Repositories;

namespace Shows4AllMicaela.Pages.user
{
    public class CreateModel : PageModel
    {
        private readonly UserRepository _userRepository;

        public CreateModel(UserRepository repository)
        {
            _userRepository = repository;
        }

        public IActionResult OnGet()
        {

            ViewData["UserType"] = new SelectList(new object[]
            {
                new {Name = "Administrator", Value = "Administrator"},
                new {Name = "Client", Value = "Client"}
            }, "Value", "Name");

            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _userRepository.AddUserAsync(User);          

            return RedirectToPage("./Index");
        }
    }
}
