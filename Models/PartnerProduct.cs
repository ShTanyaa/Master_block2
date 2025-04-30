using System;
using System.Collections.Generic;

namespace WpfApp1.Models;

public partial class PartnerProduct
{
    public int Id { get; set; }

    public int ProductsId { get; set; }

    public int PartnersId { get; set; }

    public int Count { get; set; }

    public DateOnly Date { get; set; }

    public virtual Partner Partners { get; set; } = null!;

    public virtual Product Products { get; set; } = null!;
}
