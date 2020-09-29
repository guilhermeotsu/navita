using Microsoft.EntityFrameworkCore;
using Nativa.Data.Context;
using Navita.Core.Interfaces;
using Navita.Core.Model;
using System.Threading.Tasks;

namespace Nativa.Data.Repository
{
    public class PatrimonioRepository : Repository<Patrimonio>, IPatrimonioRepository
    {
        public PatrimonioRepository(MainDbContext dbContext) : base(dbContext) { }
        public async Task<Patrimonio> GetMarcaByPatrimonio(int id)
        {
            return await _context.Patrimonios.Include(p => p.Marca).FirstOrDefaultAsync(p => p.Id == id);
        }
        public override async Task<Patrimonio> Update(Patrimonio patrimonio)
        {
            var entry = _context.Entry(patrimonio);
            entry.State = EntityState.Modified;
            
            entry.Property(p => p.NTombo).IsModified = false;

            await SaveChanges();

            return patrimonio;
        }
    }
}
 