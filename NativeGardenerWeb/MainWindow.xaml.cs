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
using DataObjects;
using LogicLayer;

namespace ZombieVeggieTales
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PlantManager _plantManager = new PlantManager();
        private List<Plant> _viewPlants;
        public MainWindow()
        {
            InitializeComponent();
        }
        //private void btnAddPlant_Click(object sender, RoutedEventArgs e)
        //{
        //    var addPlantForm = new frmAddPlant(_plantManager);
        //    addPlantForm.ShowDialog();
        //}

        private void dgViewPlants_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //var plant = (Plant)dgViewPlants.SelectedItem;
            //_viewPlants = _plantManager.RetrieveSelectedPlants(soilType, growingZone);
            //dgViewPlants.Items.Refresh();
            //dgViewPlants.Focus();
        }

        private void tabViewPlants_GotFocus(object sender, RoutedEventArgs e)
        {
            //dgViewPlants.ItemsSource = _viewPlants;
        }
    }
}
