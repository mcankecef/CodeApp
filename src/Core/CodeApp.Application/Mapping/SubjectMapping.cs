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
            //GetAll
            CreateMap<Subject, GetAllSubjectDto>();

            //GetById
            CreateMap<Subject, GetSubjectByIdDto>();

            //Create
            CreateMap<CreateSubjectCommandRequest, Subject>();
            CreateMap<Subject, CreateSubjectDto>();
        }
    }
}
