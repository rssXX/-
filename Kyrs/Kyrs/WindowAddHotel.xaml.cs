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
    /// Логика взаимодействия для WindowAddHotel.xaml
    /// </summary>
    public partial class WindowAddHotel : Window
    {
        private HotelTabl _curretHotel = new HotelTabl();
        public WindowAddHotel(HotelTabl selectedHotel)
        {
            InitializeComponent();

            if (selectedHotel != null)
            {
                _curretHotel = selectedHotel;
            }

            DataContext = _curretHotel;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_curretHotel.id == 0)
            {
                using (Class1 db = new Class1())
                {
                    db.hotel.Add(_curretHotel);
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
                    var t = db.hotel.Single(x => x.id == _curretHotel.id);
                    t.name = _curretHotel.name;
                    t.address = _curretHotel.address;
                    t.classA = _curretHotel.classA;
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
