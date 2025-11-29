using AutoMapper;
using CodeApp.Application.Dtos.Subject;
using CodeApp.Application.Features.SubjectCommandQuery.Commands.CreateSubject;
using CodeApp.Domain.Entities;

namespace CodeApp.Application.Mapping
{
    public class SubjectMapping : Profile
    {
        public SubjectMapping()
        {
            CreateMap<Subject, GetAllSubjectDto>();

            CreateMap<Subject, GetSubjectByIdDto>();

            CreateMap<CreateSubjectCommandRequest, Subject>();
            CreateMap<Subject, CreateSubjectDto>();
        }
    }
}
