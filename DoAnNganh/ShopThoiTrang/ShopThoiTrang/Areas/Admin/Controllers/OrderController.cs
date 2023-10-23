using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopThoiTrang.Models;
using System.Diagnostics;

namespace ShopThoiTrang.Areas.Admin.Controllers
{
    [Area("admin")]
    
    public class OrderController : Controller
    {
        ShopThoiTrangContext db = new ShopThoiTrangContext();
        [Route("admin/Order")]
        public IActionResult Index()
        {
            var lstdonHang = db.Orders.ToList();
            var user=db.User1s.ToList();
            ViewBag.user = user;
            return View(lstdonHang);
        }
        [HttpGet]
        [Route("admin/XoaDonHang")]
        public IActionResult XoaDonHang(int Pid)
        {
            var donHang = db.Orders.Find(Pid);
            if (donHang == null)
            {
                return NotFound(); // Trả về trang 404 nếu không tìm thấy loại sản phẩm.
            }
            else
            {

                db.Orders.Remove(donHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
