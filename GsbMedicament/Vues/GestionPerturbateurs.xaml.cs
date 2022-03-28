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
    /// Logique d'interaction pour GestionPerturbateurs.xaml
    /// </summary>
    public partial class GestionPerturbateurs : Page
    {
        public GestionPerturbateurs()
        {
            InitializeComponent();
        }

        GstBdd gst;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new GstBdd();
            cboAllMedicaments.ItemsSource = gst.getAllMedicaments();
            cboMedicamentsPerturbes.ItemsSource = gst.GetMedicamentPertub((cboAllMedicaments.SelectedItem as Medicament).DepotMedicament);            
        }

        private void btnAjouterMedicament_Click(object sender, RoutedEventArgs e)
        {
            if(cboMedicamentsPerturbes.SelectedItem == null)
            {
                MessageBox.Show("Vous devez sélectionner un médicaments perturbé.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Medicament perturbe = (cboMedicamentsPerturbes.SelectedItem as Interagir).EtrePerturbe;
                gst.AjouterMedicament(perturbe.NomMedicament, perturbe.CodeFamille.CodeFamille, perturbe.CompoMedicament, perturbe.EffetsMedicament,perturbe.ContreIndicMedicament, perturbe.PrixChantillon);
                gst.GetMedicamentNonPertub(perturbe.DepotMedicament);

                /*List<Medicament> nonPerturbeList = gst.getAllMedicaments();
                foreach (Medicament medic in nonPerturbeList)
                {
                    if(medic.DepotMedicament == perturbe.DepotMedicament)
                    {
                        nonPerturbeList.Remove(perturbe);
                    }
                }*/
            }
        }

        private void cboAllMedicaments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cboMedicamentsPerturbes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}