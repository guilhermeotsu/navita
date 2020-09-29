using Navita.Core.Model;
using System;
using System.Threading.Tasks;

namespace Navita.Core.Interfaces
{
    public interface IMarcaService : IDisposable
    {
        Task<Marca> Add(Marca marca);
        Task<Marca> Update(Marca marca);
        Task<bool> Remove(int id);
    }
}
