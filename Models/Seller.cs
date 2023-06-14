using System;
using System.Collections.Generic;

namespace NV.Models;

public partial class Seller
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Passwd { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
