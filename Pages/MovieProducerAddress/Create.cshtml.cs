using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestingWebAppRazorPages.Data;
using TestingWebAppRazorPages.Models;


namespace TestingWebAppRazorPages.Pages.MovieProducerAddress
{
    public class CreateModel : PageModel
    {
        private readonly TestingWebAppRazorPagesContext _context;


        public CreateModel(TestingWebAppRazorPagesContext context)
        {
            _context = context;
        }


        public IActionResult OnGet()
        {
        ViewData["ProducerId"] = new SelectList(_context.Producer, "Id", "Id");
            return Page();
        }


        [BindProperty]
        public ProducerAddress ProducerAddress { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ProducerAddress == null || ProducerAddress == null)
            {
                return Page();
            }

            _context.ProducerAddress.Add(ProducerAddress);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
