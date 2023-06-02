using System;
using System.Collections.Generic;

namespace NV.Models;

public partial class SaleHistory
{
    public int Id { get; set; }

    public int? IdSeller { get; set; }

    public int? IdCustomer { get; set; }

    public DateTime? Date { get; set; }

    public virtual Client? IdCustomerNavigation { get; set; }

    public virtual Seller? IdSellerNavigation { get; set; }
}
