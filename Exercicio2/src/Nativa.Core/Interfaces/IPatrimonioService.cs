using Navita.Core.Model;
using System;
using System.Threading.Tasks;

namespace Navita.Core.Interfaces
{
    public interface IPatrimonioService : IDisposable
    {
        Task<Patrimonio> Add(Patrimonio patrimonio);
        Task<Patrimonio> Update(Patrimonio patrimonio);
        Task<bool> Remove(int id);
    }
}
