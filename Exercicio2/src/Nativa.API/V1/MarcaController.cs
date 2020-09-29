using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Navita.Core.Interfaces;
using Navita.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nativa.API.Controllers
{
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/marca")]
    public class MarcaController : MainController
    {
        private readonly IMarcaRepository _marcaRepository;
        private readonly IMarcaService _marcaService;

        public MarcaController(
            IMarcaRepository marcaRepository,
            IMarcaService marcaService,
            INotifier notifier,
            IUser user
        ) : base(user, notifier)
        {
            _marcaRepository = marcaRepository;
            _marcaService = marcaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marca>>> Get() 
            => CustomResponse(await _marcaRepository.GetAll());
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Marca>> Get(int id)
        {
            var marca = await _marcaRepository.GetById(id);

            if (marca == null)
                return NotFound();

            return CustomResponse(marca);
        }

        // Remover o delete cascate
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _marcaService.Remove(id);

            return CustomResponse();
        }

        [HttpPost]
        public async Task<ActionResult<Marca>> Create(Marca marca)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var result = await _marcaService.Add(marca);

            return CustomResponse(result);
        }

        [HttpPut]
        public async Task<ActionResult<Marca>> Update(Marca marca)
        {
            if (marca.Id == 0)
                ModelState.AddModelError(nameof(marca.Id), "O campo Id é obrigatório");

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var result = await _marcaService.Update(marca);

            return CustomResponse(result);
        }
    }
}
