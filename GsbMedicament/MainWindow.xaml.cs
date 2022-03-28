using GestionnaireBdd;
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



namespace GsbMedicament
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //GstBdd gst;       

        private void btnGstIndividu_Click(object sender, RoutedEventArgs e)
        {
            Vues.GestionIndividus gstIndividu = new Vues.GestionIndividus();
            gstIndividu.Show();
        }

        private void btnGstPrescription_Click(object sender, RoutedEventArgs e)
        {
            Vues.GestionPrescriptions gstPrescription = new Vues.GestionPrescriptions();
            gstPrescription.Show();
        }

        private void btnVoirMedicaments_Click(object sender, RoutedEventArgs e)
        {
            Vues.voirMedicament voirMedicament = new Vues.voirMedicament();
            voirMedicament.Show();
        }

        private void btnGstPerturbateur_Click(object sender, RoutedEventArgs e)
        {
            Vues.GestionPerturbateur gstPerturbateur = new Vues.GestionPerturbateur();
            gstPerturbateur.Show();
        }

        private void btnStatistiques_Click(object sender, RoutedEventArgs e)
        {
            Vues.VoirStatistique voirStat = new Vues.VoirStatistique();
            voirStat.Show();
        }

        private void btnGstMedicaments_Click(object sender, RoutedEventArgs e)
        {
            Vues.GestionMedicament gstMedicament= new Vues.GestionMedicament();
            gstMedicament.Show();
        }
    }
}