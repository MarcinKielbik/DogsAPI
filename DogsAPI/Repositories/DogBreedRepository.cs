using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using DogsAPI.Models;
using DogsAPI.Models.DTO;
public class DogBreedRepository : IDogBreedRepository
{
    private readonly AppDbContext _context;

    public DogBreedRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<DogBreed> GetAll() => _context.DogBreeds.ToList();

    public DogBreed GetById(int id) => _context.DogBreeds.Find(id);

    public void Add(DogBreed breed)
    {
        _context.DogBreeds.Add(breed);
        _context.SaveChanges();
    }

    public void Update(DogBreed breed)
    {
        _context.DogBreeds.Update(breed);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var breed = _context.DogBreeds.Find(id);
        if (breed != null)
        {
            _context.DogBreeds.Remove(breed);
            _context.SaveChanges();
        }
    }
}
