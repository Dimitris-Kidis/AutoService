using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Masters.GetReviewsAboutMaster
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<MasterReviewDto, MasterReviewDto>();
            CreateMap<IEnumerable<MasterReviewDto>, IEnumerable<MasterReviewDto>>();
        }
    }
}
