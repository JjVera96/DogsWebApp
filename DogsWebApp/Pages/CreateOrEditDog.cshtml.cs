using DogsWebApp.Interfaces;
using DogsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DogsWebApp.Pages
{
    public class EditDogModel : PageModel
    {
        public string? Title = null;
        private readonly IDogProvider _dogProvider;
        [BindProperty]
        public Dog Dog { get; set; } = new();
        public EditDogModel(IDogProvider dogProvider)
        {
            _dogProvider = dogProvider;
        }
        public async void OnGet(int? id)
        {
            if (id == null)
            {
                Dog = new Dog();
                Title = "Dog create";
            }
            else
            {
                Title = "Dog edit";
                var result = await _dogProvider.GetAsync((int)id);
                if (result != null)
                {
                    Dog = result;
                }
                else
                {
                    Response.Redirect("Index");
                }
            }
        }

        public async void OnPost()
        {
            if (!ModelState.IsValid)
            {
                if (Dog.Id == 0)
                {
                    Dog = new Dog();
                    Title = "Dog create";
                }
                else
                {
                    Title = "Dog edit";
                }
            }
            else
            {
                if (Dog.Id == 0)
                {
                    Dog = new Dog(
                        Dog.Name,
                        Dog.Age,
                        Dog.Breed,
                        Dog.Gender,
                        Dog.Color,
                        Dog.Size,
                        Dog.Vaccinated,
                        Dog.Adopted
                        );
                    var result = await _dogProvider.AddAsync(Dog);
                    if (result.IsSuccess)
                    {
                        Response.Redirect("Index");
                    }
                    else
                    {
                        Title = "Dog create";
                        Page();
                    }
                }
                else
                {
                    bool result = await _dogProvider.UpdateAsync(Dog.Id, Dog);
                    if (result == true)
                    {
                        Response.Redirect("Index");
                    }
                    else
                    {
                        Title = "Dog edit";
                        Page();
                    }
                }
            }
        }
    }
}
