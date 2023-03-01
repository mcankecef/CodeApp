using CodeApp.Application.Features.LanguageCommandQuery.Commands.CreateLanguage;
using CodeApp.Application.Features.LanguageCommandQuery.Commands.DeleteLanguage;
using CodeApp.Application.Features.LanguageCommandQuery.Commands.UpdateLanguage;
using CodeApp.Application.Features.LanguageCommandQuery.Queries.GetAllLanguage;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="Admin")]
    public class LanguagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LanguagesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllLanguageQueryRequest()));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateLanguageCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return StatusCode(201, response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateLanguageCommandRequest request)
        {
            await _mediator.Send(request);

            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteLanguageCommandRequest(id));

            return NoContent();
        }
    }
}
