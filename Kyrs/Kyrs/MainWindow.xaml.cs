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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace Kyrs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void authorization_Click(object sender, RoutedEventArgs e)
        {
            if (sotryd.IsChecked ?? true)
            {
                var person = Class1.ShowGridTeach7().SingleOrDefault(x => x.email == loginAuth.Text);
                if (person != null)
                {
                    if (person.password == passwordAuth.Password)
                    {
                        if (person.post == "Директор")
                        {
                            Window1 nW = new Window1();
                            nW.Show();
                            Close();
                            return;
                        }
                        else{
                            Window2 nW = new Window2();
                            nW.Show();
                            Close();
                            return;
                        }
                    }   
                }
            }
            else
            {
                var person = Class1.ShowGridTeach2().SingleOrDefault(x => x.email == loginAuth.Text);
                if (person.password == passwordAuth.Password)
                {
                    Window3 nW = new Window3();
                    nW.Show();
                    Close();
                    return;
                }
            }
            MessageBox.Show("Неверный логин или пароль");
        }

        private void registration_Click(object sender, RoutedEventArgs e)
        {
            registr nW = new registr(null);
            nW.Show();
            return;
        }
    }
}