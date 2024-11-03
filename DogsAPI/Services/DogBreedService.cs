using DogsAPI.Models;
using DogsAPI.Models.DTO;

public class DogBreedService
{
    private readonly IDogBreedRepository _dogBreedRepository;

    public DogBreedService(IDogBreedRepository dogBreedRepository)
    {
        _dogBreedRepository = dogBreedRepository;
    }

   
        
    public IEnumerable<DogBreedDto> GetAll()
    {
        return _dogBreedRepository.GetAll().Select(d => new DogBreedDto
        {
            Id = d.Id,
            Name = d.Name,
            Description = d.Description
        });
    }

    /*public DogBreedDto GetById(int id)
    {
        var breed = _dogBreedRepository.GetById(id);
        return breed == null ? null : new DogBreedDto
        {
            Id = breed.Id,
            Name = breed.Name,
            Description = breed.Description
        };
    }*/


    public DogBreedDto GetById(int id)
    {
        var breed = _dogBreedRepository.GetById(id);
        return breed == null ? null : new DogBreedDto { Id = breed.Id, Name = breed.Name, Description = breed.Description };
    }

    /*public void Add(CreateDogBreedDto newBreed)
    {
        var breed = new DogBreed
        {
            Name = newBreed.Name,
            Description = newBreed.Description
        };

        _dogBreedRepository.Add(breed);
    }*/
    public DogBreedDto Add(CreateDogBreedDto newBreed)
    {
        var breed = new DogBreed
        {
            Name = newBreed.Name,
            Description = newBreed.Description
        };

        _dogBreedRepository.Add(breed);

        // Zwracamy DogBreedDto z ustawionym Id
        return new DogBreedDto
        {
            Id = breed.Id,
            Name = breed.Name,
            Description = breed.Description
        };
    }



    public void Update(int id, CreateDogBreedDto updatedBreed)
    {
        var breed = new DogBreed 
        { 
            Id = id, 
            Name = updatedBreed.Name, 
            Description = updatedBreed.Description 
        };

        _dogBreedRepository.Update(breed);
    }

    public void Delete(int id) => _dogBreedRepository.Delete(id);
}