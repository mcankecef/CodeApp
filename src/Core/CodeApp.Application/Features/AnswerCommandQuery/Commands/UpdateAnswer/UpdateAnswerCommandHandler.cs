using CodeApp.Application.Dtos;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.AnswerCommandQuery.Commands.UpdateAnswer
{
    public class UpdateAnswerCommandHandler : IRequestHandler<UpdateAnswerCommandRequest, BaseResponse<NoContentDto>>
    {
        private readonly IAnswerReadRepository _answerReadRepository;
        private readonly IAnswerWriteRepository _answerWriteRepository;

        public UpdateAnswerCommandHandler(
            IAnswerReadRepository answerReadRepository,
            IAnswerWriteRepository answerWriteRepository)
        {
            _answerReadRepository = answerReadRepository;
            _answerWriteRepository = answerWriteRepository;
        }

        public async Task<BaseResponse<NoContentDto>> Handle(UpdateAnswerCommandRequest request, CancellationToken cancellationToken)
        {
            var answer = await _answerReadRepository.GetByIdAsync(request.Id);

            if (answer == null)
                throw new KeyNotFoundException("Answer not found");

            answer.AnswerName = request.AnswerName;
            answer.QuestionId = request.QuestionId;

            _answerWriteRepository.Update(answer);

            return new BaseResponse<NoContentDto>(true);
        }
    }
}
