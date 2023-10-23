using Microsoft.AspNetCore.Mvc;
using ShopThoiTrang.Models;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using ShopThoiTrang.Helpers;

namespace ShopThoiTrang.Controllers
{
    public class AccountController : Controller
    {
        ShopThoiTrangContext db = new ShopThoiTrangContext();

       

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DangKy(User1 user)
        {
            
            if (!Regex.IsMatch(user.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                ModelState.AddModelError("Email", "Email không hợp lệ.");
                return View();
            }
            if (!Regex.IsMatch(user.PhoneNumber, @"^[0-9]{10,12}$"))
            {
                ModelState.AddModelError("PhoneNumber", "Số điện thoại không hợp lệ.");
                return View();
            }
           
            db.User1s.Add(user);
            db.SaveChanges();
            return RedirectToAction("DangNhap");
        }
        public IActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DangNhap(User1 user)
        {
            var taikhoan = user.Email;
            var matkhau = user.PassWord;
            var usercheck=db.User1s.SingleOrDefault(x=>x.Email.Equals(taikhoan)&&x.PassWord.Equals(matkhau));
            if(usercheck!=null)
            {
               
                HttpContext.Session.Set("User1", usercheck);
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.LoginFail = "Đăng nhập thất bại,vui lòng kiểm tra lại!";
                return View("DangNhap");
            }
            
        }
        public IActionResult DangXuat()
        {
            
            HttpContext.Session.Clear();//remove session
            return RedirectToAction("Index", "Home");
        }
        public IActionResult About()
        {
            ViewBag.Message = "Your appli cation description page.";
            return View();
        }
    }
}
