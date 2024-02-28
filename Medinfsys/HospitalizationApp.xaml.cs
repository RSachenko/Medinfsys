using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для HospitalizationWindow.xaml
    /// </summary>
    public partial class HospitalizationWindow : Window
    {
        public HospitalizationWindow()
        {
            InitializeComponent();
        }

        private void RecordForHospitalization_Click(object sender, RoutedEventArgs e)
        {
            string hospitalizationCode = TextBoxHospitalizationCode.Text;
            DateTime hospitalizationDate = DatePickerHospitalization.SelectedDate ?? DateTime.Now;
            string hospitalizationTime = TextBoxHospitalizationTime.Text;
            int patientID;

            if (int.TryParse(TextBoxPatientID.Text, out patientID))
            {
                string diagnosis = TextBoxDiagnosis.Text;
                string hospitalDepartment = TextBoxHospitalDepartment.Text;
                bool isPaid = RadioButtonPaid.IsChecked ?? false;
                bool isCancelled = RadioButtonCancelled.IsChecked ?? false;

                DatabaseManager.RecordHospitalization(patientID, hospitalizationCode, hospitalizationDate, diagnosis, hospitalDepartment, isPaid, hospitalizationTime, isCancelled);
            }
            else
            {
                MessageBox.Show("Введите корректный идентификатор пациента.");
            }
        }

        private void TextBoxHospitalizationCode_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ConfirmPatientInfo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
