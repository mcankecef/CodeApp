using CodeApp.Application.Features.LanguageCommandQuery.Commands.DeleteLanguage;
using CodeApp.Application.Repositories;
using CodeApp.Domain.Entities;
using FluentAssertions;
using Moq;

namespace CodeApp.Test.Application;

public class LanguageCommandHandlerTests
{
    private Mock<ILanguageWriteRepository> _languageWriteRepositoryMock;
    private Mock<ILanguageReadRepository> _languageReadRepositoryMock;
    private DeleteLanguageCommandHandler _handler;

    public LanguageCommandHandlerTests()
    {
        _languageReadRepositoryMock = new Mock<ILanguageReadRepository>();
        _languageWriteRepositoryMock = new Mock<ILanguageWriteRepository>();
        _handler = new DeleteLanguageCommandHandler(_languageWriteRepositoryMock.Object,
                                                    _languageReadRepositoryMock.Object);
    }


    [Test]
    public async Task LanguageCommandHandler_NonLanguageId_ArgumentNullException()
    {
        // Arrange  
        var request = new DeleteLanguageCommandRequest(Guid.NewGuid());
        Language? language = null;

        _languageReadRepositoryMock.Setup(l => l.GetByIdAsync(request.Id)).ReturnsAsync(language);

        // Action  
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert  
        await act.Should().ThrowAsync<ArgumentNullException>();
    }
}
