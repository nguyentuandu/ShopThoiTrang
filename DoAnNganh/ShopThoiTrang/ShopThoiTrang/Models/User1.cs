using System;
using System.Collections.Generic;

namespace ShopThoiTrang.Models;

public partial class User1
{
    public int CustomerId { get; set; }

    public string FullName { get; set; } = null!;

    public string PassWord { get; set; } = null!;

    public bool? Active { get; set; }

    public string? PhoneNumber { get; set; }

    public string Email { get; set; } = null!;

    public bool? IsAdmin { get; set; } = false;

    public virtual ICollection<Complain> Complains { get; set; } = new List<Complain>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
