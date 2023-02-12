using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.AutoServiceRepository;
using ApplicationCore.Services.Repository.UserRepository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Masters.GetReviewsAboutMaster
{
    public class GetReviewsAboutMasterQueryHandler : IRequestHandler<GetReviewsAboutMasterQuery, IEnumerable<MasterReviewDto>>
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly IAutoServiceRepository<Consultation> _consRepository;
        private readonly IMapper _mapper;

        public GetReviewsAboutMasterQueryHandler(
            IUserRepository<User> userRepository,
            IAutoServiceRepository<Consultation> consRepository,
            IMapper mapper)
        {
            _consRepository = consRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MasterReviewDto>> Handle(GetReviewsAboutMasterQuery request, CancellationToken cancellationToken)
        {
            var cons = _consRepository.FindBy(cons => cons.MasterId == request.MasterId).ToList();
            var ids = _consRepository.FindBy(cons => cons.MasterId == request.MasterId).Select(x => x.ClientId).ToList();
            var users = _userRepository.FindBy(cons => ids.Contains(cons.Id)).ToList();

            var reviews = (from con in cons
                          join user in users on con.ClientId equals user.Id
                          where con.Done == true
                          select new MasterReviewDto
                          {
                              Id = con.MasterId,
                              Stars = con.Stars,
                              Comment = con.Comment,
                              UserAvatar = user.Avatar,
                              UserName = user.FirstName + " " + user.LastName,
                              CreatedAt = con.CreatedAt
                          }).ToList();


            return reviews.Select(_mapper.Map<MasterReviewDto>);
        }
    }
}
