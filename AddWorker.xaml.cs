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
    /// Логика взаимодействия для AddWorker.xaml
    /// </summary>
    public partial class AddWorker : Page
    {
        HealthBDEntities context;
        public AddWorker(HealthBDEntities cont)
        {
            InitializeComponent() ;
            context = cont;
            posBox.ItemsSource = context.ListPositions.ToList();
            apBox.ItemsSource = context.Appel.ToList();
            recBox.ItemsSource = context.Reception.ToList();
            timeBox.ItemsSource = context.ListTimeTableForWorker.ToList();
            flag = true;
        }
        bool flag;
        private void AddSave(object sender, RoutedEventArgs e)
        {
            if (flag == true)
            {
                Worker worker = new Worker()
                {
                    idWorker = Convert.ToInt32(idBox.Text),
                    fio = fioBox.Text,
                    idPosition = (posBox.SelectedItem as ListPositions).id,
                    password = passBox.Text,
                    idAppel = (apBox.SelectedItem as Appel).idAppel,
                    idReception = (recBox.SelectedItem as Reception).idReception,
                    //idTimeTable = (timeBox.SelectedItem as TimeTable).id
                };
                context.Worker.Add(worker);
                context.SaveChanges();
                NavigationService.Navigate(new WorkerPage());
            }
            else
            {

                context.Worker.Find(worker1.idWorker).fio = fioBox.Text;
                context.Worker.Find(worker1.idWorker).idPosition = (posBox.SelectedItem as ListPositions).id;
                context.Worker.Find(worker1.idWorker).password = passBox.Text;
                context.Worker.Find(worker1.idWorker).idAppel = (apBox.SelectedItem as Appel).idAppel;
                context.Worker.Find(worker1.idWorker).idReception = (recBox.SelectedItem as Reception).idReception;
               //context.Worker.Find(worker1.idWorker).idTimeTable = (timeBox.SelectedItem as TimeTable).id;
              
                context.SaveChanges();
                NavigationService.Navigate(new WorkerPage());
            }
        }
        Worker worker1;
        public AddWorker(HealthBDEntities cont, Worker worker)
        {
            InitializeComponent();
            context = cont;
            posBox.ItemsSource = context.ListPositions.ToList();
            apBox.ItemsSource = context.Appel.ToList();
            recBox.ItemsSource = context.Reception.ToList();
            timeBox.ItemsSource = context.TimeTable.ToList();

            worker1 = worker;
            idBox.Text = worker.idWorker.ToString();
            fioBox.Text = worker.fio;
            posBox.SelectedItem = worker.ListPositions;
            passBox.Text = worker.password;
            apBox.Text = worker.Appel.ToString();
            recBox.Text = worker.Reception.ToString();
            //timeBox.SelectedItem = worker.DaTime.ToList();

            
            flag = false;
        }
    }
}
