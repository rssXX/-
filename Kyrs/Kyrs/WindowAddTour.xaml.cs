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

namespace Kyrs
{
    /// <summary>
    /// Логика взаимодействия для WindowAddTour.xaml
    /// </summary>
    public partial class WindowAddTour : Window
    {
        private TourTabl _curretTour = new TourTabl();
        public WindowAddTour(TourTabl selectedHotel)
        {
            InitializeComponent();

            if (selectedHotel != null)
            {
                _curretTour = selectedHotel;
            }

            DataContext = _curretTour;
        }
        public static List<HotelTabl> GetHotel()
        {
            using (Class1 db = new Class1())
            {
                return db.hotel.ToList();
            }
        }
        public static List<CityTabl> GetCity()
        {
            using (Class1 db = new Class1())
            {
                return db.city.ToList();
            }
        }
        public static List<WorkersTabl> GetWorks()
        {
            using (Class1 db = new Class1())
            {
                return db.workers.ToList();
            }
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_curretTour.id == 0)
            {
                using (Class1 db = new Class1())
                {
                    db.tour.Add(_curretTour);
                    db.SaveChanges();
                }
                MessageBox.Show("Сотрудник успешно создан!");
                Window1 nW = new Window1();
                nW.Show();
                Close();
                return;
            }
            else
            {
                using (Class1 db = new Class1())
                {
                    var t = db.tour.Single(x => x.id == _curretTour.id);
                    t.date_dispatch = _curretTour.date_dispatch;
                    t.date_arrival = _curretTour.date_arrival;
                    t.adults = _curretTour.adults;
                    t.children = _curretTour.children;
                    t.cost = _curretTour.cost;
                    t.duration_stay = _curretTour.duration_stay;
                    t.hotel_id = _curretTour.hotel_id;
                    t.city_id = _curretTour.city_id;
                    t.workers_id = _curretTour.workers_id;
                    db.SaveChanges();
                }
                MessageBox.Show("Сотрудник успешно отредактирован!");
                Window1 nW = new Window1();
                nW.Show();
                Close();
                return;
            }
        }
    }
}
