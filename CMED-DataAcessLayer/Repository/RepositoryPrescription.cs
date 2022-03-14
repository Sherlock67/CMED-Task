using CMED_DataAcessLayer.Data;
using CMED_DataAcessLayer.Interface;
using CMED_DataAcessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMED_DataAcessLayer.Repository
{
    public class RepositoryPrescription : IPrescription
    {
        private readonly ApplicationDbContext _db;
        public RepositoryPrescription(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Prescription> Create(Prescription entity)
        {
            var obj = await _db.Prescriptions.AddAsync(entity);
            _db.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Prescription entity)
        {
            _db.Remove(entity);
            _db.SaveChanges();
        }

        public IEnumerable<Prescription> GetAll()
        {
            try
            {
                return _db.Prescriptions.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Prescription GetById(int Id)
        {
            return _db.Prescriptions.Where(x => x.Prescription_Id == Id).SingleOrDefault();
        }

        public void Update(Prescription entity)
        {
            _db.Prescriptions.Update(entity);
            _db.SaveChanges();
        }
    }
}
