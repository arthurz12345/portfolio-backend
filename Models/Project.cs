namespace Portfolio.Models
{
    public class Project
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Date { get; set; }
        public required int Year { get; set; }
        public required string Format { get; set; }
        public required string Location { get; set; }
        public required string Url { get; set; }
        public required string DisplayImage { get; set; }
        public required string Summary { get; set; }
        public required string LongDescription { get; set; }
        public List<ProjectImage> ProjectImages { get; set; }
    }
}
