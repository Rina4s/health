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
    /// Логика взаимодействия для ProcedurePage.xaml
    /// </summary>
    public partial class ProcedurePage : Page
    {
        HealthBDEntities context;
        public ProcedurePage()
        {
            InitializeComponent();
            context = new HealthBDEntities();
            ProcedureListView.ItemsSource = context.ListAnalysisAndProcedure.ToList();
        }

        private void ClickToListItem(object sender, MouseButtonEventArgs e)
        {
            ListAnalysisAndProcedure listAnalysisAndProcedure = (sender as Grid).DataContext as ListAnalysisAndProcedure;
            NavigationService.Navigate(new ProcedurePage1(context, listAnalysisAndProcedure));
        }
    }
}
