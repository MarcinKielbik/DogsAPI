using DogsAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DogBreedsController : ControllerBase
{
    private readonly DogBreedService _service;

    public DogBreedsController(DogBreedService service)
    {
        _service = service;
    }

    
    [HttpGet]
    public IActionResult GetAll()
    {
        var breeds = _service.GetAll();
        return Ok(breeds);
    }


    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var breed = _service.GetById(id);
        if (breed == null)
            return NotFound();

        return Ok(breed);
    }

    
    [HttpPost]
    public IActionResult Create([FromBody] CreateDogBreedDto breedDto)
    {
        var createdBreed = _service.Add(breedDto);
        return CreatedAtAction(nameof(GetById), new { id = createdBreed.Id }, createdBreed);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] CreateDogBreedDto breedDto)
    {
        _service.Update(id, breedDto);
        return NoContent();
    }

    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return NoContent();
    }
}
