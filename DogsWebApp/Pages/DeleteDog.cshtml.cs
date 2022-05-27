using DogsWebApp.Interfaces;
using DogsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DogsWebApp.Pages
{
    public class DeleteDogModel : PageModel
    {
        private readonly IDogProvider _dogProvider;
        public Dog Dog { get; set; } = new();

        public DeleteDogModel(IDogProvider dogProvider)
        {
            _dogProvider = dogProvider;
        }

        public async void OnGet(int id)
        {
            var result = await _dogProvider.RemoveAsync(id);
            Console.WriteLine(result);
            Response.Redirect("Index");
        }
    }
}
