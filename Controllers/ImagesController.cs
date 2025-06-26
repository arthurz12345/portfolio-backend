using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;
using Portfolio.Dto;
using Portfolio.Mappers;
using System.Linq;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/[controller]")]
public class imagesController : ControllerBase {

    private readonly AppDbContext _context;

    public imagesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetImages(){
        return Ok(await _context.ProjectImages.ToListAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Project>> GetImageById([FromRoute] int id)
    {
        ProjectImage? image = await _context.ProjectImages.FindAsync(id);

        if (image == null)
        {
            return NotFound();
        }
        var imageDto = image.toImageDto();

        return Ok(imageDto);
    }

    [HttpGet("project/{project:int}")]
    public async Task<ActionResult<IEnumerable<ProjectImage>>> GetAllImagesForProject([FromRoute] int projectId){
        List<ImageDto> images = await _context.ProjectImages
        .Where(image => image.ProjectId == projectId)
        .Select(image => new ImageDto{
            Id = image.Id,
            ProjectId = image.ProjectId,
            Position = image.Position,
            Url = image.Url
        }).
        ToListAsync();

        if (images == null){
            return NotFound();
        }

        return Ok(images);

    }

    [HttpPost]
    public async Task<IActionResult> CreateImage([FromBody] MultipleImageDto imageDto){
        List<ProjectImage> allNewImages = imageDto.images
            .Select(image => ImageMappers.fromCreateDtoToImage(image))
            .ToList();
        await _context.ProjectImages.AddRangeAsync(allNewImages);
        await _context.SaveChangesAsync();
        var dtos = allNewImages.Select(i => i.toImageDto()).ToList();
        return CreatedAtAction(nameof(GetImageById), new { id = dtos.First().Id }, dtos);

    }




}