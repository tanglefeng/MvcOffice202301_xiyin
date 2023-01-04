using Microsoft.AspNetCore.Mvc;
using MvcOffice.Models;

namespace MvcOffice.Controllers
{
    public class ProductController : Controller
    {
        
      public  IProductRepository repository;
        public ItimeRepository timerepository;
        public ProductController(IProductRepository repo, ItimeRepository timerepository)
        {
            repository = repo;
            this.timerepository = timerepository;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Timeset(string ime)
        {

            //ViewBag.ime = ime;
            ViewBag.ime = timerepository.Now.ToString();
            return View();
        }
        //public ViewResult aList() => View(repository.Products);
        public ViewResult List()
        {
            ViewBag.ime = timerepository.Now.ToString();
            return View(repository.Products);
        }
    }
}
