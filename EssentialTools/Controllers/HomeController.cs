using EssentialTools.Models;
using Ninject;
using System.Web.Mvc;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        private IValueCalculator calc;

        private Product[] products = {
            new Product{Name = "Лижі", Category = "Спорт", Price = 10.86M},
            new Product{Name = "Сноуборд", Category = "Спорт", Price = 20.14M},
            new Product{Name = "Захисне приладдя", Category = "Спорт", Price = 15.34M}
        };

        public HomeController(IValueCalculator calcParam)
        {
            calc = calcParam;
        }

        public ActionResult Index()
        {
            ShoppingCart shopCart = new ShoppingCart(calc) {
                Products = products
            };

            decimal totalValue = shopCart.CalculateProductTotal();
            return View(totalValue);
        }
    }
}