using Microsoft.AspNetCore.Mvc;
using ShopThoiTrang.Models;
using System.Diagnostics;

namespace ShopThoiTrang.Controllers
{
    public class HomeController : Controller
    {
        ShopThoiTrangContext db = new ShopThoiTrangContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Product> allProducts = db.Products.ToList();
            int numberOfRandomProducts = 8;
            Random random = new Random(Guid.NewGuid().GetHashCode());
            List<Product> randomProducts = new List<Product>();
            while (randomProducts.Count < numberOfRandomProducts)
            {
                int randomIndex = random.Next(0, allProducts.Count);
                Product randomProduct = allProducts[randomIndex];

                // Kiểm tra xem sản phẩm đã tồn tại trong danh sách chưa
                if (!randomProducts.Contains(randomProduct))
                {
                    randomProducts.Add(randomProduct);
                }
            }
            List<Product> aoProducts = allProducts.Where(p => p.CategoryId == 1).ToList();
            List<Product> quanProducts = allProducts.Where(p => p.CategoryId == 2).ToList();
            List<Product> phuKienProducts = allProducts.Where(p => p.CategoryId == 3).ToList();
            int numberOfIterations = 2;
            List<List<Product>> aoProductsList = new List<List<Product>>();
            List<List<Product>> quanProductsList = new List<List<Product>>();
            List<List<Product>> phuKienProductsList = new List<List<Product>>();
            for (int i = 0; i < numberOfIterations; i++)
            {
                List<Product> aoProductsCopy = new List<Product>(aoProducts);
                List<Product> quanProductsCopy = new List<Product>(quanProducts);
                List<Product> phuKienProductsCopy = new List<Product>(phuKienProducts);
                // Lấy 3 sản phẩm ngẫu nhiên từ danh sách sao lưu
                List<Product> aoProductsRandom = GetRandomProducts(aoProductsCopy, 3);
                List<Product> quanProductsRandom = GetRandomProducts(quanProductsCopy, 3);
                List<Product> phuKienProductsRandom = GetRandomProducts(phuKienProductsCopy, 3);


                // Thêm danh sách sản phẩm ngẫu nhiên vào danh sách chung
                aoProductsList.Add(aoProductsRandom);
                quanProductsList.Add(quanProductsRandom);
                phuKienProductsList.Add(phuKienProductsRandom);
            }

            ViewBag.AoProductsList = aoProductsList;         
            ViewBag.QuanProductsList = quanProductsList;
            ViewBag.PhuKienProductsList = phuKienProductsList;
            ViewBag.RandomProducts = randomProducts;
            return View();
        }
        private List<Product> GetRandomProducts(List<Product> allProducts, int numberOfRandomProducts)
        {
            // Sử dụng một phương thức nào đó để tạo danh sách sản phẩm ngẫu nhiên
            // Ở đây, bạn có thể sử dụng hàm ngẫu nhiên để chọn các sản phẩm từ danh sách tất cả sản phẩm.
            // Hãy đảm bảo kiểm tra số lượng sản phẩm ngẫu nhiên không vượt quá số lượng sản phẩm có sẵn.

            Random random = new Random();
            List<Product> randomProducts = new List<Product>();

            for (int i = 0; i < numberOfRandomProducts; i++)
            {
                int randomIndex = random.Next(0, allProducts.Count);
                randomProducts.Add(allProducts[randomIndex]);
            }

            return randomProducts;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}