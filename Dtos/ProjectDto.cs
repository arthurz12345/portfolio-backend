
namespace Portfolio.Dto
{

    public class ProjectDto{
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
    }

    public class CreateProjectDto{
        public required string Title { get; set; }
        public required string Date { get; set; }
        public required int Year { get; set; }
        public required string Format { get; set; }
        public required string Location { get; set; }
        public required string Url { get; set; }
        public required string DisplayImage { get; set; }
        public required string Summary { get; set; }
        public required string LongDescription { get; set; }
    }

        public class UpdateProjectDto{
        public required string Title { get; set; }
        public required string Date { get; set; }
        public required int Year { get; set; }
        public required string Format { get; set; }
        public required string Location { get; set; }
        public required string Url { get; set; }
        public required string DisplayImage { get; set; }
        public required string Summary { get; set; }
        public required string LongDescription { get; set; }
    }
}