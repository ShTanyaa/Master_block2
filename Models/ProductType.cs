using System;
using System.Collections.Generic;

namespace WpfApp1.Models;

public partial class ProductType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public float QtypeProduct { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
