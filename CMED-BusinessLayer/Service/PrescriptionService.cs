using CMED_DataAcessLayer.Interface;
using CMED_DataAcessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMED_BusinessLayer.Service
{
    public class PrescriptionService
    {
        private readonly IPrescription prescription;
        public PrescriptionService(IPrescription _prescription)
        {
            prescription = _prescription;
        }
        public IEnumerable<Prescription> GetPrescriptions(int id)
        {
            return prescription.GetAll().Where(x => x.Prescription_Id == id).ToList();
        }
        public Prescription GetPrescriptionById(int id)
        {
            return prescription.GetById(id);
        }
        public IEnumerable<Prescription> GetAllPrescription()
        {
            try
            {
                return prescription.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Prescription> AddNewPrescription(Prescription p)
        {
            return await prescription.Create(p);
        }
        public async Task DeletePrescription(int id)
        {

            try
            {
                var DataList = prescription.GetById(id);
                prescription.Delete(DataList);

            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task UpdatePrescription(Prescription obj)
        {
            try
            {
                
                prescription.Update(obj);
                

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
