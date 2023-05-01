﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestingWebAppRazorPages.Data;
using TestingWebAppRazorPages.Models;


namespace TestingWebAppRazorPages.Pages.MovieProducers
{
    public class EditModel : PageModel
    {
        private readonly TestingWebAppRazorPagesContext _context;


        public EditModel(TestingWebAppRazorPagesContext context)
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

            var producer =  await _context.Producer.FirstOrDefaultAsync(m => m.Id == id);
            if (producer == null)
            {
                return NotFound();
            }
            Producer = producer;
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

            _context.Attach(Producer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProducerExists(Producer.Id))
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


        private bool ProducerExists(int id)
        {
          return (_context.Producer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
