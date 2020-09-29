using Navita.Core.Interfaces;
using Navita.Core.Model;
using Navita.Core.Model.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Navita.Core.Services
{
    public class PatrimonioService : BaseService, IPatrimonioService
    {
        private readonly IPatrimonioRepository _patrimonioRepository;
        private readonly IMarcaRepository _marcaRepository;

        public PatrimonioService(
            IPatrimonioRepository patrimonioRepository,
            IMarcaRepository marcaRepository,
            INotifier notifier
            ) : base(notifier)
        {
            _patrimonioRepository = patrimonioRepository;
            _marcaRepository = marcaRepository;
        }

        public async Task<Patrimonio> Add(Patrimonio patrimonio)
        {
            if (!ExecuteValidation(new PatrimonioCreateValidation(), patrimonio)) return null;

            if (!_marcaRepository.Search(p => p.Id == patrimonio.MarcaId).Result.Any())
            {
                Notify("Não foi encontrado Marca com o MarcaId informado!");

                return null;
            }

            patrimonio.NTombo = Guid.NewGuid();

            await _patrimonioRepository.Add(patrimonio);

            return patrimonio;
        }

        public async Task<bool> Remove(int id)
        {
            if (!_patrimonioRepository.Search(p => p.Id == id).Result.Any())
            {
                Notify("Não foi encontrado Patrimônio com o Id informado!");

                return false;
            }

            await _patrimonioRepository.Delete(id);

            return true;
        }

        public async Task<Patrimonio> Update(Patrimonio patrimonio)
        {
            if (!ExecuteValidation(new PatrimonioValidation(), patrimonio)) return null;

            var patrimonioDb = _patrimonioRepository.Search(p => p.Id == patrimonio.Id).Result.FirstOrDefault();

            if (patrimonioDb == null)
            {
                Notify("Não foi encontrado Patrimônio com o Id informado!");

                return null;
            }

            if (patrimonio.NTombo != null)
            {
                if (!patrimonioDb.NTombo.Equals(patrimonio.NTombo))
                {
                    Notify("Não é possível alterar o número do tombo!");

                    return null;
                }
            }

            var result = await _patrimonioRepository.Update(patrimonio);

            return result;
        }

        public void Dispose()
        {
            _patrimonioRepository?.Dispose();
        }
    }
}
