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
    public class ContractTabl
    {
        public int id { get; set; }
        public DateTime date_purchase { get; set; }
        public string additional_services { get; set; }
        public int client_id { get; set; }
        public int tour_id { get; set; }
    }
    public class ClientTabl
    {
        public int id { get; set; }
        public string phone { get; set; }
        public string full_name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int pass_id { get; set; }
    }
    public class PassTabl
    {
        public int id { get; set; }
        public string pass_ser { get; set; }
        public string pass_num { get; set; }
        public DateTime data_birth { get; set; }
        public DateTime data_issue { get; set; }
        public string gender { get; set; }
        public string issued_whom { get; set; }
    }
    public class TourTabl
    {
        public int id { get; set; }
        public DateTime date_dispatch { get; set; }
        public DateTime date_arrival { get; set; }
        public int adults { get; set; }
        public int children { get; set; }
        public decimal cost { get; set; }
        public int duration_stay { get; set; }
        public int hotel_id { get; set; }
        public int city_id { get; set; }
        public int workers_id { get; set; }
    }
    public class CityTabl
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class HotelTabl
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string classA { get; set;}
    }
    public class WorkersTabl
    {
        public int id { get; set; }
        public string name { get; set; }
        public string post { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
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
                List<WorkersTabl> wk = new List<WorkersTabl>();
                wk = db.workers.ToList();
                TablWorkers.ItemsSource = wk;

                List<TourTabl> tt = new List<TourTabl>();
                tt = db.tour.ToList();
                TablTour.ItemsSource = tt;

                List<HotelTabl> h = new List<HotelTabl>();
                h = db.hotel.ToList();
                TablHotel.ItemsSource = h;

                List<CityTabl> s = new List<CityTabl>();
                s = db.city.ToList();
                TablCity.ItemsSource = s;

                List<ClientTabl> ct = new List<ClientTabl>();
                ct = db.client.ToList();
                TablClient.ItemsSource = ct;

                List<ContractTabl> cot = new List<ContractTabl>();
                cot = db.contract.ToList();
                TablContract.ItemsSource = cot;
            }
        }

        private void BtnEdit1_Click(object sender, RoutedEventArgs e)
        {
            WindowWorksList WWl = new WindowWorksList((sender as Button).DataContext as WorkersTabl);
            WWl.Show();
            this.Close();
            return;
        }

        private void add1_click(object sender, RoutedEventArgs e)
        {
            WindowWorksList WWl = new WindowWorksList(null);
            WWl.Show();
            this.Close();
            return;
        }
        private void delete1_click(object sender, RoutedEventArgs e)
        {
            var Removing = TablWorkers.SelectedItems.Cast<WorkersTabl>().ToList();
            WindowDeleteWorks WDw = new WindowDeleteWorks(Removing);
            WDw.Show();
            this.Close();
            return;
        }


        private void add2_click(object sender, RoutedEventArgs e)
        {
            WindowAddTour WAt = new WindowAddTour(null);
            WAt.Show();
            this.Close();
            return;
        }

        private void BtnEdit2_Click(object sender, RoutedEventArgs e)
        {
            WindowAddTour WAt = new WindowAddTour((sender as Button).DataContext as TourTabl);
            WAt.Show();
            this.Close();
            return;
        }

        private void delete2_click(object sender, RoutedEventArgs e)
        {
            var TourForRemoving = TablTour.SelectedItems.Cast<TourTabl>().ToList();
            WindowDleteTour WDt = new WindowDleteTour(TourForRemoving);
            WDt.Show();
            this.Close();
            return;
        }

        private void add3_click(object sender, RoutedEventArgs e)
        {
            WindowAddHotel WAh = new WindowAddHotel(null);
            WAh.Show();
            this.Close();
            return;
        }

        private void BtnEdit3_Click(object sender, RoutedEventArgs e)
        {
            WindowAddHotel WAh = new WindowAddHotel((sender as Button).DataContext as HotelTabl);
            WAh.Show();
            this.Close();
            return;
        }

        private void delete3_click(object sender, RoutedEventArgs e)
        {
            var HotelForRemoving = TablHotel.SelectedItems.Cast<HotelTabl>().ToList();
            WindowDeleteHotel WDh = new WindowDeleteHotel(HotelForRemoving);
            WDh.Show();
            this.Close();
            return;
        }

        private void add4_click(object sender, RoutedEventArgs e)
        {
            WindowAddCity WAc = new WindowAddCity(null);
            WAc.Show();
            this.Close();
            return;
        }

        private void delete4_click(object sender, RoutedEventArgs e)
        {
            var CityForRemoving = TablCity.SelectedItems.Cast<CityTabl>().ToList();
            WindowDeleteCity WDc = new WindowDeleteCity(CityForRemoving);
            WDc.Show();
            this.Close();
            return;
        }

        private void BtnEdit4_Click(object sender, RoutedEventArgs e)
        {
            WindowAddCity WAc = new WindowAddCity((sender as Button).DataContext as CityTabl);
            WAc.Show();
            this.Close();
            return;
        }

        private void BtnEdit5_Click(object sender, RoutedEventArgs e)
        {
            WindowAddClient WAc = new WindowAddClient((sender as Button).DataContext as ClientTabl);
            WAc.Show();
            this.Close();
            return;
        }

        private void add5_click(object sender, RoutedEventArgs e)
        {
            WindowAddClient WAc = new WindowAddClient(null);
            WAc.Show();
            this.Close();
            return;
        }

        private void delete5_click(object sender, RoutedEventArgs e)
        {
            var ClientForRemoving = TablClient.SelectedItems.Cast<ClientTabl>().ToList();
            WindowDeleteClient WDc = new WindowDeleteClient(ClientForRemoving);
            WDc.Show();
            this.Close();
            return;
        }

        private void BtnEdit6_Click(object sender, RoutedEventArgs e)
        {
            WindowAddContract WAc = new WindowAddContract((sender as Button).DataContext as ContractTabl);
            WAc.Show();
            this.Close();
            return;
        }

        private void delete6_click(object sender, RoutedEventArgs e)
        {
            var ContractForRemoving = TablContract.SelectedItems.Cast<ContractTabl>().ToList();
            WindowDeleteContract WDc = new WindowDeleteContract(ContractForRemoving);
            WDc.Show();
            this.Close();
            return;
        }

        private void add6_click(object sender, RoutedEventArgs e)
        {
            WindowAddContract WAc = new WindowAddContract(null);
            WAc.Show();
            this.Close();
            return;
        }
    }
}
