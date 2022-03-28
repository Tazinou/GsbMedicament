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
    /// Logique d'interaction pour GestionPerturbateur.xaml
    /// </summary>
    public partial class GestionPerturbateur : Window
    {
        public GestionPerturbateur()
        {
            InitializeComponent();
        }

        GstBdd gst;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new GstBdd();
            lstMedicaments.ItemsSource = gst.getAllMedicaments();
        }

        private void btnAjouterMedicament_Click(object sender, RoutedEventArgs e)
        {
            if (lstMedicaments.SelectedItem != null)
            {
                if (lstMedicNonPertub.SelectedItem != null)
                {
                    gst.AjouterMedicamentPertub((lstMedicNonPertub.SelectedItem as Medicament).DepotMedicament, (lstMedicaments.SelectedItem as Medicament).DepotMedicament);
                }
            }
            lstMedicPertub.ItemsSource = gst.GetMedicamentPertub((lstMedicaments.SelectedItem as Medicament).DepotMedicament);
            lstMedicNonPertub.ItemsSource = gst.GetMedicamentNonPertub((lstMedicaments.SelectedItem as Medicament).DepotMedicament);


            /*List<Medicament> nonPerturbeList = gst.getAllMedicaments();
                foreach (Medicament medic in nonPerturbeList)
                {
                    if(medic.DepotMedicament == perturbe.DepotMedicament)
                    {
                        nonPerturbeList.Remove(perturbe);
                    }
                }*/
        }

        private void lstMedicaments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstMedicaments.SelectedItem != null)
            {
                lstMedicPertub.ItemsSource = gst.GetMedicamentPertub((lstMedicaments.SelectedItem as Medicament).DepotMedicament);
                lstMedicNonPertub.ItemsSource = gst.GetMedicamentNonPertub((lstMedicaments.SelectedItem as Medicament).DepotMedicament);
            }
        }

        private void lstMedicPertub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lstMedicNonPertub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
