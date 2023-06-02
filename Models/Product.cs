using System;
using System.Collections.Generic;

namespace NV.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Nick { get; set; }

    public int? AddedBy { get; set; }

    public DateTime? PjoinedDate { get; set; }

    public int? Amount { get; set; }

    public string? Provider { get; set; }

    public virtual Seller? AddedByNavigation { get; set; }
}
