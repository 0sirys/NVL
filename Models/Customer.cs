using System;
using System.Collections.Generic;

namespace NV.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Seller { get; set; }

    public virtual ICollection<SaleLog> SaleLogs { get; set; } = new List<SaleLog>();

    public virtual Seller? SellerNavigation { get; set; }
}
