using System;
using System.Collections.Generic;

namespace ShopThoiTrang.Models;

public partial class ImageProduct
{
    public int ImageProductId { get; set; }

    public string Image { get; set; } = null!;

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
