using System.ComponentModel.DataAnnotations;

namespace DogsWebApp.Models
{
    public class Dog
    {
        static int Cant = 1;
        public int Id { get; set; } = 0;
        public string UID { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Age { get; set; }
        [Required]
        public string Breed { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public bool Vaccinated { get; set; }
        [Required]
        public bool Adopted { get; set; }

        public Dog() {
        }
        public Dog(
            string _Name,
            int _Age,
            string _Breed,
            string _Gender,
            string _Color,
            string _Size,
            bool _Vaccinated,
            bool _Adopted
            )
        {
            Id = Cant;
            UID = Guid.NewGuid().ToString();
            Name = _Name;
            Age = _Age;
            Breed = _Breed;
            Gender = _Gender;
            Color = _Color;
            Size = _Size;
            Vaccinated = _Vaccinated;
            Adopted = _Adopted;
            Cant += 1;
        }

        public string Str()
        {
            return Id + " - " + UID + " - " + Name + " - " + Age + " - " + Breed;  
        }
    }
}
