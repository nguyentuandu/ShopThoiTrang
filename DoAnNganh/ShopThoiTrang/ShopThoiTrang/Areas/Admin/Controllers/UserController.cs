using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopThoiTrang.Models;
using System.Diagnostics;

namespace ShopThoiTrang.Areas.Admin.Controllers
{
    [Area("admin")]

    public class UserController : Controller
    {
        ShopThoiTrangContext db = new ShopThoiTrangContext();

        [Route("admin/User")]
        public IActionResult Index()
        {
            var lstUser = db.User1s.ToList();
            return View(lstUser);
        }
        [HttpGet]
        [Route("admin/ThemNguoiDung")]
        public IActionResult ThemNguoiDung()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("admin/ThemNguoiDung")]
        public IActionResult ThemNguoiDung(User1 user)
        {
            if (ModelState.IsValid)
            {
                db.User1s.Add(user);
                db.SaveChanges();
                return RedirectToAction("index");

            }
            else return View();
        }
        [HttpGet]
        [Route("admin/XoaNguoiDung")]
        public IActionResult XoaNguoiDung(int Pid)
        {
            var user = db.User1s.Find(Pid);
            if (user == null)
            {
                return NotFound(); // Trả về trang 404 nếu không tìm thấy loại sản phẩm.
            }
            else
            {

                db.User1s.Remove(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
   

}
