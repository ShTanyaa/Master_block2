using System;
using System.Collections.Generic;

namespace WpfApp1.Models;

public partial class Product
{
    public int Id { get; set; }

    public int TypeId { get; set; }

    public string Name { get; set; } = null!;

    public int Articule { get; set; }

    public decimal MinPrice { get; set; }

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();

    public virtual ProductType Type { get; set; } = null!;
}
