﻿using CodeApp.Application.Repositories;
using CodeApp.Domain.Entities;

namespace CodeApp.Application.Repositories
{
    public interface IAnswerReadRepository : IReadRepository<Answer>
    {
        Task<List<Answer>> GetAllByQuestionIdAsync(Guid questionId);
    }
}
