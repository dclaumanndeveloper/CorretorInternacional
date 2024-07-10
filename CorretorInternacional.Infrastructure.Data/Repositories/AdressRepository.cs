using CorretorInternacional.Domain.Interfaces.Repositories;
using CorretorInternacional.Domain.Models;
using CorretorInternacional.Infrastructure.Data.Context;

using Microsoft.EntityFrameworkCore;

namespace CorretorInternacional.Infrastructure.Data.Repositories
{
    public class AdressRepository : BaseRepository<Adress>, IAdressRepository
    {
        public AdressRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Adress>> Obter(bool somenteAtivos, string parametro = null)
        {
            try
            {
                return await DbSet
                    .AsNoTracking()

                    .ToListAsync();
            }
            catch (Exception ex)
            {

                return new List<Adress>();
            }
        }

        public async Task<Adress> Obter(string id)
        {
            try
            {
                return await DbSet
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {

                return null;
            }
        }



    }
}
