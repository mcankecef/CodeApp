using AutoMapper;
using CodeApp.Application.Dtos.Question;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeApp.Application.Features.QuestionCommandQuery.Commands.CreateQuestion
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommandRequest, BaseResponse<CreateQuestionDto>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public CreateQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper, IAnswerRepository answerRepository)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
            _answerRepository = answerRepository;
        }

        public async Task<BaseResponse<CreateQuestionDto>> Handle(CreateQuestionCommandRequest request, CancellationToken cancellationToken)
        {

            var createdQuestion = _mapper.Map<Question>(request);

            await _questionRepository.CreateAsync(createdQuestion);            

            var response = _mapper.Map<CreateQuestionDto>(createdQuestion);

            return new BaseResponse<CreateQuestionDto>("Created question succesfully", true, response);
        }
    }
}
