using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestingWebAppRazorPages.Data;
using TestingWebAppRazorPages.Models;


namespace TestingWebAppRazorPages.Pages.MovieProducers
{
    public class DeleteModel : PageModel
    {
        private readonly TestingWebAppRazorPagesContext _context;


        public DeleteModel(TestingWebAppRazorPagesContext context)
        {
            _context = context;
        }


        [BindProperty]
        public Producer Producer { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Producer == null)
            {
                return NotFound();
            }

            var producer = await _context.Producer.FirstOrDefaultAsync(m => m.Id == id);

            if (producer == null)
            {
                return NotFound();
            }
            else 
            {
                Producer = producer;
            }
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Producer == null)
            {
                return NotFound();
            }
            var producer = await _context.Producer.FindAsync(id);

            if (producer != null)
            {
                Producer = producer;
                _context.Producer.Remove(Producer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
