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
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public UpdateQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<NoContentDto>> Handle(UpdateQuestionCommandRequest request, CancellationToken cancellationToken)
        {
            var question = await _questionRepository.GetByIdAsync(request.Id);

            if (question == null)
                throw new ArgumentNullException(nameof(question));

            question.Name = request.Name;
            question.Description = request.Description;
            question.Level = request.Level;
            question.Description = request.Description;
            question.CorrectAnswer = request.CorrectAnswer;
            question.Score = request.Score;

            await _questionRepository.UpdateAsync(question);

            return new BaseResponse<NoContentDto>(true);
        }
    }
}
