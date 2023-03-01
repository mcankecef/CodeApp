using CodeApp.Application.Features.AnswerCommandQuery.Commands.CreateAnswer;
using CodeApp.Application.Features.SubjectCommandQuery.Commands.CreateSubject;
using CodeApp.Application.Features.SubjectCommandQuery.Queries.GetAllSubject;
using CodeApp.Application.Features.SubjectCommandQuery.Queries.GetSubjectById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class SubjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subjects = await _mediator.Send(new GetAllSubjectQueryRequest());

            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var subject = await _mediator.Send(new GetSubjectByIdQueryRequest(id));

            return Ok(subject);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSubjectCommandRequest request)
        {
            var subject = await _mediator.Send(request);

            return StatusCode(201, subject);
        }
    }
}
