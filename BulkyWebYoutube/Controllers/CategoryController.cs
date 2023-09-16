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
        public IActionResult Edit(int ?Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            var category = _db.Categories.FirstOrDefault(u => u.Id == Id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and Display Order Can not be same");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View();

            }
        }
        public IActionResult Delete(int? Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            var category = _db.Categories.FirstOrDefault(u => u.Id == Id);
            return View(category);
        }
        [HttpPost,ActionName("Delete")]

        public IActionResult DeletePost(int? Id)
        {

            Category categoryFromDB = _db.Categories.FirstOrDefault(u => u.Id == Id);
            if(categoryFromDB == null)
            {
                return NotFound();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _db.Categories.Remove(categoryFromDB);
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
}
