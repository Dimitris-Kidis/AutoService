using AutoMapper;
using AutoService.Controllers.Masters.ViewModel;
using Query.Client.GetClientsForChat;
using Query.Masters.GetMasterHistory;

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
        }

    }
}
