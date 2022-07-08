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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
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

                List<ContractTabl> cot = new List<ContractTabl>();
                cot = db.contract.ToList();
                TablContract.ItemsSource = cot;
            }
        }

        private void add2_click(object sender, RoutedEventArgs e)
        {
            Window2AddTour WAt = new Window2AddTour(null);
            WAt.Show();
            this.Close();
            return;
        }

        private void BtnEdit2_Click(object sender, RoutedEventArgs e)
        {
            Window2AddTour WAt = new Window2AddTour((sender as Button).DataContext as TourTabl);
            WAt.Show();
            this.Close();
            return;
        }

        private void delete2_click(object sender, RoutedEventArgs e)
        {
            var TourForRemoving = TablTour.SelectedItems.Cast<TourTabl>().ToList();
            Window2DleteTour WDt = new Window2DleteTour(TourForRemoving);
            WDt.Show();
            this.Close();
            return;
        }
        private void BtnEdit6_Click(object sender, RoutedEventArgs e)
        {
            Window2AddContract WAc = new Window2AddContract((sender as Button).DataContext as ContractTabl);
            WAc.Show();
            this.Close();
            return;
        }

        private void delete6_click(object sender, RoutedEventArgs e)
        {
            var ContractForRemoving = TablContract.SelectedItems.Cast<ContractTabl>().ToList();
            Window2DeleteContract WDc = new Window2DeleteContract(ContractForRemoving);
            WDc.Show();
            this.Close();
            return;
        }

        private void add6_click(object sender, RoutedEventArgs e)
        {
            Window2AddContract WAc = new Window2AddContract(null);
            WAc.Show();
            this.Close();
            return;
        }
    }
}
