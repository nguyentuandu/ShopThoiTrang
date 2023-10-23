using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopThoiTrang.Models;
using System.Diagnostics;

namespace ShopThoiTrang.Areas.Admin.Controllers
{
    [Area("admin")]
    public class LoginController : Controller
    {
        [Route("admin/Login")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
