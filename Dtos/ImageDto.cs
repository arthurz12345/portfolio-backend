using Portfolio.Models;

namespace Portfolio.Dto
{

    public class ImageDto
    {
        public int Id { get; set; }
        public required int ProjectId { get; set; }
        public required int Position { get; set; }

        public required string Url { get; set; }
    }

    public class ExistingProjectImageDto{
        public required int ProjectId { get; set; }
        public required int Position { get; set; }
        public required string Url { get; set; }
    }

    public class NewProjectImageDto{
        public required int Position { get; set; }
        public required string Url { get; set; }
    }
    public class MultipleImageDto{
        public required List<ExistingProjectImageDto> images { get; set; }
    }
}