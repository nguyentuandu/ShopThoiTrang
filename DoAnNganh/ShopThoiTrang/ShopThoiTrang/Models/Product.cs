using System;
using System.Collections.Generic;

namespace ShopThoiTrang.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public string? Description { get; set; }

    public bool? Active { get; set; }

    public string Image { get; set; } = null!;

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<ImageProduct> ImageProducts { get; set; } = new List<ImageProduct>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
