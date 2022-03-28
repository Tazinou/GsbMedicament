using GestionnaireBdd;
using LiveCharts;
using LiveCharts.Wpf;
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

namespace GsbMedicament.Vues
{
    /// <summary>
    /// Logique d'interaction pour VoirStatistique.xaml
    /// </summary>
    public partial class VoirStatistique : Window
    {
        public VoirStatistique()
        {
            InitializeComponent();
        }

        GstBdd gst;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new GstBdd();
            //cboMedicaments.ItemsSource = gst.getAllMedicaments();

            PieSeries ps;
            ChartValues<int> line;

            Dictionary<string, int> lesDatas = new Dictionary<string, int>();

            lesDatas = gst.GetDatasGraph2();

            foreach (string cle in lesDatas.Keys)
            {
                ps = new PieSeries();
                line = new ChartValues<int>();
                line.Add(lesDatas[cle]);
                ps.Values = line;
                ps.Title = cle;
                ps.DataLabels = true;
                monGraph2.Series.Add(ps);
            }
            monGraph2.LegendLocation = LegendLocation.Bottom;





            ColumnSeries cs = new ColumnSeries();
            cs.Fill = Brushes.Red;
            ChartValues<double> line2 = new ChartValues<double>();

            Dictionary<string, int> lesDatas2 = new Dictionary<string, int>();
            lesDatas2 = gst.GetDatasGraph1();

            //lesDatas = gst.GetDatasGraph1((cboActions.SelectedItem as MetierTrader.Action).NomAction);

            foreach (string cle in lesDatas2.Keys)
            {
                line2.Add(lesDatas2[cle]);

            }
            cs.Values = line2;

            monGraph1.Series.Clear();
            monGraph1.AxisX.Clear();
            Axis axe = new Axis();
            axe.Labels = lesDatas2.Keys.ToList();
            monGraph1.AxisX.Add(axe);
            monGraph1.Series.Add(cs);
            cs.Title = "Nombre de perturbateurs";
            cs.DataLabels = true;
            monGraph1.LegendLocation = LegendLocation.Top;

        }

        private void cboMedicaments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ColumnSeries cs = new ColumnSeries();
            cs.Fill = Brushes.Red;
            ChartValues<double> line = new ChartValues<double>();

            Dictionary<string, double> lesDatas = new Dictionary<string, double>();

            //lesDatas = gst.GetDatasGraph1((cboActions.SelectedItem as MetierTrader.Action).NomAction);

            foreach (string cle in lesDatas.Keys)
            {
                line.Add(lesDatas[cle]);
            }
            cs.Values = line;

            monGraph1.Series.Clear();
            monGraph1.AxisX.Clear();
            Axis axe = new Axis();
            axe.Labels = lesDatas.Keys.ToList();
            monGraph1.AxisX.Add(axe);
            monGraph1.Series.Add(cs);
            cs.Title = "Prix d'achat";
            cs.DataLabels = true;

            monGraph1.LegendLocation = LegendLocation.Top;
        }
    }
}
