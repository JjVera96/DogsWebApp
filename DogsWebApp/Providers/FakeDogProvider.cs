using DogsWebApp.Interfaces;
using DogsWebApp.Models;

namespace DogsWebApp.Providers
{
    public class FakeDogProvider : IDogProvider
    {
        private readonly List<Dog> _dogList = new();

        public FakeDogProvider()
        {
            _dogList.Add(new Dog(
                "Firulais",
                8,
                "Schnauzer",
                "Male",
                "Gray",
                "Medium",
                false,
                false
                ));
            _dogList.Add(new Dog(
                "Tobby",
                5,
                "Labrador",
                "Male",
                "Brown",
                "Medium",
                false,
                true
                ));
            _dogList.Add(new Dog(
                "Maximo",
                1,
                "Creole",
                "Male",
                "Black",
                "Medium",
                true,
                true
                ));
        }
        Task<ICollection<Dog>> IDogProvider.GetAllAsync()
        {
            return Task.FromResult((ICollection<Dog>)_dogList.ToList());
        }

        Task<ICollection<Dog>> IDogProvider.SearchAsync(string search)
        {
            return Task.FromResult((ICollection<Dog>)_dogList.Where(dog => dog.Name.ToLowerInvariant().Contains(
                search.ToLowerInvariant())).ToList());
        }

        Task<Dog?> IDogProvider.GetAsync(int id)
        {
            var dog = _dogList.FirstOrDefault(dog => dog.Id == id);
            return Task.FromResult(dog);
        }

        Task<bool> IDogProvider.UpdateAsync(int id, Dog _dog)
        {

            var dogToUpdate = _dogList.FirstOrDefault(dog => dog.Id == id);
            if (dogToUpdate != null)
            {
                dogToUpdate.Name = _dog.Name;
                dogToUpdate.Age = _dog.Age;
                dogToUpdate.Color = _dog.Color;
                dogToUpdate.Breed = _dog.Breed;
                dogToUpdate.Gender = _dog.Gender;
                dogToUpdate.Size = _dog.Size;
                dogToUpdate.Vaccinated = _dog.Vaccinated;
                dogToUpdate.Adopted = _dog.Adopted;
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        Task<(bool IsSuccess, int? Id)> IDogProvider.AddAsync(Dog _dog)
        {
            _dogList.Add(_dog);
            return Task.FromResult((true, (int?)_dog.Id));
        }

        Task<bool> IDogProvider.RemoveAsync(int id)
        {
            var dogToDelete = _dogList.FirstOrDefault(dog => dog.Id == id);
            if (dogToDelete != null)
            {
                _dogList.Remove(dogToDelete);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
