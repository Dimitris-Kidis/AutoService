using AutoMapper;
using AutoService.Controllers.Masters.ViewModel;
using Command.Masters.UpdateMaster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Query.Client.GetClientsForChat;
using Query.Masters.GetMasterHistory;

namespace AutoService.Controllers.Masters
{
    [Route("api/master")]
    [ApiController]
    public class MastersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public MastersController(
            IMapper mapper,
            IMediator mediator
            )
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPut("master")]
        public async Task<IActionResult> UpdateMaster([FromBody] UpdateMasterCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == -1) return NotFound("There's no master with such id");
            return NoContent();
        }

        [HttpGet("history/{masterId}")]
        public async Task<IActionResult> GetMasterHistory(int masterId)
        {
            var result = await _mediator.Send(new GetMasterHistoryQuery { MasterId = masterId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<MasterHistoryViewModel>));
        }

        [HttpGet("clients-for-chat/{masterId}")]
        public async Task<IActionResult> GetClientsWithInfoAndNotification(int masterId)
        {
            var result = await _mediator.Send(new GetClientsForChatQuery { MasterId = masterId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<ClientsForChatViewModel>));
        }
    }
}



