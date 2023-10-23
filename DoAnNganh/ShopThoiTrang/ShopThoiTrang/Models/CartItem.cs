using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace ShopThoiTrang.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public double UnitPrice { get; set; }
        public int SoLuong { get; set; }
        public double Ship { get; set; }
        public double Temp => SoLuong * UnitPrice;
        public double ThanhTien => (SoLuong * UnitPrice)+Ship;
        
    }
}
