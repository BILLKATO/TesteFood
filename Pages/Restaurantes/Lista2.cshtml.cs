using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TesteFood.Core;
using TesteFood.Data;

namespace TesteFood.Pages.Restaurantes
{
    public class Lista2Model : PageModel
    {
        [TempData]
        public string Message { get; set; }

        private readonly IRestaurantData restaurantData;
        public IEnumerable<Restaurant> Restaurantes;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public Lista2Model(IConfiguration config, IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public void OnGet()
        {
            Restaurantes = restaurantData.GetRestaurantsByName(SearchTerm);
        }

    }
}