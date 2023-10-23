using Microsoft.AspNetCore.Mvc;
using ShopThoiTrang.Models;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using ShopThoiTrang.Helpers;

namespace ShopThoiTrang.Controllers
{
    public class PaymentController : Controller
    {
        ShopThoiTrangContext db = new ShopThoiTrangContext();
        
        public IActionResult Index()
        {
            return View();
        }
      
        public IActionResult ThanhToan()
        {
            var usercheck = HttpContext.Session.Get<User1>("User1");
            if (usercheck != null)
            {
                var listCart = HttpContext.Session.Get<List<CartItem>>("GioHang");
                var deliveryAddress = Request.Form["DeliveryAddress"];
                decimal totalTemp = listCart.Sum(item => (decimal)item.Temp);
                decimal totalShip = listCart.Sum(item => (decimal)item.Ship);
                Order order = new Order();
                order.Active = true;
                order.OrderDate = DateTime.Now;
                order.CustomerId = usercheck.CustomerId;
                order.DeliveryAddress = deliveryAddress;
                order.Temp = totalTemp;
                order.Ship = totalShip;
                db.Orders.Add(order);
                db.SaveChanges();
                int intOrderId = order.OrderId;
                List<OrderDetail> lstOrderDetail = new List<OrderDetail>();
                foreach (var item in listCart)
                {
                    OrderDetail detail = new OrderDetail();
                    detail.Quantity = (short)item.SoLuong;
                    detail.OrderId = intOrderId;
                    detail.ProductId = item.ProductId;
                    detail.UnitPrice = (decimal)item.UnitPrice;
                    lstOrderDetail.Add(detail);
                }
                db.OrderDetails.AddRange(lstOrderDetail);
                db.SaveChanges();
                return View("Index");
            }
            else
            {
                return RedirectToAction("DangNhap", "Account");
                

            }
           

        }
    }
}
