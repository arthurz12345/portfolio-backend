using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;
using Portfolio.Dto;
using Portfolio.Mappers;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/[controller]")]
public class projectsController : ControllerBase
{
    private readonly AppDbContext _context;

    public projectsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
    {
        List<Project> allProjects = await _context.Projects.ToListAsync();
        List<List<ProjectImage>> allImageLists = await _context.ProjectImages
            .GroupBy(image => image.ProjectId)
            .Select(group => group.ToList())
            .ToListAsync();

        var result = allProjects.GroupJoin(
            allImageLists,
            project => project.Id,
            image => image[0].ProjectId,
            (project, images) => project.ToGetProjectDto(images.SelectMany(List => List).ToList())  
        ).ToList();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Project>> GetProjectById([FromRoute] int id)
    {
        Project? project = await _context.Projects.FindAsync(id);

        if (project == null)
        {
            return NotFound("No such project");
        }
        List<ProjectImage> images = await _context.ProjectImages
            .Where(image => image.ProjectId == id).ToListAsync();
        
        var projectDto = project.ToGetProjectDto(images);

        return Ok(projectDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProject([FromBody] CreateProjectDto projectDto){
     
        Project projectModel = projectDto.FromCreateDtoToProject();
        List<NewProjectImageDto> imageDtos = projectDto.Images;


        await _context.Projects.AddAsync(projectModel);
        await _context.SaveChangesAsync();

        int newProjectId = projectModel.Id;
        if (newProjectId > 0){
            List<ProjectImage> images = imageDtos.Select(image => image.NewImageDtoToImage(newProjectId)).ToList();
            await _context.ProjectImages.AddRangeAsync(images);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProjectById), new { id = projectModel.Id },
            projectModel.ToGetProjectDto(images)
        );
        
        }
        return NotFound("Project ID invalid");
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdateProject([FromRoute] int id, [FromBody] UpdateProjectDto updateDto)
    {
        Project? projectModel = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);

        if (projectModel == null){
            return NotFound();
        }

        projectModel.Title = updateDto.Title;
        projectModel.Date = updateDto.Date;
        projectModel.Year = updateDto.Year;
        projectModel.Format = updateDto.Format;
        projectModel.Location = updateDto.Location;
        projectModel.Url = updateDto.Url;
        projectModel.DisplayImage = updateDto.DisplayImage;
        projectModel.Summary = updateDto.Summary;
        projectModel.LongDescription = updateDto.LongDescription;
        projectModel.ProjectImages = updateDto.Images;

        _context.SaveChanges();
        return Ok(projectModel);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteProject([FromRoute] int id){
        var project = await _context.Projects.FindAsync(id);

        if (project == null){
            return NotFound($"No such project id: ${id}");
        }
        

        _context.Projects.Remove(project);
        List<ProjectImage> images = _context.ProjectImages
            .Where(img => img.ProjectId == id).ToList();
        _context.ProjectImages.RemoveRange(images);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}