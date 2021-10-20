using CmsAPI.Model;
using CmsAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsAPI.Provider
{
    public class DocProv : IDocProv
    {
        private readonly IDoctor _repo;

        public DocProv() { }

        public DocProv(IDoctor repo)
        {
            _repo = repo;
        }

        public Doctor AddDoctor(Doctor d)
        {
            _repo.AddDoctor(d);
            return d;
        }

        public void DeleteDoctor(int id)
        {
            _repo.DeleteDoctor(id);
        }

        public bool DoctorExists(int id)
        {
            return _repo.DoctorExists(id);
        }

        public List<Doctor> GetDoctor()
        {
            return _repo.GetDoctor();
        }

        public Doctor GetDoctorById(int id)
        {
            return _repo.GetDoctorById(id);
        }

        public Doctor UpdateDoctor(int id, Doctor d)
        {
            _repo.UpdateDoctor(id, d);
            return d;
        }
        public int DoctorIDByDoctorName(string name)
        {
            return _repo.DoctorIDByDoctorName(name);
        }

        public List<int> VisitinghourList(int id)
        {
            return _repo.VisitinghourList(id);
        }

        public List<int> BookedAppointment(string name, DateTime visitdate)
        {
            return _repo.BookedAppointment(name, visitdate);
        }
    }
}
