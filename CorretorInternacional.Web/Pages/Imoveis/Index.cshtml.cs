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
    public class IndexModel : PageModel
    {
        private readonly CorretorInternacional.Infrastructure.Data.Context.ApplicationDbContext _context;

        public IndexModel(CorretorInternacional.Infrastructure.Data.Context.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Imovel> Imovel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Imovel = await _context.Imoveis.ToListAsync();
        }
    }
}
