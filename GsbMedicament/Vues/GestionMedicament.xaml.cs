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
    /// Logique d'interaction pour GestionMedicament.xaml
    /// </summary>
    public partial class GestionMedicament : Window
    {
        public GestionMedicament()
        {
            InitializeComponent();
        }

        GstBdd gst;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new GstBdd();
            lstAllMedicaments.ItemsSource = gst.getAllMedicaments();
            lstGetFamille.ItemsSource = gst.getAllFamille();
        }

        private void btnModifierMedicament_Click(object sender, RoutedEventArgs e)
        {
            if (TxtNom.Text == null)
            {
                MessageBox.Show("Vous devez entrer un nom.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (lstGetFamille.SelectedItem == null)
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
                string nom = TxtNom.Text;
                int famille = (lstGetFamille.SelectedItem as Famille).CodeFamille;
                string compo = TxtCompo.Text;
                string effets = TxtEffets.Text;
                string contreIndic = TxtContreIndic.Text;
                string lePrix = TxtPrix.Text;
                double prix = Convert.ToDouble(lePrix);

                gst.UpdateMedicament(nom, famille, compo, effets, contreIndic, prix);
                lstAllMedicaments.ItemsSource = gst.getAllMedicaments();

                MessageBox.Show("Le médicament a bien été modifié.");
            }
        }

        private void btnAjouterMedicament_Click(object sender, RoutedEventArgs e)
        {
            if (TxtNom.Text == null)
            {
                MessageBox.Show("Vous devez entrer un nom.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (lstGetFamille.SelectedItem == null)
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
                string nom = TxtNom.Text;
                int famille = (lstGetFamille.SelectedItem as Famille).CodeFamille;
                string compo = TxtCompo.Text;
                string effets = TxtEffets.Text;
                string contreIndic = TxtContreIndic.Text;
                string lePrix = TxtPrix.Text;
                double prix = Convert.ToDouble(lePrix);

                gst.AjouterMedicament(nom, famille, compo, effets, contreIndic, prix);
                lstAllMedicaments.SelectedItem = gst.getAllMedicaments();
                lstAllMedicaments.ItemsSource = gst.getAllMedicaments();

                MessageBox.Show("Le médicament a bien été ajouté.");
            }
        }

        private void lstAllMedicaments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lstGetFamille_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
