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

namespace Medinfsys
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            AddNewPatientWindow addNewPatientWindow = new AddNewPatientWindow();
            addNewPatientWindow.Show();
            Close();
        }

        private void Hospitalization_Click(object sender, RoutedEventArgs e)
        {
            HospitalizationWindow HospitalizationWindow = new HospitalizationWindow();
            HospitalizationWindow.Show();
            Close();
        }

        private void Diagnostic_Копировать_Click(object sender, RoutedEventArgs e)
        {
            HospitalTrackingApp hospitalTrackingApp = new HospitalTrackingApp();
            hospitalTrackingApp.Show();
            Close();
        }
    }
}
