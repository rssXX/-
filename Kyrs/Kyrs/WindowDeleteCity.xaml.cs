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
    /// Логика взаимодействия для WindowDeleteCity.xaml
    /// </summary>
    public partial class WindowDeleteCity : Window
    {
        public List<CityTabl> CityForRemoving;
        public WindowDeleteCity(List<CityTabl> CityForRemoving)
        {
            InitializeComponent();
            this.CityForRemoving = CityForRemoving;
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
                db.city.RemoveRange(CityForRemoving);
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
