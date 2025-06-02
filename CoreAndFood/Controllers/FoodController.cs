using CoreAndFood.Models;
using CoreAndFood.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using X.PagedList;

namespace CoreAndFood.Controllers
{
	public class FoodController : Controller
	{
        FoodRepository foodRepository = new FoodRepository();
        Context c = new Context();
		public IActionResult Index(int page=1)
		{
			return View(foodRepository.TList("Category").ToPagedList(page,5));
		}
        [HttpGet]
        public IActionResult AddFood()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString(),
                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }
        [HttpPost]
        public IActionResult AddFood(Urunekle p)
        {
            Food f=new Food();
            if (p.ImageUrl!=null)
            {
                var extension = Path.GetExtension(p.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/resimler/",newimagename);
                var stream=new FileStream(location, FileMode.Create);
                p.ImageUrl.CopyTo(stream);
                f.ImageUrl = newimagename;
            }
            f.Name = p.Name;
            f.Price = p.Price;
            f.Stock = p.Stock;
            f.CategoryID = p.CategoryID;
            f.Description = p.Description;
            foodRepository.TAdd(f);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteFood(int id)
        {
            foodRepository.TDelete(new Food {FoodID=id });
            return RedirectToAction("Index");
        }
        public IActionResult FoodGet(int id)
        {
            var x=foodRepository.TGet(id);
            List<SelectListItem> values = (from a in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = a.CategoryName,
                                               Value = a.CategoryID.ToString(),
                                           }).ToList();
            ViewBag.v1 = values;
            Food f = new Food()
            {
                FoodID=x.FoodID,
                CategoryID = x.CategoryID,
                Name = x.Name,
                Price = x.Price,
                Stock  = x.Stock,
                Description= x.Description,
                ImageUrl= x.ImageUrl,
            };
            return View(f);
        }
        public IActionResult FoodUpdate(Food f)
        {
            var fd = foodRepository.TGet(f.FoodID);
            fd.Name = f.Name;
            fd.Stock = f.Stock;
            fd.Price = f.Price;
            fd.ImageUrl = f.ImageUrl;
            fd.CategoryID= f.CategoryID;
            fd.Description= f.Description;
            foodRepository.TUpdate(fd);
            return RedirectToAction("Index");
        }
    }
}
