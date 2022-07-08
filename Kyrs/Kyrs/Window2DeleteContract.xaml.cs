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
    /// Логика взаимодействия для Window2DeleteContract.xaml
    /// </summary>
    public partial class Window2DeleteContract : Window
    {
        public List<ContractTabl> ContractForRemoving;
        public Window2DeleteContract(List<ContractTabl> ContractForRemoving)
        {
            InitializeComponent();
            this.ContractForRemoving = ContractForRemoving;
        }

        private void yes_click(object sender, RoutedEventArgs e)
        {
            using (Class1 db = new Class1())
            {
                db.contract.RemoveRange(ContractForRemoving);
                db.SaveChanges();
                MessageBox.Show("Успешно удалено!!");
            }
            Window2 nW = new Window2();
            nW.Show();
            Close();
            return;
        }

        private void no_click(object sender, RoutedEventArgs e)
        {
            Window2 nW = new Window2();
            nW.Show();
            Close();
            return;
        }
    }
}
