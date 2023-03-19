using CodeApp.Application.Dtos;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Application.Features.AnswerCommandQuery.Commands.DeleteAnswer
{
    public class DeleteAnswerCommandHandler : IRequestHandler<DeleteAnswerCommandRequest, BaseResponse<NoContentDto>>
    {
        private readonly IAnswerWriteRepository _answerWriteRepository;
        private readonly IAnswerReadRepository _answerReadRepository;

        public DeleteAnswerCommandHandler(IAnswerWriteRepository answerWriteRepository, IAnswerReadRepository answerReadRepository)
        {
            _answerWriteRepository = answerWriteRepository;
            _answerReadRepository = answerReadRepository;
        }

        public async Task<BaseResponse<NoContentDto>> Handle(DeleteAnswerCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedAnswers = await _answerReadRepository
                .Queryable()
                .Where(x => x.QuestionId == request.QuestionId)
                .ToListAsync();

            deletedAnswers.ForEach(a => a.Status = StatusType.Deleted);

            _answerWriteRepository.RemoveRange(deletedAnswers);

            return new BaseResponse<NoContentDto>("Answer is succesfully deleted", true);
        }
    }
}
