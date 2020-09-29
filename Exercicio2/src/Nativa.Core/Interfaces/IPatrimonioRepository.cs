using Navita.Core.Model;
using System.Threading.Tasks;

namespace Navita.Core.Interfaces
{
    public interface IPatrimonioRepository : IRepository<Patrimonio>
    {
        Task<Patrimonio> GetMarcaByPatrimonio(int id);

        Task<Patrimonio> Update(Patrimonio patrimonio);
    }
}
