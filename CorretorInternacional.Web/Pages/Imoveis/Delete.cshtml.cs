using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CorretorInternacional.Domain.Models;
using CorretorInternacional.Infrastructure.Data.Context;

namespace CorretorInternacional.Web.Pages.Imoveis
{
    public class DeleteModel : PageModel
    {
        private readonly CorretorInternacional.Infrastructure.Data.Context.ApplicationDbContext _context;

        public DeleteModel(CorretorInternacional.Infrastructure.Data.Context.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Imovel Imovel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imoveis.FirstOrDefaultAsync(m => m.Id == id);

            if (imovel == null)
            {
                return NotFound();
            }
            else
            {
                Imovel = imovel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imoveis.FindAsync(id);
            if (imovel != null)
            {
                Imovel = imovel;
                _context.Imoveis.Remove(Imovel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
