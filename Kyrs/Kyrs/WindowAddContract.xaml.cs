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
    /// Логика взаимодействия для WindowAddContract.xaml
    /// </summary>
    public partial class WindowAddContract : Window
    {
        private ContractTabl _curretContract = new ContractTabl();
        public WindowAddContract(ContractTabl selectedContract)
        {
            InitializeComponent();

            if (selectedContract != null)
            {
                _curretContract = selectedContract;
            }

            DataContext = _curretContract;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_curretContract.id == 0)
            {
                using (Class1 db = new Class1())
                {
                    db.contract.Add(_curretContract);
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
                    var t = db.contract.Single(x => x.id == _curretContract.id);
                    t.date_purchase = _curretContract.date_purchase;
                    t.additional_services = _curretContract.additional_services;
                    t.client_id = _curretContract.client_id;
                    t.tour_id = _curretContract.tour_id;
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
