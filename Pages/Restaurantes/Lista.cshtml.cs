using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TesteFood.Core;
using TesteFood.Data;

namespace TesteFood.Pages.Restaurantes
{
    public class ListaModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        
        private readonly IRestaurantData restaurantData;
        private readonly IConfiguration config;       
        public IEnumerable<Restaurant> Restaurantes;
        
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListaModel(IConfiguration config,IRestaurantData restaurantData)
        { 
            this.config = config;
            this.restaurantData = restaurantData;
        }

        public void OnGet()
        {
            Restaurantes = restaurantData.GetRestaurantsByName(SearchTerm);
        }

    }
}