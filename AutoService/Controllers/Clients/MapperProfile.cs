using AutoMapper;
using AutoService.Controllers.Clients.ViewModels;
using Query.Client.GetClientHistory;
using Query.Masters.GetMasterInfo;

namespace AutoService.Controllers.Clients
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ClientHistoryDto, ClientHistoryViewModel>();
            CreateMap<IEnumerable<ClientHistoryDto>, IEnumerable<ClientHistoryViewModel>>();

            CreateMap<MasterInfoDto, MasterInfoViewModel>();

        }

    }
}
