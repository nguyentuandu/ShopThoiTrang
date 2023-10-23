using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopThoiTrang.Models;
using System.Diagnostics;

namespace ShopThoiTrang.Areas.Admin.Controllers
{
    [Area("admin")]
    public class TagController : Controller
    {
        ShopThoiTrangContext db = new ShopThoiTrangContext();
        [Route("admin/Tag")]
        public IActionResult Index()
        {
            var lstTag = db.Tags.ToList();
            return View(lstTag);
        }
        [HttpGet]
        [Route("admin/ThemNhanSanPham")]
        public IActionResult ThemNhanSanPham()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemNhanSanPham(Tag tag)
        {
            if (ModelState.IsValid)
            {
                db.Tags.Add(tag);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else return View();
        }
        [HttpGet]
        [Route("admin/SuaNhanSanPham")]
        public IActionResult SuaNhanSanPham(int Pid)
        {         
            var tag = db.Tags.Find(Pid);
            return View(tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("admin/SuaNhanSanPham")]
        public IActionResult SuaNhanSanPham(Tag tag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
                return View(tag);
        }
        [HttpGet]
        [Route("admin/XoaNhanSanPham")]
        public IActionResult XoaNhanSanPham(int Pid)
        {
            var NsanPham = db.Tags.Find(Pid);
            if (NsanPham == null)
            {
                return NotFound(); // Trả về trang 404 nếu không tìm thấy loại sản phẩm.
            }
            else
            {

                db.Tags.Remove(NsanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
