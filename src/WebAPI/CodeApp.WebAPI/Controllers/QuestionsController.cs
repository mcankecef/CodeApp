using CodeApp.Application.Features.QuestionCommandQuery.Commands.CreateQuestion;
using CodeApp.Application.Features.QuestionCommandQuery.Commands.DeleteQuestion;
using CodeApp.Application.Features.QuestionCommandQuery.Commands.UpdateQuestion;
using CodeApp.Application.Features.QuestionCommandQuery.Queries.GetAllQuestion;
using CodeApp.Application.Features.QuestionCommandQuery.Queries.GetByIdQuestion;
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

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int questionLevel, Guid languageId)
        {
            var questions = await _mediator.Send(new GetAllQuestionQueryRequest(questionLevel, languageId));

            return Ok(questions);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestionCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return StatusCode(201, response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateQuestionCommandRequest request)
        {
            await _mediator.Send(request);

            return NoContent();
        }

        [HttpGet, Route("GetQuestionById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var question = await _mediator.Send(new GetQuestionByIdQueryRequest(id));

            return Ok(question);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteQuestionCommandRequest(id));

            return NoContent();
        }

    }
}
