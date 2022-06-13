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

namespace health
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HealthBDEntities context;


        public MainWindow()
        {
            InitializeComponent();
            context = new HealthBDEntities();
        }

        private void EnterClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int idWorker = Convert.ToInt32(login.Text);
                string pass = passwords.Text;

                Worker worker = context.Worker.ToList().Find(x => x.idWorker == idWorker);
                if (worker == null)
                {
                    MessageBox.Show("Работника с таким логином не существует", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (worker.password.Equals(pass))
                    {
                        passwords.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                        MessageBox.Show("Успешная авторизация", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                        
                    }
                    else
                    {
                        passwords.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                        MessageBox.Show("Пароль не совпадает", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        
                    }
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Был неверно введен логин", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch
            {
                MessageBox.Show("Ошибка", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }


    }
}
