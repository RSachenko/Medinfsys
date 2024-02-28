using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medinfsys
{
    public class Patient
    {
        public byte[] Photo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PassportNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string MedicalCardNumber { get; set; }
        public DateTime MedicalCardIssueDate { get; set; }
        public DateTime LastVisitDate { get; set; }
        public DateTime NextVisitDate { get; set; }
        public string InsurancePolicyNumber { get; set; }
        public DateTime InsurancePolicyExpirationDate { get; set; }
        public string Diagnosis { get; set; }
        public string MedicalHistory { get; set; }
        public string HospitalizationCode { get; set; }
        public DateTime HospitalizationDate { get; set; }
    }
}
