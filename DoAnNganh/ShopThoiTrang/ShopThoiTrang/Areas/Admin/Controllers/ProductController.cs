using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopThoiTrang.Models;
using System.Diagnostics;

namespace ShopThoiTrang.Areas.Admin.Controllers
{
    [Area("admin")]
    
    public class ProductController : Controller
    {
        ShopThoiTrangContext db = new ShopThoiTrangContext();
        [Route("admin/Product")]
        public IActionResult Index()
        {
            var listSanPham = db.Products.ToList();
            return View(listSanPham);
        }
       
        /*public IActionResult DanhMucSanPham()
        {
            var listSanPham = db.Products.ToList();
            return View(listSanPham);
        }*/
        
        [HttpGet]
        [Route("admin/ThemSanPhamMoi")]
        public IActionResult ThemSanPhamMoi()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "CategoryId", "CategoryName");
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(Product sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else return View();
        }
        
        [HttpGet]
        [Route("admin/SuaSanPham")]
        public IActionResult SuaSanPham(int Pid)
        {
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "CategoryId", "CategoryName");
            var sanPham = db.Products.Find(Pid);
            return View(sanPham);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("admin/SuaSanPham")]
        public IActionResult SuaSanPham(Product sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
                return View(sanPham);
        }
        [HttpGet]
        [Route("admin/XoaSanPham")]
        public IActionResult XoaSanPham(int Pid)
        {
            var sanPham = db.Products.Find(Pid);
            if (sanPham == null)
            {
                return NotFound(); // Trả về trang 404 nếu không tìm thấy loại sản phẩm.
            }
            else
            {

                db.Products.Remove(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
