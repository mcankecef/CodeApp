﻿namespace CodeApp.Application.Dtos.Subject
{
    public class GetAllSubjectDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LanguageName { get; set; }
    }
}
