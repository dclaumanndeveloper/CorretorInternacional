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
    public class DetailsModel : PageModel
    {
        private readonly CorretorInternacional.Infrastructure.Data.Context.ApplicationDbContext _context;

        public DetailsModel(CorretorInternacional.Infrastructure.Data.Context.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
