using Portfolio.Models;
using Portfolio.Dto;

namespace Portfolio.Mappers {

    public static class ImageMappers{

        public static ImageDto toImageDto(this Image image){
            return new ImageDto{
                Id = image.Id,
                ProjectId = image.ProjectId,
                Position = image.Position,
                Url = image.Url
            };
        }

        public static Image fromDtoToImage(this CreateImageDto imageDto)
        {
            return new Image
            {
               ProjectId = imageDto.ProjectId,
               Position = imageDto.Position,
               Url = imageDto.Url
            };
        }
    }
}