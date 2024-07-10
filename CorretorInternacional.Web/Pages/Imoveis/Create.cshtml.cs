using CorretorInternacional.Domain.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CorretorInternacional.Web.Pages.Imoveis
{
    public class CreateModel : PageModel
    {
        private readonly CorretorInternacional.Infrastructure.Data.Context.ApplicationDbContext _context;

        public CreateModel(CorretorInternacional.Infrastructure.Data.Context.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Imovel Imovel { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Imoveis.Add(Imovel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
