using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestingWebAppRazorPages.Data;
using TestingWebAppRazorPages.Models;


namespace TestingWebAppRazorPages.Pages.MovieProducerAddress
{
    public class DeleteModel : PageModel
    {
        private readonly TestingWebAppRazorPagesContext _context;


        public DeleteModel(TestingWebAppRazorPagesContext context)
        {
            _context = context;
        }


        [BindProperty]
        public ProducerAddress ProducerAddress { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProducerAddress == null)
            {
                return NotFound();
            }

            var produceraddress = await _context.ProducerAddress.FirstOrDefaultAsync(m => m.ProducerAddressId == id);

            if (produceraddress == null)
            {
                return NotFound();
            }
            else 
            {
                ProducerAddress = produceraddress;
            }
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ProducerAddress == null)
            {
                return NotFound();
            }
            var produceraddress = await _context.ProducerAddress.FindAsync(id);

            if (produceraddress != null)
            {
                ProducerAddress = produceraddress;
                _context.ProducerAddress.Remove(ProducerAddress);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
