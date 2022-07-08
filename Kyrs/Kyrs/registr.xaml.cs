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
    /// Логика взаимодействия для registr.xaml
    /// </summary>
    public partial class registr : Window
    {
        private ClientTabl _curretClient = new ClientTabl();
        public registr(ClientTabl selectedClient)
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
                Close();
                return;
            }
        }
    }
}
