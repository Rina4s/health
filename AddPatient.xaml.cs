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
    /// Логика взаимодействия для AddPatient.xaml
    /// </summary>
    public partial class AddPatient : Page
    {
        HealthBDEntities context;
        public AddPatient(HealthBDEntities cont)
        {
            InitializeComponent();
            context = cont;
            
            flag = true;
        }
        bool flag;

        private void AddSave(object sender, RoutedEventArgs e)
        {
            if (flag == true)
            {
                Patient patient= new Patient()
                {
                   
                    fio = fioBox.Text,
                    oms = Convert.ToDecimal(omsBox.Text),
                    seriesAndNumberPassword = sandnBox.Text,
                    phone = Convert.ToDecimal(phoneBox.Text) 
                   
                };
                context.Patient.Add(patient);
                context.SaveChanges();
                NavigationService.Navigate(new PatientPage());
            }
            else
            {

                context.Patient.Find(patient1.oms).fio = fioBox.Text;
                context.Patient.Find(patient1.oms).seriesAndNumberPassword = sandnBox.Text;
                context.Patient.Find(patient1.oms).phone = Convert.ToDecimal( phoneBox.Text);
               
                

                context.SaveChanges();
                NavigationService.Navigate(new WorkerPage());
            }
        }
            Patient patient1;
            public AddPatient(HealthBDEntities cont, Patient patient)
            {
                InitializeComponent();
                context = cont;
                
                patient1 = patient;
                
                fioBox.Text = patient.fio;
                omsBox.Text = patient.oms.ToString();
                sandnBox.Text = patient.seriesAndNumberPassword;
                phoneBox.Text = patient.phone.ToString();
                


                flag = false;
            }
    }
}
