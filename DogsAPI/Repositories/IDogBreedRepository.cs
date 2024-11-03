using DogsAPI.Models;
using System.Collections;

public interface IDogBreedRepository
{
    IEnumerable<DogBreed> GetAll();
    DogBreed GetById(int id);
    void Add(DogBreed breed);
    void Update(DogBreed breed);
    void Delete(int id);
}