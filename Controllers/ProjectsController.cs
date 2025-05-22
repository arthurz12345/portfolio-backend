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
        return Ok(await _context.Projects.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Project>> GetProjectById([FromRoute] string id)
    {
        Project? project = await _context.Projects.FindAsync(id);

        if (project == null)
        {
            return NotFound();
        }
        var projectDto = project.toProjectDto();

        return Ok(projectDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProject([FromBody] CreateProjectDto projectDto){
     
        Project projectModel = projectDto.fromDtoToProject();
        await _context.Projects.AddAsync(projectModel);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProjectById), new { id = projectModel.Id }, projectModel.toProjectDto());

    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateProject([FromRoute] int id, [FromBody] UpdateProjectDto updateDto)
    {
        var projectModel = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);

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

        _context.SaveChanges();
        return Ok(projectModel.toProjectDto());
    }
}