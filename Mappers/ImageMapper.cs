using Portfolio.Models;
using Portfolio.Dto;

namespace Portfolio.Mappers {

    public static class ImageMappers{

        public static ImageDto toImageDto(this ProjectImage image){
            return new ImageDto{
                Id = image.Id,
                ProjectId = image.ProjectId,
                Position = image.Position,
                Url = image.Url
            };
        }
        public static ProjectImage fromCreateDtoToImage(this ExistingProjectImageDto imageDto)
        {
            return new ProjectImage
            {
               ProjectId = imageDto.ProjectId,
               Position = imageDto.Position,
               Url = imageDto.Url
            };
        }

         public static ProjectImage NewImageDtoToImage(this NewProjectImageDto imageDto, int newProjectId)
        {
            return new ProjectImage
            {
                ProjectId = newProjectId,
               Position = imageDto.Position,
               Url = imageDto.Url
            };
        }
    }
}