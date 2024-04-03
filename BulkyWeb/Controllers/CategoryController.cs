using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BulkyWeb.Controllers;
using Bulky.DataAcess.Data;
using Bulky.Models;

namespace BulkyWeb.Controllers
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
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category obj)
            
        {
            if(obj.Name.ToLower() == "Test")
            {
                ModelState.AddModelError("", "Test in an Invalid Value");
            }
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order can not be same as Category Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created Sucessfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {  
            if(id == null || id == 0 )
            {
                return NotFound();
            }
            Category? CategorfromDb = _db.Categories.Find(id);
            if (CategorfromDb == null)
            {
                return NotFound();
            }
            return View(CategorfromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)

        {
          
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Sucessfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? CategorfromDb = _db.Categories.Find(id);
            if (CategorfromDb == null)
            {
                return NotFound();
            }
            return View(CategorfromDb);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)

        {

            
                Category? obj = _db.Categories.Find(id);
                if (obj == null)
                {
                    return NotFound();
                }

                _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Category Deleted Sucessfully";
            return RedirectToAction("Index");
      
        }
    }
}
