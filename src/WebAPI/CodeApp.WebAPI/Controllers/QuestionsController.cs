using CodeApp.Application.Features.QuestionCommandQuery.Commands.CreateQuestion;
using CodeApp.Application.Features.QuestionCommandQuery.Queries.GetAllQuestion;
using CodeApp.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class QuestionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{questionLevel}")]
        public async Task<IActionResult> GetAll(QuestionLevel questionLevel)
        {
            return Ok(await _mediator.Send(new GetAllQuestionQueryRequest(questionLevel)));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestionCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return StatusCode(201, response);
        }
    }
}
