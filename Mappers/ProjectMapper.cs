using Portfolio.Models;
using Portfolio.Dto;

namespace Portfolio.Mappers
{

    public static class ProjectMappers
    {

        public static CreateProjectDto ToCreateProjectDto(this Project project, List<NewProjectImageDto> images){
            return new CreateProjectDto{
                Title = project.Title,
                Date = project.Date,
                Year = project.Year,
                Format = project.Format,
                Location = project.Location,
                Url = project.Url,
                DisplayImage = project.DisplayImage,
                LongDescription = project.LongDescription,
                Summary = project.Summary,
                Images = images
            };
        }

        public static GetProjectDto ToGetProjectDto(this Project project, List<ProjectImage> images){
            return new GetProjectDto{
                Id = project.Id,
                Title = project.Title,
                Date = project.Date,
                Year = project.Year,
                Format = project.Format,
                Location = project.Location,
                Url = project.Url,
                DisplayImage = project.DisplayImage,
                LongDescription = project.LongDescription,
                Summary = project.Summary,
                Images = images
            };
        }

        public static Project FromCreateDtoToProject(this CreateProjectDto createProjectDto){
            return new Project{
                Title = createProjectDto.Title,
                Date = createProjectDto.Date,
                Year = createProjectDto.Year,
                Format = createProjectDto.Format,
                Location = createProjectDto.Location,
                Url = createProjectDto.Url,
                DisplayImage = createProjectDto.DisplayImage,
                LongDescription = createProjectDto.LongDescription,
                Summary = createProjectDto.Summary,
            };
        }
   
    }
}