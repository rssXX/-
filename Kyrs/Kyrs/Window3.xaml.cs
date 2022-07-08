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
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace Kyrs
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
            Test();
            colHotel.ItemsSource = WindowAddTour.GetHotel();
            colCity.ItemsSource = WindowAddTour.GetCity();
            colWorks.ItemsSource = WindowAddTour.GetWorks();
        }
        public class ApplicationContext : DbContext
        {
            public ApplicationContext()
            {
                Database.EnsureCreated();
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseMySQL(
                    "server=127.0.0.1;port=3307;user=root;password=root;database=test_v_8;"
                    );
            }
            public DbSet<ContractTabl> contract { get; set; }
            public DbSet<ClientTabl> client { get; set; }
            public DbSet<PassTabl> pass { get; set; }
            public DbSet<TourTabl> tour { get; set; }
            public DbSet<CityTabl> city { get; set; }
            public DbSet<HotelTabl> hotel { get; set; }
            public DbSet<WorkersTabl> workers { get; set; }
        }
        public void Test()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<TourTabl> tt = new List<TourTabl>();
                tt = db.tour.ToList();
                TablTour.ItemsSource = tt;
            }
        }
    }
}
