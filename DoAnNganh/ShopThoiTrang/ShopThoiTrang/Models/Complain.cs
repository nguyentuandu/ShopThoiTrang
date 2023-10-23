using System;
using System.Collections.Generic;

namespace ShopThoiTrang.Models;

public partial class Complain
{
    public int ComplainId { get; set; }

    public string ComplainContent { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public int? UserId { get; set; }

    public bool Active { get; set; }

    public virtual User1? User { get; set; }
}
