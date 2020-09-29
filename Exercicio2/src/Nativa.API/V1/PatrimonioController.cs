using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nativa.API.ViewModel;
using Navita.Core.Interfaces;
using Navita.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nativa.API.Controllers
{
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/patrimonio")]
    public class PatrimonioController : MainController
    {
        private readonly IPatrimonioRepository _patrimonioRepository;
        private readonly IPatrimonioService _patrimonioService;
        private readonly IMapper _mapper;

        public PatrimonioController(
            IPatrimonioRepository patrimonioRepository,
            IPatrimonioService patrimonioService,
            IMapper mapper,
            INotifier notifier,
            IUser user
        ) : base(user, notifier)
        {
            _patrimonioRepository = patrimonioRepository;
            _patrimonioService = patrimonioService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatrimonioViewModel>>> Get()
        {
            var patrimonioViewModel = _mapper.Map<IEnumerable<PatrimonioViewModel>>(await _patrimonioRepository.GetAll());

            return CustomResponse(patrimonioViewModel);
        }
        

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PatrimonioViewModel>> Get(int id)
        {
            var patrimonio = await _patrimonioRepository.GetById(id);

            if (patrimonio == null)
                return NotFound();

            return CustomResponse(_mapper.Map<PatrimonioViewModel>(patrimonio));
        }

        [HttpPost]
        public async Task<ActionResult<PatrimonioViewModel>> Create(PatrimonioViewModel patrimonio)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var result = await _patrimonioService.Add(_mapper.Map<Patrimonio>(patrimonio));

            return CustomResponse(_mapper.Map<PatrimonioViewModel>(result));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _patrimonioService.Remove(id);

            return CustomResponse("Excluído com sucesso!");
        }

        [HttpPut]
        public async Task<ActionResult<PatrimonioViewModel>> Update(PatrimonioViewModel patrimonio)
        {
            if (patrimonio.Id == null)
                ModelState.AddModelError(nameof(patrimonio.Id), "Campo Id é obrigatório");

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var result = await _patrimonioService.Update(_mapper.Map<Patrimonio>(patrimonio));

            return CustomResponse(_mapper.Map<PatrimonioViewModel>(result));
        }

    }
}
