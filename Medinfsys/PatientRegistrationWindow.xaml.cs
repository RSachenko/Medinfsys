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

namespace Medinfsys
{
    /// <summary>
    /// Логика взаимодействия для PatientRegistrationWindow.xaml
    /// </summary>
    public partial class PatientRegistrationWindow : Window
    {
        public PatientRegistrationWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            Loaded += PatientRegistrationWindow_Loaded;
        }

        private void PatientRegistrationWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Patients.ItemsSource = DatabaseManager.GetPatients().DefaultView;
        }

        private void Patients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Обработка изменения выбора, если нужно
        }


        private void RegisterPatient_Click(object sender, RoutedEventArgs e)
        {
            Patient newPatient = new Patient
            {
                // Инициализация данных о пациенте из элементов управления в окне
                // Пример: newPatient.FirstName = TextBoxFirstName.Text;
            };

        }

        private void AddNewPatient_Click(object sender, RoutedEventArgs e)
        {
            // Открываете окно для добавления нового пациента
            AddNewPatientWindow addNewPatientWindow = new AddNewPatientWindow();
            addNewPatientWindow.Owner = this;
            addNewPatientWindow.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            QRCode qRCode = new QRCode();
            qRCode.Show();
            Close();
        }
    }
}
