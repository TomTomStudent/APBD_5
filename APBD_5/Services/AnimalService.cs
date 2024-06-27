using APBD_5.Model;
using APBD_5.Repositories;

namespace APBD_5.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }
        public int CreateAnimal(Animal animal)
        {
            return _animalRepository.CreateAnimal(animal);
        }

        public int DeleteAnimal(int idAnimal)
        {
            return _animalRepository.DeleteAnimal(idAnimal);
        }

        public Animal GetAnimal(int idAnimal)
        {
            return _animalRepository.GetAnimal(idAnimal);
        }

        public IEnumerable<Animal> GetAnimals(string? orderBy)
        {
            return _animalRepository.GetAnimals(orderBy);
        }

        public int UpdateAnimal(Animal animal)
        {
            return _animalRepository.UpdateAnimal(animal);
        }
    }
}
