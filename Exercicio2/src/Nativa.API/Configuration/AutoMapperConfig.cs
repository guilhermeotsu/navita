using AutoMapper;
using Nativa.API.ViewModel;
using Navita.Core.Model;

namespace Nativa.API.Configs
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Patrimonio, PatrimonioViewModel>().ReverseMap();
        }
    }
}
