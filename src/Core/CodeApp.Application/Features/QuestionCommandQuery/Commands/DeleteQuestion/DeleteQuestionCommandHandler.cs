using CodeApp.Application.Dtos;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Enums;
using MediatR;

namespace CodeApp.Application.Features.QuestionCommandQuery.Commands.DeleteQuestion
{
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommandRequest, BaseResponse<NoContentDto>>
    {
        private readonly IQuestionWriteRepository _questionWriteRepository;
        private readonly IQuestionReadRepository _questionReadRepository;
        private readonly IAnswerReadRepository _answerReadRepository;
        private readonly IAnswerWriteRepository _answerWriteRepository;

        public DeleteQuestionCommandHandler(IQuestionWriteRepository questionWriteRepository, IQuestionReadRepository questionReadRepository, IAnswerReadRepository answerReadRepository, IAnswerWriteRepository answerWriteRepository)
        {
            _questionWriteRepository = questionWriteRepository;
            _questionReadRepository = questionReadRepository;
            _answerReadRepository = answerReadRepository;
            _answerWriteRepository = answerWriteRepository;
        }

        public async Task<BaseResponse<NoContentDto>> Handle(DeleteQuestionCommandRequest request, CancellationToken cancellationToken)
        {
            var question = await _questionReadRepository.GetByIdAsync(request.Id);

            if (question == null)
                throw new ArgumentNullException("Question not found!");

            var answers = await _answerReadRepository.GetAllByQuestionIdAsync(question.Id);

            answers.ForEach(a=>a.Status = StatusType.Deleted);

            question.Status = StatusType.Deleted;

            _questionWriteRepository.Update(question);
            _answerWriteRepository.UpdateRange(answers);

            return new BaseResponse<NoContentDto>("Deleted question and answers succesfully", true);
        }
    }
}
