using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfApp1.Models;

public partial class Partner
{
    public int Id { get; set; }

    public string TypePartner { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Director { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string UrAdress { get; set; } = null!;

    public string Inn { get; set; } = null!;

    public string Rating { get; set; } = null!;

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();

  
}
