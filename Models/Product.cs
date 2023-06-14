using System;
using System.Collections.Generic;

namespace NV.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal? Price { get; set; }

    public decimal? Cost { get; set; }

    public int? Amount { get; set; }

    public int Code { get; set; }

    public decimal? Discount { get; set; }

    public int? Seller { get; set; }

    public virtual Seller? SellerNavigation { get; set; }
}
