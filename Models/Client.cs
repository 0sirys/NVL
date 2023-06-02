using System;
using System.Collections.Generic;

namespace NV.Models;

public partial class Client
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? FullName { get; set; }

    public decimal? PaymentAdvance { get; set; }

    public DateTime? PaymentDue { get; set; }

    public bool? PaymentStatus { get; set; }

    public virtual ICollection<SaleHistory> SaleHistories { get; set; } = new List<SaleHistory>();
}
