namespace Portfolio.Dto
{

    public class ImageDto
    {
        public int Id { get; set; }
        public required int ProjectId { get; set; }
        public required int Position { get; set; }

        public required string Url { get; set; }
    }

    public class CreateImageDto{
        public required int ProjectId { get; set; }
        public required int Position { get; set; }
        public required string Url { get; set; }
    }

    public class UpdateImageDto{
        public required int Position { get; set; }
    }
}