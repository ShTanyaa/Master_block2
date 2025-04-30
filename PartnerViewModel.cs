using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1
{
    class PartnerViewModel
    {
        public string TypePartner { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Phone { get; set; }
        public string Rating { get; set; }
        public decimal TotalSales { get; set; }
        public int DiscountPercent { get; set; }
        public string DiscountInfo { get; set; }

        public PartnerViewModel(Partner partner, decimal totalSales, int discountPercent)
        {
            TypePartner = partner.TypePartner;
            Name = partner.Name;
            Director = partner.Director;
            Phone = partner.Phone;
            Rating = partner.Rating;
            TotalSales = totalSales;
            DiscountPercent = discountPercent;
            DiscountInfo = $"{discountPercent}%";
        }
    }
}
