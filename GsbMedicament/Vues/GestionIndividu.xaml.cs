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
    /// Logique d'interaction pour GestionIndividu.xaml
    /// </summary>
    public partial class GestionIndividu : Page
    {
        public GestionIndividu()
        {
            InitializeComponent();
        }

        GstBdd gst;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new GstBdd();
            cboAllIndividus.ItemsSource = gst.getAllIndividu();
        }

        private void btnModifierIndividu_Click(object sender, RoutedEventArgs e)
        {
            if (cboAllIndividus.SelectedItem == null)
            {
                MessageBox.Show("Vous devez selectionner un individu.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (TxtLibelle == null)
            {
                MessageBox.Show("Vous devez entrer un libelle.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int codeTypeIndividu = (cboAllIndividus.SelectedItem as TypeIndividu).CodeTypeIndividu;
                string libelleTypeIndividu = TxtLibelle.Text;
                gst.UpdateIndividu(codeTypeIndividu, libelleTypeIndividu);

                MessageBox.Show("Ce type d'individu à été mis à jour.");
            }              
        }


        private void btnAjouterIndividu_Click(object sender, RoutedEventArgs e)
        {
            gst = new GstBdd();
            cboAllIndividus.ItemsSource = gst.getAllIndividu();
        }

        private void cboAllIndividus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboAllIndividus.SelectedItem != null)
            {
                string libelleTypeIndividu = (cboAllIndividus.SelectedItem as TypeIndividu).LibelleTypeIndividu;
                TxtCode.Text = libelleTypeIndividu;
            }
        }
    }
}
