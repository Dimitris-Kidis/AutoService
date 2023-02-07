using AutoMapper;
using Command.Blobs.UploadAvatar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.Controllers.Avatars
{

    [Route("api/avatars")]
    [ApiController]
    public class AvatarsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public AvatarsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAvatar([FromForm] UploadAvatarCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok();
        }
    }
}
