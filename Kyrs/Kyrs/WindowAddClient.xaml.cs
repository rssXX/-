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
    /// Логика взаимодействия для WindowAddClient.xaml
    /// </summary>
    public partial class WindowAddClient : Window
    {
        private ClientTabl _curretClient = new ClientTabl();
        public WindowAddClient(ClientTabl selectedClient)
        {
            InitializeComponent();

            if (selectedClient != null)
            {
                _curretClient = selectedClient;
            }

            DataContext = _curretClient;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_curretClient.id == 0)
            {
                using (Class1 db = new Class1())
                {
                    db.client.Add(_curretClient);
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
                    var t = db.client.Single(x => x.id == _curretClient.id);
                    t.phone = _curretClient.phone;
                    t.full_name = _curretClient.full_name;
                    t.password = _curretClient.password;
                    t.email = _curretClient.email;
                    t.pass_id = _curretClient.pass_id;
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
