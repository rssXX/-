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
    /// Логика взаимодействия для WindowAddCity.xaml
    /// </summary>
    public partial class WindowAddCity : Window
    {
        private CityTabl _curretCity = new CityTabl();
        public WindowAddCity(CityTabl selectedCity)
        {
            InitializeComponent();

            if (selectedCity != null)
            {
                _curretCity = selectedCity;
            }

            DataContext = _curretCity;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_curretCity.id == 0)
            {
                using (Class1 db = new Class1())
                {
                    db.city.Add(_curretCity);
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
                    var t = db.city.Single(x => x.id == _curretCity.id);
                    t.name = _curretCity.name;
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
