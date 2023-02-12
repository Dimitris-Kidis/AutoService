using AutoMapper;
using AutoService.Controllers.Clients.ViewModels;
using Command.Cars.CreateNewCar;
using Command.Consultations.CreateNewConsultation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Query.Client.GetClientHistory;
using Query.Client.GetCurrentConsultation;
using Query.Consultations.GetIsThereConsultation;
using Query.Masters.GetMasterInfo;

namespace AutoService.Controllers.Clients
{
    [Route("api/client")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ClientsController(
            IMapper mapper,
            IMediator mediator
            )
        {
            _mapper = mapper;
            _mediator = mediator;
        }


        [HttpPost("consultation")]
        public async Task<IActionResult> CreateNewConsultation([FromBody] CreateNewConsultationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("car")]
        public async Task<IActionResult> CreateNewCar([FromBody] CreateNewCarCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("history/{clientId}")]
        public async Task<IActionResult> GetClientHistory(int clientId)
        {
            var result = await _mediator.Send(new GetClientHistoryQuery { ClientId = clientId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<ClientHistoryViewModel>));
        }

        [HttpGet("master-info/{clientId}")]
        public async Task<IActionResult> GetMasterInfo(int clientId)
        {
            var result = await _mediator.Send(new GetMasterInfoQuery { ClientId = clientId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(_mapper.Map<MasterInfoViewModel>(result));
        }

        [HttpGet("current-consultation/{userId}/{role}")]
        public async Task<IActionResult> GetCurrentMasterId(int userId, bool role)
        {
            var result = await _mediator.Send(new GetCurrentConsultationQuery { UserId = userId, Role = role });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(_mapper.Map<CurrentConsultationViewModel>(result));
        }

        [HttpGet("is-there-consultation/{userId}/{role}")]
        public async Task<IActionResult> GetBoolIsThereConsultation(int userId, bool role)
        {
            var result = await _mediator.Send(new GetIsThereConsultationQuery { UserId = userId, Role = role });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(_mapper.Map<IsThereConsultationViewModel>(result));
        }
    }
}
