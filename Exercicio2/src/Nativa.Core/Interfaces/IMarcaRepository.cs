using Navita.Core.Model;
using System.Threading.Tasks;

namespace Navita.Core.Interfaces
{
    public interface IMarcaRepository : IRepository<Marca>
    {
        Task<bool> HasAny(int id);
    }
}
