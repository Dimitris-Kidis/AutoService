using ApplicationCore.Domain.Entities;
using AutoMapper;
using AutoService.Controllers.Common.ViewModels;
using Command.Consultations.UpdateConsultation;
using Command.Messages.CreateNewMessage;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Query.Masters.GetAllMasters;
using Query.Masters.GetReviewsAboutMaster;
using Query.Messages.GetAllSeenMessages;
using Query.Messages.GetAllUnseenMessages;

namespace AutoService.Controllers.Common
{
    [Route("api/common")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CommonController(
            IMapper mapper,
            IMediator mediator
            )
        {
            _mapper = mapper;
            _mediator = mediator;
        }


        [HttpPost("message")]
        public async Task<IActionResult> CreateNewMessage([FromBody] CreateMessageCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("consultation")]
        public async Task<IActionResult> UpdateConsultation([FromBody] UpdateConsultationCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == -1) return NotFound("There's no consultation with such id");
            return NoContent();
        }

        [HttpGet("all-masters")]
        public async Task<IActionResult> GetAllMasters()
        {
            var result = await _mediator.Send(new GetAllMastersQuery());
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<MasterListItemViewModel>));
        }

        [HttpGet("all-master-review/{masterId}")]
        public async Task<IActionResult> GetMastersReview(int masterId)
        {
            var result = await _mediator.Send(new GetReviewsAboutMasterQuery { MasterId = masterId});
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<MasterReviewViewModel>));
        }

        [HttpGet("all-seen-messages/{senderId}/{receiverId}")]
        public async Task<IActionResult> GetAllSeenMessages(int senderId, int receiverId)
        {
            var result = await _mediator.Send(new GetAllSeenMessagesQuery { Sender = senderId, Receiver = receiverId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<MessageViewModel>));
        }

        [HttpGet("all-unseen-messages/{senderId}/{receiverId}")]
        public async Task<IActionResult> GetAllUnseenMessages(int senderId, int receiverId)
        {
            var result = await _mediator.Send(new GetAllUnseenMessagesQuery { Sender = senderId, Receiver = receiverId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(result.Select(_mapper.Map<MessageViewModel>));
        }
    }
}