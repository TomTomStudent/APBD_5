using APBD_5.Model;

namespace APBD_5.Repositories
{
    public interface IAnimalRepository
    {
        IEnumerable<Animal> GetAnimals(string? orderBy);
        int CreateAnimal(Animal animal);
        Animal GetAnimal(int idAnimal);
        int UpdateAnimal(Animal animal);
        int DeleteAnimal(int idAnimal);
    }
}
