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
    /// Логика взаимодействия для ProcedurePage1.xaml
    /// </summary>
    public partial class ProcedurePage1 : Page
    {
        HealthBDEntities context;
        public ProcedurePage1(HealthBDEntities cont, ListAnalysisAndProcedure listAnalysisAndProcedure)
        {
            InitializeComponent();
            context = cont;
            ProcedureTable.ItemsSource = cont.ListAnalysisAndProcedure.ToList().Where(x => x.title == listAnalysisAndProcedure.title).ToList();
        }
    }
}
