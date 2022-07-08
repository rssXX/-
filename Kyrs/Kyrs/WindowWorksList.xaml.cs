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
    /// Логика взаимодействия для WindowWorksList.xaml
    /// </summary>
    public partial class WindowWorksList : Window
    {
        private WorkersTabl _curretWorker = new WorkersTabl();
        public WindowWorksList(WorkersTabl selectedWorkers)
        {
            InitializeComponent();

            if (selectedWorkers != null)
                _curretWorker = selectedWorkers;

            DataContext = _curretWorker;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_curretWorker.name))
                errors.AppendLine("Укажи ФИО");
            if (string.IsNullOrWhiteSpace(_curretWorker.email))
                errors.AppendLine("Укажи почту");
            if (string.IsNullOrWhiteSpace(_curretWorker.post))
                errors.AppendLine("Укажи должность");
            if (string.IsNullOrWhiteSpace(_curretWorker.password))
                errors.AppendLine("Укажи пароль");

            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if(_curretWorker.id == 0)
            {
                using (Class1 db = new Class1())
                {
                    db.workers.Add(_curretWorker);
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
                    var t = db.workers.Single(x => x.id == _curretWorker.id);
                    t.name = _curretWorker.name;
                    t.post = _curretWorker.post;
                    t.email = _curretWorker.email;
                    t.password = _curretWorker.password;
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
