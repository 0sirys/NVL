using System;
using System.Collections.Generic;

namespace NV.Models;

public partial class Seller
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? FullName { get; set; }

    public string? NickName { get; set; }

    public string? Passwd { get; set; }

    public int? Level { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<SaleHistory> SaleHistories { get; set; } = new List<SaleHistory>();
}
