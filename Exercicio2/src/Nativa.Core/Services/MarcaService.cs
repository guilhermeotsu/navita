using Navita.Core.Interfaces;
using Navita.Core.Model;
using Navita.Core.Model.Validations;
using System.Linq;
using System.Threading.Tasks;

namespace Navita.Core.Services
{
    public class MarcaService : BaseService, IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(
            IMarcaRepository marcaRepository,
            INotifier notifier
            ) : base(notifier)
        {
            _marcaRepository = marcaRepository;
        }

        public async Task<Marca> Add(Marca marca)
        {
            if (!ExecuteValidation(new MarcaValidation(), marca)) return null;

            if (_marcaRepository.Search(p => p.Nome == marca.Nome).Result.Any())
            {
                Notify("Já existe uma marca com esse mesmo nome!");

                return null;
            }

            await _marcaRepository.Add(marca);

            return marca;
        }

        public async Task<bool> Remove(int id)
        {
            if (!_marcaRepository.Search(p => p.Id == id).Result.Any())
            {
                Notify("Não foi encontrada uma marca com o Id informado!");

                return true;
            }

            await _marcaRepository.Delete(id);

            return true;
        }

        public async Task<Marca> Update(Marca marca)
        {
            if (!ExecuteValidation(new MarcaValidation(), marca)) return null;

            var marcaDb = await _marcaRepository.Search(p => p.Id == marca.Id);

            if (!await _marcaRepository.IsAny(marcaDb))
            {
                Notify("Não foi encontrado uma marca com o Id informado!");

                return null;
            }

            if (_marcaRepository.Search(p => p.Nome == marca.Nome).Result.Any())
            {
                Notify("Já existe uma marca com o nome informado");

                return null;
            }

            await _marcaRepository.Update(marca);

            return marca;
        }

        public void Dispose()
        {
            _marcaRepository?.Dispose();
        }
    }
}
