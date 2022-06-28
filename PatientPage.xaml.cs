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
    /// Логика взаимодействия для PatientPage.xaml
    /// </summary>
    public partial class PatientPage : Page
    {
        HealthBDEntities context;
        public PatientPage()
        {
            InitializeComponent();
            context = new HealthBDEntities();
            patienttable.ItemsSource = context.Patient.ToList();     
        }
        public void RefreshData()
        {
            var list = context.Patient.ToList();

            if (!string.IsNullOrWhiteSpace(fiobox.Text))
            {
                list = list.Where(x => x.fio.ToLower().Contains(fiobox.Text.ToLower())).ToList();
            }
            if (!string.IsNullOrWhiteSpace(omsbox.Text))
            {
                list = list.Where(x => x.oms.ToString().Contains(omsbox.Text.ToLower())).ToList();
            }
            patienttable.ItemsSource = list;
        }

        private void fiochanged(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }

        private void omschanged(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }

        private void AddPatient(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPatient(context));
        }

        private void DeletePatient(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Вы уверены, что хотите удалить пациента?", "Подтверждение", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Patient patient = patienttable.SelectedItem as Patient;
                    context.Patient.Remove(patient);
                    context.SaveChanges();
                    NavigationService.Navigate(new PatientPage());
                }
                catch
                {
                    MessageBox.Show("Ошибка!");
                }
            }
        }

        private void EditPatient(object sender, RoutedEventArgs e)
        {
            Patient patient = patienttable.SelectedItem as Patient;
            NavigationService.Navigate(new AddPatient(context, patient));
        }
    }
}
