using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
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
using Microsoft.Win32;

namespace Medinfsys
{
    /// <summary>
    /// Логика взаимодействия для AddNewPatientWindow.xaml
    /// </summary>
    public partial class AddNewPatientWindow : Window
    {

        private string generatedMedicalCardNumber;

        public AddNewPatientWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

        private void AddNewPatientWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Генерируем идентификационный код медицинской карты при загрузке окна
            generatedMedicalCardNumber = GenerateMedicalCardNumber();
            TextBoxMedicalCardNumber.Text = generatedMedicalCardNumber;
        }
        private string GenerateMedicalCardNumber()
        {
            string medicalCardNumber = Guid.NewGuid().ToString("N").Substring(0, 10);
            return medicalCardNumber;
        }

        private void SaveNewPatient_Click(object sender, RoutedEventArgs e)
        {
            {
                string firstname = TextBoxFirstName.Text;
                string lastname = TextBoxLastName.Text;
                string middlename = TextBoxMiddleName.Text;
                string passportnumber = TextBoxPassportNumber.Text;
                string birthdate = TextBoxBirthDate.Text;
                string gender = TextBoxGender.Text;
                string address = TextBoxAddress.Text;
                string phonenumber = TextBoxPhoneNumber.Text;
                string email = TextBoxEmail.Text;
                string medicalcardnumber = TextBoxMedicalCardNumber.Text;
                string medicalcardissuedate = TextBoxMedicalCardIssueDate.Text;
                string lastvisitdate = TextBoxLastVisitDate.Text;
                string nextvisitdate = TextBoxNextVisitDate.Text;
                string insurancepolicynumber = TextBoxInsurancePolicyNumber.Text;
                string insurancepolicyexpirationdate = TextBoxInsurancePolicyExpirationDate.Text;
                string diagnosis = TextBoxDiagnosis.Text;
                string medicalhistory = TextBoxMedicalHistory.Text;


                if (!IsPatientExists(medicalcardnumber))
                {
                    DatabaseManager.InsertPatient(firstname, lastname, middlename, passportnumber, birthdate, gender, address, phonenumber, email,
                        medicalcardnumber, medicalcardissuedate, lastvisitdate, nextvisitdate, insurancepolicynumber, insurancepolicyexpirationdate, diagnosis, medicalhistory);
                    Close();
                }
                else
                {
                    MessageBox.Show("Пациент с таким идентификационным кодом уже существует.");
                }



            }
        }

        private bool IsPatientExists(string medicalCardNumber)
        {
            //Логика проверки наличия пациента в системе
            return DatabaseManager.IsPatientExists(medicalCardNumber);
        }

        private void TextBoxMedicalCardNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PatientRegistrationWindow patientRegistrationWindow = new PatientRegistrationWindow();
            patientRegistrationWindow.Show();
            Close();
        }

        private void SelectPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedImagePath = openFileDialog.FileName;

                // Отобразить выбранное изображение в элементе Image
                BitmapImage bitmapImage = new BitmapImage(new Uri(selectedImagePath));
                PatientPhoto.Source = bitmapImage;
            }
        }
    }
}
