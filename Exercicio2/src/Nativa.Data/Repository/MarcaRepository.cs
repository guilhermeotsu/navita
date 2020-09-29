using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Nativa.Data.Context;
using Navita.Core.Interfaces;
using Navita.Core.Model;
using System.Linq;
using System.Threading.Tasks;

namespace Nativa.Data.Repository
{
    public class MarcaRepository : Repository<Marca>, IMarcaRepository
    {
        public MarcaRepository(MainDbContext dbContext) : base(dbContext) { }

        public async Task<bool> HasAny(int id)
            => await _context.Marcas.AnyAsync(p => p.Id == id);
    }
}
