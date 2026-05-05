using CodeApp.Application.Repositories;
using CodeApp.Application.Repositories.StepQuestion;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities;
using CodeApp.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Application.Features.StepQuestionCommandQuery.Commands.CreateStepQuestion;

public class CreateStepQuestionCommandHandler : IRequestHandler<CreateStepQuestionCommandRequest, BaseResponse<Guid>>
{
    private readonly IStepQuestionWriteRepository _stepQuestionWriteRepository;
    private readonly IStepQuestionReadRepository _stepQuestionReadRepository;
    private readonly ILanguageReadRepository _languageReadRepository;

    public CreateStepQuestionCommandHandler(
        IStepQuestionWriteRepository stepQuestionWriteRepository,
        IStepQuestionReadRepository stepQuestionReadRepository,
        ILanguageReadRepository languageReadRepository)
    {
        _stepQuestionWriteRepository = stepQuestionWriteRepository;
        _stepQuestionReadRepository = stepQuestionReadRepository;
        _languageReadRepository = languageReadRepository;
    }

    public async Task<BaseResponse<Guid>> Handle(CreateStepQuestionCommandRequest request, CancellationToken cancellationToken)
    {
        var languageExists = await _languageReadRepository.GetByIdAsync(request.LanguageId);
        if (languageExists == null)
        {
            return new BaseResponse<Guid>("Language not found!", false, Guid.Empty);
        }

        var existingStep = await _stepQuestionReadRepository.Queryable()
            .Where(x => x.LanguageId == request.LanguageId 
                     && x.StepNumber == request.StepNumber 
                     && x.Status == StatusType.Active)
            .FirstOrDefaultAsync(cancellationToken);

        if (existingStep != null)
        {
            return new BaseResponse<Guid>($"Step number {request.StepNumber} already exists for this language!", false, Guid.Empty);
        }

        var stepQuestion = new StepQuestion
        {
            Title = request.Title,
            Description = request.Description ?? string.Empty,
            LanguageId = request.LanguageId,
            StepNumber = request.StepNumber,
            Status = request.Status,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow
        };

        await _stepQuestionWriteRepository.CreateAsync(stepQuestion);

        return new BaseResponse<Guid>("Step question created successfully!", true, stepQuestion.Id);
    }
}
