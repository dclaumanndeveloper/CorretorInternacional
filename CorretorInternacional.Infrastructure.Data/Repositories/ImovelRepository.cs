using CorretorInternacional.Domain.Interfaces.Repositories;
using CorretorInternacional.Domain.Models;
using CorretorInternacional.Infrastructure.Data.Context;

using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace CorretorInternacional.Infrastructure.Data.Repositories
{
    public class ImovelRepository : BaseRepository<Imovel>, IImovelRepository
    {
        public ImovelRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Imovel>> Obter(bool somenteAtivos, string parametro = null)
        {
            try
            {
                return await DbSet
                    .AsNoTracking()

                    .ToListAsync();
            }
            catch (Exception ex)
            {

                return new List<Imovel>();
            }
        }

        public async Task<Imovel> Obter(string id)
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

        public Task UpdateAsync(Imovel entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IEnumerable<Imovel> entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Imovel>> WhereAsync(Expression<Func<Imovel, bool>> expression)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Imovel>> IBaseRepository<Imovel>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Imovel> IBaseRepository<Imovel>.GetById<T>(T id)
        {
            throw new NotImplementedException();
        }
    }
}
