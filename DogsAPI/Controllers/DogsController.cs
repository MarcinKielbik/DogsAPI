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

    // Pobierz wszystkie rasy ps�w
    [HttpGet]
    public IActionResult GetAll()
    {
        var breeds = _service.GetAll();
        return Ok(breeds);
    }

    // Pobierz ras� psa na podstawie ID
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var breed = _service.GetById(id);
        if (breed == null)
            return NotFound();

        return Ok(breed);
    }

    // Dodaj now� ras� psa
    [HttpPost]
    public IActionResult Create([FromBody] CreateDogBreedDto breedDto)
    {
        var createdBreed = _service.Add(breedDto);  // Zaktualizowana linia
        return CreatedAtAction(nameof(GetById), new { id = createdBreed.Id }, createdBreed);
    }

    // Aktualizuj istniej�c� ras� psa
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] CreateDogBreedDto breedDto)
    {
        _service.Update(id, breedDto);
        return NoContent();
    }

    // Usu� ras� psa
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return NoContent();
    }
}
