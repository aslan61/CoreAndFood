using CoreAndFood.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }        
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }
        public List<Sınıf> ProList()
        {
            List<Sınıf> cs = new List<Sınıf>();
            cs.Add(new Sınıf()
            {
                proname="Computer",
                stock=150
            });
            cs.Add(new Sınıf()
            {
                proname="LCD",
                stock=75
            });
            cs.Add(new Sınıf()
            {
                proname="USB DİSK",
                stock=220
            });
            return cs;
        }
        public IActionResult Index3()
        {
            return View();
        }
        public IActionResult VisualizeProductResult2()
        {
            return Json(FoodList());
        }
        public List<Sınıf2> FoodList()
        {
            List<Sınıf2> cs2 = new List<Sınıf2>();
            using (var c=new Context())
            {
                cs2 = c.Foods.Select(x => new Sınıf2
                {
                    foodname=x.Name,
                    stok=x.Stock
                }).ToList();
            }
            return cs2;
        }
        public IActionResult Statistics()
        {
            Context c=new Context();
            var deger1 = c.Foods.Count();
            ViewBag.deger1 = deger1;

            var d2 = c.Categories.Count();
            ViewBag.dgr2 = d2;

            var foid = c.Categories.Where(x => x.CategoryName == "Fruit").Select(y => y.CategoryID).FirstOrDefault();
            var d3 = c.Foods.Where(x=>x.CategoryID== foid).Count();
            ViewBag.dgr3 = d3;


            var d4 = c.Foods.Where(x => x.CategoryID == 4).Count();
            ViewBag.dgr4 = d4;

            var d5 = c.Foods.Sum(x=>x.Stock);
            ViewBag.dgr5 = d5;

            var d6 = c.Categories.Where(x => x.CategoryID==c.Categories.Where(y=>y.CategoryName=="Legumes").Select(z=>z.CategoryID).FirstOrDefault()).Count();
            ViewBag.dgr6 = d6;

            var d7 = c.Foods.OrderByDescending(x=>x.Stock).Select(y=>y.Name).FirstOrDefault();
            ViewBag.dgr7 = d7;


            var d8 = c.Foods.OrderBy(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.dgr8 = d8;

            var d9 = c.Foods.Average(x=>x.Price).ToString("0.00");
            ViewBag.dgr9 = d9;

            var d10 = c.Categories.Where(x=>x.CategoryName=="Fruit").Select(y=>y.CategoryID).FirstOrDefault();
            var deger10p = c.Foods.Where(y => y.CategoryID == d10).Sum(X => X.Stock);
            ViewBag.dgr10 = deger10p;


            var d11 = c.Categories.Where(x => x.CategoryName == "Vergetables").Select(y => y.CategoryID).FirstOrDefault();
            var deger11p = c.Foods.Where(y => y.CategoryID == d11).Sum(x => x.Stock);
            ViewBag.dgr11 = deger11p;

            var deger12 = c.Foods.OrderByDescending(y => y.Price).Select(x => x.Name).FirstOrDefault();
            ViewBag.dgr12 = deger12;
            return View();
        }
    }
}
