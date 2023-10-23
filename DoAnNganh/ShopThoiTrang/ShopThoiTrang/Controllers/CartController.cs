using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ShopThoiTrang.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ShopThoiTrang.Helpers;
using System.Linq;

namespace ShopThoiTrang.Controllers
{
    public class CartController : Controller
    {
        ShopThoiTrangContext db = new ShopThoiTrangContext();

        public List<CartItem> Carts
        {
            get
            {
                var data = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (data == null)
                {
                    data = new List<CartItem>();
                }
                return data;
            }
        }
        public IActionResult Index()
        {
           
            return View(Carts);
        }
        public IActionResult AddToCart(int id, int SoLuong,int ship, string type = "Normal")
        {
            var myCart = Carts;
            var item = myCart.SingleOrDefault(p => p.ProductId == id);
            if (item == null)
            {
                var hanghoa = db.Products.SingleOrDefault(p => p.ProductId == id);
                if(myCart.Count==0)
                {
                    ship = 30000;
                }
                else
                {
                    ship = 0;
                }
                double unitPrice = (double)hanghoa.UnitPrice;
                var spSale = db.Tags.Any(tag => tag.TagId == 2);
                     if (spSale)
                {
                    unitPrice *= 0.8; // Giảm giá 20%
                }
                item = new CartItem
                {
                    ProductId = id,
                    ProductName = hanghoa.ProductName,
                    UnitPrice = unitPrice,
                    SoLuong = SoLuong,
                    Image = hanghoa.Image,
                    Ship=ship,
                    
                    
                };
               
                myCart.Add(item);
                
            }
            else
            {
                item.SoLuong += SoLuong;
            }
            HttpContext.Session.Set("GioHang", myCart);
            if (type == "ajax")
            {
                return Json(new
                {
                    SoLuong = Carts.Sum(c => c.SoLuong)
                });
            }
            return RedirectToAction("Index");
        }
        public IActionResult UpdateCartItem(int id, int newSoLuong)
        {
            var myCart = Carts;
            var item = myCart.SingleOrDefault(p => p.ProductId == id);
            if (item != null)
            {
                item.SoLuong = newSoLuong;
            }
            HttpContext.Session.Set("GioHang", myCart);
            return RedirectToAction("Index");
        }
        public IActionResult DelCartItem(int id)
        {
            var myCart = Carts;
            var item = myCart.SingleOrDefault(p => p.ProductId == id);
            if (item != null)
            {
                myCart.Remove(item);
            }
            HttpContext.Session.Set("GioHang", myCart);
            return RedirectToAction("Index");
        }
    }
}
