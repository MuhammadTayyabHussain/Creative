using CreativeWeb.Controllers.Data;
using CreativeWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CreativeWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db= db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList= _db.Categories.ToList();
            return View(objCategoryList);
        }
        [HttpGet]
        public IActionResult Create() 
        {
        return View();
        }
        [HttpPost]
        public IActionResult Create(Category category) 
        {
            if (category.Name == category.DisplyOrder.ToString())
            {
                ModelState.AddModelError("name", "Category Name and Display order cannot by the same value");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");

            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id==null) 
            {
                return NotFound();
            }
            Category categoryFromDb= _db.Categories.Find(Id);
            if (categoryFromDb == null) { return NotFound(); }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
           if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Successfully";

                return RedirectToAction("Index");

            }
           return RedirectToAction("Index");
           
        }

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(Id);
            if (categoryFromDb == null) { return NotFound(); }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? Id)
        {
            Category? obj= _db.Categories.Find(Id);
            if(obj == null) { return NotFound(); }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";

            return RedirectToAction("Index");
            
        }
    }
}
  