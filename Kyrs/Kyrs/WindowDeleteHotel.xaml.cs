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
    /// Логика взаимодействия для WindowDeleteHotel.xaml
    /// </summary>
    public partial class WindowDeleteHotel : Window
    {
        public List<HotelTabl> HotelForRemoving;
        public WindowDeleteHotel(List<HotelTabl> HotelForRemoving)
        {
            InitializeComponent();
            this.HotelForRemoving = HotelForRemoving;
        }

        private void no_click(object sender, RoutedEventArgs e)
        {
            Window1 nW = new Window1();
            nW.Show();
            Close();
            return;
        }

        private void yes_click(object sender, RoutedEventArgs e)
        {
            using (Class1 db = new Class1())
            {
                db.hotel.RemoveRange(HotelForRemoving);
                db.SaveChanges();
                MessageBox.Show("Успешно удалено!!");
            }
            Window1 nW = new Window1();
            nW.Show();
            Close();
            return;
        }
    }
}
