using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestingWebAppRazorPages.Data;
using TestingWebAppRazorPages.Models;


namespace TestingWebAppRazorPages.Pages.MovieProducers
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
            return Page();
        }


        [BindProperty]
        public Producer Producer { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Producer == null || Producer == null)
            {
                return Page();
            }

            _context.Producer.Add(Producer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
