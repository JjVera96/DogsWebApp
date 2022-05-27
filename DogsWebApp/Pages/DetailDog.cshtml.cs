using DogsWebApp.Models;
using DogsWebApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DogsWebApp.Pages
{
    public class DetailDogModel : PageModel
    {
        private readonly IDogProvider _dogProvider;
        public Dog Dog { get; set; } = new();
        public DetailDogModel(IDogProvider dogProvider)
        {
            _dogProvider = dogProvider;
        }
        public async void OnGet(int id)
        {
            var result = await _dogProvider.GetAsync(id);
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
}
