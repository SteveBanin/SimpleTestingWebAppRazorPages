using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestingWebAppRazorPages.Data;
using TestingWebAppRazorPages.Models;


namespace TestingWebAppRazorPages.Pages.MovieProducerAddress
{
    public class IndexModel : PageModel
    {
        private readonly TestingWebAppRazorPagesContext _context;


        public IndexModel(TestingWebAppRazorPagesContext context)
        {
            _context = context;
        }


        public IList<ProducerAddress> ProducerAddress { get;set; } = default!;


        public async Task OnGetAsync()
        {
            if (_context.ProducerAddress != null)
            {
                ProducerAddress = await _context.ProducerAddress
                .Include(p => p.Producers).ToListAsync();
            }
        }
    }
}
