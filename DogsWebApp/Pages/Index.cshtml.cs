using DogsWebApp.Interfaces;
using DogsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DogsWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IDogProvider _dogProvider;
        public List<Dog> DogList { get; set; } = new List<Dog>();

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; } = string.Empty;

        public IndexModel(IDogProvider dogProvider)
        {
            _dogProvider = dogProvider;
        }

        public async void OnGet()
        {
            if (!string.IsNullOrWhiteSpace(Search))
            {
                var result = await _dogProvider.SearchAsync(Search);
                if (result != null)
                {
                    DogList = new List<Dog>(result);
                }
            }
            else
            {
                var result = await _dogProvider.GetAllAsync();
                if (result != null)
                {
                    DogList = new List<Dog>(result);
                }
            }
        }
    }
}