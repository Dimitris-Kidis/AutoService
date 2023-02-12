using AutoMapper;
using AutoService.Controllers.Masters.ViewModel;
using Query.Client.GetClientsForChat;
using Query.Masters.GetMasterHistory;
using Query.Masters.GetMasterInfo;

namespace AutoService.Controllers.Masters
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<MasterHistoryDto, MasterHistoryViewModel>();
            CreateMap<IEnumerable<MasterHistoryDto>, IEnumerable<MasterHistoryViewModel>>();

            CreateMap<ClientsForChatDto, ClientsForChatViewModel>();
            CreateMap<IEnumerable<ClientsForChatDto>, IEnumerable<ClientsForChatViewModel>>();

            CreateMap<MasterInfoDto, MasterCabinetInfoViewModel>();

        }

    }
}
