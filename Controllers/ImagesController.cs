using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;
using Portfolio.Dto;
using Portfolio.Mappers;
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
        return Ok(await _context.Images.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Project>> GetImageById([FromRoute] int id)
    {
        Image? image = await _context.Images.FindAsync(id);

        if (image == null)
        {
            return NotFound();
        }
        var imageDto = image.toImageDto();

        return Ok(imageDto);
    }

    [HttpGet("project/{projectId}")]
    public async Task<ActionResult<IEnumerable<Image>>> GetAllImagesForProject([FromRoute] int projectId){
        List<ImageDto> images = await _context.Images.Where(image => image.ProjectId == projectId).
        Select(image => new ImageDto{
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
    public async Task<IActionResult> CreateImage([FromBody] CreateImageDto imageDto){
        Image imageModel = imageDto.fromDtoToImage();
        await _context.Images.AddAsync(imageModel);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetImageById), new { id = imageModel.Id }, imageModel.toImageDto());
    }




}