using System;
using System.Collections.Generic;
using System.IO;
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

namespace health
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2(Worker worker)
        {
            InitializeComponent();

            DowloadPict();
            frame1.Navigate(new PatientPage());
            if (worker.idPosition == 1)
            {
                WorkersButton.Visibility = Visibility.Hidden;
                ProceduresButton.Visibility = Visibility.Hidden;
            }
        }

        

        private void ShowPatients(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(new PatientPage());
        }

        private void ShowWorkers(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(new WorkerPage());
        }

        public void DowloadPict()
        {
            HealthBDEntities context = new HealthBDEntities();
            List<ListAnalysisAndProcedure> procedures = context.ListAnalysisAndProcedure.ToList();
            foreach (var item in procedures)
            {
                item.image = File.ReadAllBytes(@"C:\HealthPicture\" + item.id + ".jpg");
            }
                context.SaveChanges();
        }


        private void ShowProcedure(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(new ProcedurePage());
        }
    }
}
