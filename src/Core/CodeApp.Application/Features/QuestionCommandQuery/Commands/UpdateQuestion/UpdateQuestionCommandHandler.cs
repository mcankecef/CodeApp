using AutoMapper;
using CodeApp.Application.Dtos;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeApp.Application.Features.QuestionCommandQuery.Commands.UpdateQuestion
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommandRequest, BaseResponse<NoContentDto>>
    {
        private readonly IQuestionReadRepository _questionReadRepository;
        private readonly IQuestionWriteRepository _questionWriteRepository;

        public UpdateQuestionCommandHandler(IQuestionReadRepository questionReadRepository, IQuestionWriteRepository questionWriteRepository)
        {
            _questionReadRepository = questionReadRepository;
            _questionWriteRepository = questionWriteRepository;
        }

        public async Task<BaseResponse<NoContentDto>> Handle(UpdateQuestionCommandRequest request, CancellationToken cancellationToken)
        {
            var question = await _questionReadRepository.GetByIdAsync(request.Id);

            if (question == null)
                throw new ArgumentNullException(nameof(question));

            question.Name = request.Name;
            question.Description = request.Description;
            question.Level = request.Level;
            question.Description = request.Description;
            question.CorrectAnswer = request.CorrectAnswer;
            question.Score = request.Score;

            _questionWriteRepository.Update(question);

            return new BaseResponse<NoContentDto>(true);
        }
    }
}
