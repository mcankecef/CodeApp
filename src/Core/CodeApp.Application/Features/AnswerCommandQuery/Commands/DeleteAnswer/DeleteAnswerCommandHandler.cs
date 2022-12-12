using CodeApp.Application.Dtos;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeApp.Application.Features.AnswerCommandQuery.Commands.DeleteAnswer
{
    public class DeleteAnswerCommandHandler : IRequestHandler<DeleteAnswerCommandRequest, BaseResponse<NoContentDto>>
    {
        private readonly IAnswerRepository _answerRepository;

        public DeleteAnswerCommandHandler(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<BaseResponse<NoContentDto>> Handle(DeleteAnswerCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedAnswers = await _answerRepository
                .Queryable()
                .Where(x => x.QuestionId == request.QuestionId)
                .ToListAsync();

            if (deletedAnswers is null)
                throw new ArgumentNullException($"{nameof(deletedAnswers)} is not found");

            await _answerRepository.RemoveRange(deletedAnswers);
 
            return new BaseResponse<NoContentDto>("Answer is succesfully deleted", true);
        }
    }
}
