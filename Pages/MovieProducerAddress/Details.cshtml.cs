using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestingWebAppRazorPages.Data;
using TestingWebAppRazorPages.Models;


namespace TestingWebAppRazorPages.Pages.MovieProducerAddress
{
    public class DetailsModel : PageModel
    {
        private readonly TestingWebAppRazorPagesContext _context;


        public DetailsModel(TestingWebAppRazorPagesContext context)
        {
            _context = context;
        }


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
    }
}
