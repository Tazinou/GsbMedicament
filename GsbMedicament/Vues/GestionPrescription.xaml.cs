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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GsbMedicament.Vues
{
    /// <summary>
    /// Logique d'interaction pour GestionPrescription.xaml
    /// </summary>
    public partial class GestionPrescription : Page
    {
        public GestionPrescription()
        {
            InitializeComponent();
        }

        GstBdd gst;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new GstBdd();
            cboAllMedicaments.SelectedItem = gst.getAllMedicaments();
            cboTypeIndividu.ItemsSource = gst.getAllIndividu();
            cboDosage.ItemsSource = gst.getAllDosage();
        }

        private void btnAjouterPrescription_Click(object sender, RoutedEventArgs e)
        {
            if (TxtPosologie.Text == null)
            {
                MessageBox.Show("Vous devez saisir une posologie.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (cboAllMedicaments.SelectedItem == null)
            {
                MessageBox.Show("Vous devez entrer un medicament.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (cboDosage.SelectedItem == null)
            {
                MessageBox.Show("Vous devez entrer un dosage.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (cboTypeIndividu.SelectedItem == null)
            {
                MessageBox.Show("Vous devez entrer un type d'individu.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int codeMedicament = (cboAllMedicaments.SelectedItem as Medicament).DepotMedicament;
                int codeIndividu = (cboTypeIndividu.SelectedItem as TypeIndividu).CodeTypeIndividu;
                int codeDosage = (cboDosage.SelectedItem as Dosage).CodeDosage;
                string posologie = TxtPosologie.Text;

                gst.AjouterPrescription(codeMedicament, codeIndividu, codeDosage, posologie);
                cboAllMedicaments.SelectedItem = gst.getAllMedicaments();
            }
        }

        private void cboDosage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cboDosage.SelectedItem != null)
            {
                int codeDosage = (cboDosage.SelectedItem as Dosage).CodeDosage;
                TxtPosologie.Text = codeDosage.ToString();
            }
        }

        private void cboTypeIndividu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cboTypeIndividu.SelectedItem != null)
            {

            }
        }
    }
}
