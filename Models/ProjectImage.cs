namespace Portfolio.Models
{
    public class ProjectImage
    {
        public int Id { get; set; }
        public required int ProjectId { get; set; }
        public required int Position { get; set; }
        public required string Url { get; set; }

    }
}
