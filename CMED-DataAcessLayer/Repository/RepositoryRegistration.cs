using CMED_DataAcessLayer.Data;
using CMED_DataAcessLayer.Interface;
using CMED_DataAcessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMED_DataAcessLayer.Repository
{
    public class RepositoryRegistration :IRegistration 
    {
        private readonly ApplicationDbContext _db;
        public RepositoryRegistration(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Registration> Create(Registration entity)
        {
            var obj = await _db.Registrations.AddAsync(entity);
            _db.SaveChanges();
            return obj.Entity; ;
        }

        public void Delete(Registration entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Registration> GetAll()
        {
            throw new NotImplementedException();
        }

        public Registration GetById(int Id)
        {
            var obj = _db.Registrations.SingleOrDefault(x => x.UserId == Id);
            return obj;
        }

        public async Task<Registration> GetUserByEmailId(string EmailId)
        {
            var obj = await _db.Registrations.SingleOrDefaultAsync(x => x.Email == EmailId);
            return obj;
        }

        public void Update(Registration entity)
        {
            throw new NotImplementedException();
        }
    }
}
