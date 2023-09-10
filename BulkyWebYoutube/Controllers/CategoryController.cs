using BulkyWebYoutube.Data;
using BulkyWebYoutube.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWebYoutube.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> categories=_db.Categories.ToList();
            return View(categories);
        }
        public IActionResult Create() 
        {
        return View(new Category());
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and Display Order Can not be same");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View();
                
            }
            
        }
    }
}
