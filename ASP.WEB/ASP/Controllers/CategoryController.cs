using ASP.Domain.Entities;
using ASP.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace ASP.WEB.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _applicationContext;

        public CategoryController(ApplicationDbContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categoriesList = _applicationContext.Categories;
            return View(categoriesList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Simmilar names error", "Name can't be simmilar to display order");
            }

            if (ModelState.IsValid)
            {
                _applicationContext.Categories.Add(category);
                _applicationContext.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        public IActionResult Edit(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _applicationContext.Categories.Find(id);
            if (categoryFromDb is null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Simmilar names error", "Name can't be simmilar to display order");
            }

            if (ModelState.IsValid)
            {
                _applicationContext.Categories.Update(category);
                _applicationContext.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _applicationContext.Categories.Find(id);
            if (categoryFromDb is null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _applicationContext.Categories.Find(id);
            if (categoryFromDb is null)
            {
                return NotFound();
            }

            _applicationContext.Categories.Remove(categoryFromDb);
            _applicationContext.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
