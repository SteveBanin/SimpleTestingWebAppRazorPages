using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestingWebAppRazorPages.Data;
using TestingWebAppRazorPages.Models;


namespace TestingWebAppRazorPages.Pages.MovieProducers
{
    public class IndexModel : PageModel
    {
        private readonly TestingWebAppRazorPagesContext _context;


        public IndexModel(TestingWebAppRazorPagesContext context)
        {
            _context = context;
        }


        public IList<Producer> Producer { get;set; } = default!;


        public async Task OnGetAsync()
        {
            if (_context.Producer != null)
            {
                Producer = await _context.Producer.ToListAsync();
            }
        }
    }
}
