using AutoMapper;
using AutoService.Controllers.Common.ViewModels;
using Query.Masters.GetAllMasters;
using Query.Masters.GetReviewsAboutMaster;
using Query.Messages.GetAllSeenMessages;

namespace AutoService.Controllers.Common
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //CreateMap<UserDto, UserViewModel>();

            CreateMap<MasterListItemDto, MasterListItemViewModel>();
            CreateMap<IEnumerable<MasterListItemDto>, IEnumerable<MasterListItemViewModel>>();

            CreateMap<MasterReviewDto, MasterReviewViewModel>();
            CreateMap<IEnumerable<MasterReviewDto>, IEnumerable<MasterReviewViewModel>>();

            CreateMap<MessageDto, MessageViewModel>();
            CreateMap<IEnumerable<MessageDto>, IEnumerable<MessageViewModel>>();
        }

    }
}
