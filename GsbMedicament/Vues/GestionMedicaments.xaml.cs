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
    /// Logique d'interaction pour GestionMedicaments.xaml
    /// </summary>
    public partial class GestionMedicaments : Page
    {
        public GestionMedicaments()
        {
            InitializeComponent();
        }

        GstBdd gst;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new GstBdd();
            cboAllMedicaments.SelectedItem = gst.getAllMedicaments();
            cboFamille.ItemsSource = gst.getAllMedicaments();       
        }

        private void btnModifierMedicament_Click(object sender, RoutedEventArgs e)
        {
            if (TxtDepotLegal.Text == null)
            {
                MessageBox.Show("Vous devez entrer un dépot légal.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (TxtNom.Text == null)
            {
                MessageBox.Show("Vous devez entrer un nom.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (cboFamille.SelectedItem == null)
            {
                MessageBox.Show("Vous devez entrer une famille.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (TxtCompo.Text == null)
            {
                MessageBox.Show("Vous devez entrer une composition.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (TxtEffets.Text == null)
            {
                MessageBox.Show("Vous devez entrer des effets.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (TxtContreIndic.Text == null)
            {
                MessageBox.Show("Vous devez entrer des contre indications.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (TxtPrix.Text == null)
            {
                MessageBox.Show("Vous devez entrer un prix.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int depotLegal = Convert.ToInt32(TxtDepotLegal);
                string nom = TxtNom.Text;
                int famille = (cboFamille.SelectedItem as Famille).CodeFamille;
                string compo = TxtCompo.Text;
                string effets = TxtEffets.Text;
                string contreIndic = TxtContreIndic.Text;
                double prix = Convert.ToDouble(TxtPrix);

                gst.UpdateMedicament(depotLegal, nom, famille, compo, effets, contreIndic, prix);
                cboAllMedicaments.ItemsSource = gst.getAllMedicaments();
            }
        }

        private void btnAjouterMedicament_Click(object sender, RoutedEventArgs e)
        {
            if (TxtDepotLegal.Text == null)
            {
                MessageBox.Show("Vous devez entrer un dépot légal.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (TxtNom.Text == null)
            {
                MessageBox.Show("Vous devez entrer un nom.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (cboFamille.SelectedItem == null)
            {
                MessageBox.Show("Vous devez entrer une famille.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (TxtCompo.Text == null)
            {
                MessageBox.Show("Vous devez entrer une composition.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (TxtEffets.Text == null)
            {
                MessageBox.Show("Vous devez entrer des effets.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (TxtContreIndic.Text == null)
            {
                MessageBox.Show("Vous devez entrer des contre indications.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (TxtPrix.Text == null)
            {
                MessageBox.Show("Vous devez entrer un prix.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int depotLegal = Convert.ToInt32(TxtDepotLegal);
                string nom = TxtNom.Text;
                int famille = (cboFamille.SelectedItem as Famille).CodeFamille;
                string compo = TxtCompo.Text;
                string effets = TxtEffets.Text;
                string contreIndic = TxtContreIndic.Text;
                double prix = Convert.ToDouble(TxtPrix);

                gst.AjouterMedicament(nom, famille, compo, effets, contreIndic, prix);
                cboAllMedicaments.SelectedItem = gst.getAllMedicaments();
                cboAllMedicaments.ItemsSource = gst.getAllMedicaments();
            }
        }

        private void cboAllMedicaments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboAllMedicaments.SelectedItem != null)
            {
                int allMedicament = (cboAllMedicaments.SelectedItem as Medicament).DepotMedicament;
            }
        }

        private void TxtDepotLegal_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }       
}