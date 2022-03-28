using GestionnaireBdd;
using ProjetGsb;
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
    /// Logique d'interaction pour GestionPrescriptions.xaml
    /// </summary>
    public partial class GestionPrescriptions : Window
    {
        public GestionPrescriptions()
        {
            InitializeComponent();
        }

        GstBdd gst;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new GstBdd();
            lstMedicaments.ItemsSource = gst.getAllMedicaments();
            lstGetTypeIndividu.ItemsSource = gst.getAllIndividu();
            lstDosage.ItemsSource = gst.getAllDosage();
        }

        private void btnAjouterPrescription_Click(object sender, RoutedEventArgs e)
        {
            if (TxtPosologie.Text == null)
            {
                MessageBox.Show("Vous devez saisir une posologie.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (lstMedicaments.SelectedItem == null)
            {
                MessageBox.Show("Vous devez entrer un medicament.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (lstDosage.SelectedItem == null)
            {
                MessageBox.Show("Vous devez entrer un dosage.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (lstGetTypeIndividu.SelectedItem == null)
            {
                MessageBox.Show("Vous devez entrer un type d'individu.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int codeMedicament = (lstMedicaments.SelectedItem as Medicament).DepotMedicament;
                int codeIndividu = (lstGetTypeIndividu.SelectedItem as TypeIndividu).CodeTypeIndividu;
                int codeDosage = (lstDosage.SelectedItem as Dosage).CodeDosage;
                string posologie = TxtPosologie.Text;

                gst.AjouterPrescription(codeMedicament, codeIndividu, codeDosage, posologie);
                lstMedicaments.SelectedItem = gst.getAllMedicaments();
            }
        }

        private void lstMedicaments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lstGetTypeIndividu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstGetTypeIndividu.SelectedItem != null)
            {
                string typeIndividu = (lstGetTypeIndividu.SelectedItem as TypeIndividu).LibelleTypeIndividu;
               
            }
        }

        private void lstDosage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstDosage.SelectedItem != null)
            {
                string dosage = (lstDosage.SelectedItem as Dosage).QuantiteDosage;
            }
        }
    }
}
