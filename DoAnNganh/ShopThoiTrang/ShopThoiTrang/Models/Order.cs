using System;
using System.Collections.Generic;

namespace ShopThoiTrang.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }
    public int? CustomerId { get; set; }

    public string DeliveryAddress { get; set; } = null!;

    public decimal Temp { get; set; }

    public decimal Ship { get; set; }

    public bool Active { get; set; }

    public virtual User1? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
