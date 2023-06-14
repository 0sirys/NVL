using System;
using System.Collections.Generic;

namespace NV.Models;

public partial class SaleLog
{
    public int Id { get; set; }

    public string? Saledetail { get; set; }

    public int? Customer { get; set; }

    public DateTime? Date { get; set; }

    public virtual Customer? CustomerNavigation { get; set; }
}
