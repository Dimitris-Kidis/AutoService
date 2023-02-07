using ApplicationCore.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Masters.GetAllMasters
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, MasterListItemDto>();
            CreateMap<IEnumerable<User>, IEnumerable<MasterListItemDto>>();
        }
    }
}
