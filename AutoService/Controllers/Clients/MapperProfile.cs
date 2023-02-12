using AutoMapper;
using AutoService.Controllers.Clients.ViewModels;
using Query.Client.GetClientHistory;
using Query.Client.GetCurrentConsultation;
using Query.Consultations.GetIsThereConsultation;
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


            CreateMap<CurrentConsultationDto, CurrentConsultationViewModel>();

            CreateMap<IsThereConsultationDto, IsThereConsultationViewModel>();

        }

    }
}
