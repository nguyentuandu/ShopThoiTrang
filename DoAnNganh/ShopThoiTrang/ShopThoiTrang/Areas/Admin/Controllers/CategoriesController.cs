using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopThoiTrang.Models;
using System.Diagnostics;

namespace ShopThoiTrang.Areas.Admin.Controllers
{
    [Area("admin")]
    
    public class CategoriesController : Controller
    {
        ShopThoiTrangContext db = new ShopThoiTrangContext();
       [Route("admin/Categories")]
        public IActionResult Index()
        {
            var listLSP = db.Categories.ToList();
            return View(listLSP);
        }
    
        
        [HttpGet]
        [Route("admin/ThemLoaiSanPham")]
        public IActionResult ThemLoaiSanPham()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("admin/ThemLoaiSanPham")]
        public IActionResult ThemLoaiSanPham(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("index");

            }
            else return View();
        }
        [HttpGet]
        [Route("admin/SuaLoaiSanPham")]
        public IActionResult SuaLoaiSanPham(int Pid)
        {
            
            var LsanPham = db.Categories.Find(Pid);
            return View(LsanPham);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("admin/SuaLoaiSanPham")]
        public IActionResult SuaLoaiSanPham(Category LsanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(LsanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
                return View(LsanPham);
        }
        [HttpGet]
        [Route("admin/XoaLoaiSanPham")]
        public IActionResult XoaLoaiSanPham(int Pid)
        {
            var LsanPham = db.Categories.Find(Pid);
            if (LsanPham == null)
            {
                return NotFound(); // Trả về trang 404 nếu không tìm thấy loại sản phẩm.
            }
            else
            {
                
                db.Categories.Remove(LsanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

       

    }
}
