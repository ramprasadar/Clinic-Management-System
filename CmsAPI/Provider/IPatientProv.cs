using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CmsAPI.Model;

namespace CmsAPI.Provider
{
 public interface IPatientProv
    {
        public List<Patient> GetPatient();
        public Patient GetPatientById(int id);
        public Patient AddPatient(Patient p);
        public Patient UpdatePatient(int id, Patient p);
        public void DeletePatient(int id);

        public bool PatientExists(int id);
    }
}
