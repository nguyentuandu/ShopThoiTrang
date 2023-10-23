using Microsoft.AspNetCore.Http;
using ShopThoiTrang.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace ShopThoiTrang.Controllers
{

    public class ShopController : Controller
    {
        ShopThoiTrangContext db= new ShopThoiTrangContext();
        // GET: ShopController
       
        public ActionResult Index(int? page,string cateName="")
        {
            int pageSize = 12;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var sanPhamSale = db.Products.Include(p => p.Tags).Where(p => p.Tags.Any(t => t.TagId == 2)).OrderBy(x => x.ProductName);
            var sanPhamNew = db.Products.Include(p => p.Tags).Where(p => p.Tags.Any(t => t.TagId == 1)).OrderBy(x => x.ProductName);
            ViewBag.spSale = sanPhamSale;
            ViewBag.spNew = sanPhamNew;
            if (cateName != "")
            {
                var sanPham=db.Products.Include(p=>p.Category).Where(p => p.Category.CategoryName.ToUpper().Contains(cateName.ToUpper()) || p.ProductName.ToUpper().Contains(cateName.ToUpper()));
                PagedList<Product> listsp = new PagedList<Product>(sanPham, pageNumber, pageSize);
                ViewBag.cateName = cateName;
               
                return View(listsp);
            }
            else
            {
                var listsanpham = db.Products.AsNoTracking().OrderBy(x => x.ProductName);
               
              
                PagedList<Product> list = new PagedList<Product>(listsanpham, pageNumber, pageSize);
                return View(list);
            }
        }
        public ActionResult Search(string cateName)
        {
            return RedirectToAction("Index", new { cateName = cateName });
        }
        // GET: ShopController/Details/5
        public ActionResult Details(int Pid)
        {
            var sanPham = db.Products.SingleOrDefault(x => x.ProductId == Pid);
            var sanPhamSale = db.Products.Include(p => p.Tags).Where(p => p.Tags.Any(t => t.TagId == 2)).OrderBy(x => x.ProductName);

            var anhSanPham = db.ImageProducts.Where(x => x.ProductId == Pid).ToList();
            var keywords = sanPham.ProductName.Split(' ').Take(2).ToList();

           var spLienQuan = db.Products
       .Where(y => y.ProductName.ToUpper().Contains(keywords[0].ToUpper()) && y.ProductName.ToUpper().Contains(keywords[1].ToUpper()) && y.ProductId != Pid)
       .ToList();
            ViewBag.anhSanPham = anhSanPham;
            ViewBag.spLienQuan = spLienQuan;
            ViewBag.spSale = sanPhamSale;
            return View(sanPham);
        }
        // GET: ShopController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShopController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShopController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
