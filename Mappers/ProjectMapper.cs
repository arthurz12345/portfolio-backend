using Portfolio.Models;
using Portfolio.Dto;

namespace Portfolio.Mappers
{

    public static class ProjectMappers
    {

        public static ProjectDto toProjectDto(this Project project)
        {

            return new ProjectDto
            {
                Id = project.Id,
                Title = project.Title,
                Date = project.Date,
                Year = project.Year,
                Format = project.Format,
                Location = project.Location,
                Url = project.Url,
                DisplayImage = project.DisplayImage,
                LongDescription = project.LongDescription,
                Summary = project.Summary
            };
        }

        public static Project fromDtoToProject(this CreateProjectDto projectDto)
        {
            return new Project
            {
                Title = projectDto.Title,
                Date = projectDto.Date,
                Year = projectDto.Year,
                Format = projectDto.Format,
                Location = projectDto.Location,
                Url = projectDto.Url,
                DisplayImage = projectDto.DisplayImage,
                LongDescription = projectDto.LongDescription,
                Summary = projectDto.Summary
            };
        }
    }
}