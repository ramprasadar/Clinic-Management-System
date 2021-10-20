using CmsAPI.Model;
using CmsAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsAPI.Provider
{
    public class PatientProv : IPatientProv
    {
        private readonly IPatient _repo;

        public PatientProv(IPatient repo)
        {
            _repo = repo;
        }

        public Patient AddPatient(Patient p)
        {
            _repo.AddPatient(p);
            return p;
        }

        public void DeletePatient(int id)
        {
            _repo.DeletePatient(id);
        }

        public List<Patient> GetPatient()
        {
            return _repo.GetPatient();
        }

        public Patient GetPatientById(int id)
        {
            return _repo.GetPatientById(id);
        }

        public bool PatientExists(int id)
        {
            return _repo.PatientExists(id);
        }

        public Patient UpdatePatient(int id, Patient p)
        {
            _repo.UpdatePatient(id, p);
            return p;
        }
    }
}
