using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopThoiTrang.Models;
using System.Diagnostics;
namespace ShopThoiTrang.Areas.Admin.Controllers
{
    [Area("admin")]
    public class HomeAdminController : Controller
    {
        
        ShopThoiTrangContext db = new ShopThoiTrangContext();
       
        
        public IActionResult Index()
        {
            ViewBag.TotalOrders = TotalOrder();
            ViewBag.TotalMoney = TotalMoney();
            return View();
        }
        public int TotalOrder()
        {
            var order = db.Orders.Count();
            return order;
        }
        public decimal? TotalMoney()
        {
            var totalmoney = db.Orders.Where(x => x.Active == true).Sum(x => (x.Temp + x.Ship));
            return totalmoney;
        }

    }
}
