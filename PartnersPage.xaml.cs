using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для PartnersPage.xaml
    /// </summary>
    public partial class PartnersPage : Page
    {
        public PartnersPage()
        {
            InitializeComponent();
            LoadPartners();
        }
        private void LoadPartners()
        {
            using (var db = new ShumkovaMasterContext())
            {
                // Загружаем партнеров с их продажами
                var partnersData = db.Partners
                    .Include(p => p.PartnerProducts)
                    .Select(p => new
                    {
                        Partner = p,
                        TotalSales = p.PartnerProducts.Sum(pp => pp.Products.MinPrice * pp.Count)
                    })
                    .ToList();

                // Преобразуем в ViewModel с расчетом скидки
                var partners = partnersData.Select(p =>
                {
                    var discount = CalculateDiscount(p.TotalSales);
                    return new PartnerViewModel(p.Partner, p.TotalSales, (int)discount);
                }).ToList();

                PartnersList.ItemsSource = partners;
            }
        }

        private decimal CalculateDiscount(decimal totalSales)
        {
            if (totalSales < 10000) return 0;
            if (totalSales < 50000) return 5;
            if (totalSales < 300000) return 10;
            return 15;
        }

    }
}
