using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace Medinfsys
{
    public class DatabaseManager
    {
        private const string ConnectionString = "Data Source=DESKTOP-8604I9P\\SQLEXPRESS;Initial Catalog=GKB;Integrated Security=True";

        public static DataTable GetPatients()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Patients";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public static void InsertPatient(string firstname, string lastname, string middlename, string passportnumber, string birthdate, string gender, 
            string address, string phonenumber, string email, string medicalcardnumber, string medicalcardissuedate, string lastvisitdate, 
            string nextvisitdate, string insurancepolicynumber, string insurancepolicyexpirationdate, string diagnosis, string medicalhistory)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "INSERT INTO Patients (FirstName, LastName, MiddleName, PassportNumber, BirthDate, Gender, Address, PhoneNumber, Email, MedicalCardNumber, MedicalCardIssueDate," +
                    " LastVisitDate, NextVisitDate, InsurancePolicyNumber, InsurancePolicyExpirationDate, Diagnosis, MedicalHistory) " +
                    "VALUES (@FirstName, @LastName, @MiddleName, @PassportNumber, @BirthDate, @Gender, @Address, @PhoneNumber, @Email, @MedicalCardNumber, @MedicalCardIssueDate, " +
                    "@LastVisitDate, @NextVisitDate, @InsurancePolicyNumber, @InsurancePolicyExpirationDate, @Diagnosis, @MedicalHistory)";
                using (SqlCommand command = new SqlCommand(query, connection))
                { 
                    // параметры для всех полей пациента
                    command.Parameters.AddWithValue("@FirstName", firstname);
                command.Parameters.AddWithValue("@LastName", lastname);
                command.Parameters.AddWithValue("@MiddleName", middlename);
                command.Parameters.AddWithValue("@PassportNumber",passportnumber);
                command.Parameters.AddWithValue("@BirthDate", birthdate);
                command.Parameters.AddWithValue("@Gender", gender);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@PhoneNumber", phonenumber);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@MedicalCardNumber", medicalcardnumber);
                command.Parameters.AddWithValue("@MedicalCardIssueDate", medicalcardissuedate);
                command.Parameters.AddWithValue("@LastVisitDate", lastvisitdate);
                command.Parameters.AddWithValue("@NextVisitDate", nextvisitdate);
                command.Parameters.AddWithValue("@InsurancePolicyNumber", insurancepolicynumber);
                command.Parameters.AddWithValue("@InsurancePolicyExpirationDate", insurancepolicyexpirationdate);
                command.Parameters.AddWithValue("@Diagnosis", diagnosis);
                command.Parameters.AddWithValue("@MedicalHistory", medicalhistory);
                command.ExecuteNonQuery();
                }
            }

        }
        public static bool IsPatientExists(string medicalCardNumber)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Patients WHERE MedicalCardNumber = @MedicalCardNumber";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MedicalCardNumber", medicalCardNumber);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        public static void RecordHospitalization(int patientID, string hospitalizationCode, DateTime hospitalizationDate, string diagnosis, string hospitalDepartment, bool isPaid, string hospitalizationTime, bool isCancelled)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "INSERT INTO Hospitalization (PatientID, HospitalizationCode, HospitalizationDate, Diagnosis, HospitalDepartment, IsPaid, HospitalizationTime) " +
                "VALUES (@PatientID, @HospitalizationCode, @HospitalizationDate, @Diagnosis, @HospitalDepartment, @IsPaid, @HospitalizationTime, @IsCancelled)";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientID", patientID);
                    command.Parameters.AddWithValue("@HospitalizationCode", hospitalizationCode);
                    command.Parameters.AddWithValue("@HospitalizationDate", hospitalizationDate);
                    command.Parameters.AddWithValue("@Diagnosis", diagnosis);
                    command.Parameters.AddWithValue("@HospitalDepartment", hospitalDepartment);
                    command.Parameters.AddWithValue("@IsPaid", isPaid);
                    command.Parameters.AddWithValue("@HospitalizationTime", hospitalizationTime);
                    command.Parameters.AddWithValue("@IsCancelled", isCancelled);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void CancelHospitalization(int hospitalizationID, string cancellationReason)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "UPDATE Hospitalizations SET IsCancelled = 1, CancellationReason = @CancellationReason WHERE HospitalizationID = @HospitalizationID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@HospitalizationID", hospitalizationID);
                    command.Parameters.AddWithValue("@CancellationReason", cancellationReason);

                    command.ExecuteNonQuery();
                }
            }
        }
        public static DataTable GetPatientByID(int patientID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Patients WHERE PatientID = @PatientID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientID", patientID);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable patientData = new DataTable();
                    adapter.Fill(patientData);

                    return patientData;
                }
            }
        }
        public static void GenerateMedicalServiceContract(string patientName, string doctorName)
        {
            // Load template
            DocX document = DocX.Load("MedicalServiceContractTemplate.docx");

            // Replace placeholders with actual data
            document.ReplaceText("[PatientName]", patientName);
            document.ReplaceText("[DoctorName]", doctorName);

            // Save the filled document
            document.SaveAs("FilledMedicalServiceContract.docx");
        }
    }

}
