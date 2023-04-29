using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TesteFood.Core;
using TesteFood.Data;

namespace TesteFood.Pages.Restaurantes
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;
        public IEnumerable<SelectListItem> Cozinha { get; set; }

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? restaurantId)
        {
            Cozinha = htmlHelper.GetEnumSelectList<TipoCozinha>();

            if (restaurantId.HasValue)
                Restaurant = restaurantData.GetById(restaurantId.Value);
            else
                Restaurant = new Restaurant();


            if (Restaurant == null)
                return RedirectToPage("./NotFound");
            else
                return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cozinha = htmlHelper.GetEnumSelectList<TipoCozinha>();
                return Page();
            }

            if (Restaurant.ID > 0)
            {
                Restaurant = restaurantData.Update(Restaurant);
                restaurantData.Commit();
                TempData["Message"] = "Restaurante Atualizado Com Sucesso!";
                return RedirectToPage("./detalhes", new { restaurantId = Restaurant.ID });
            }
            else
            {
                restaurantData.Add(Restaurant);
                TempData["Message"] = "Restaurante Criado Com Sucesso!";
            }

            restaurantData.Commit();       
            return RedirectToPage("./Detalhes", new { restaurantId = Restaurant.ID});
        }
    }
}
