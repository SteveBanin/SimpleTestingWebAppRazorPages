using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestingWebAppRazorPages.Data;
using TestingWebAppRazorPages.Models;


namespace TestingWebAppRazorPages.Pages.MovieProducerAddress
{
    public class EditModel : PageModel
    {
        private readonly TestingWebAppRazorPagesContext _context;


        public EditModel(TestingWebAppRazorPagesContext context)
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

            var produceraddress =  await _context.ProducerAddress.FirstOrDefaultAsync(m => m.ProducerAddressId == id);
            if (produceraddress == null)
            {
                return NotFound();
            }
            ProducerAddress = produceraddress;
           ViewData["ProducerId"] = new SelectList(_context.Producer, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProducerAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProducerAddressExists(ProducerAddress.ProducerAddressId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }


        private bool ProducerAddressExists(int id)
        {
          return (_context.ProducerAddress?.Any(e => e.ProducerAddressId == id)).GetValueOrDefault();
        }
    }
}
