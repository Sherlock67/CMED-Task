using CMED_DataAcessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMED_BusinessLayer.Service
{
    public class RegistrationService
    {
        private readonly IRegistration _reg;
        public RegistrationService(IRegistration reg)
        {
            _reg = reg;

        }
        public async Task<Registration> AddUserAsync(Registration r)
        {
            return await _reg.Create(r);
        }
        public async Task<bool> VerifyUserAsync(Login login)
        {
            var obj = await _reg.GetUserByEmailId(login.EmailId);
            if (obj != null)
            {
                if (obj.Password == login.Password)
                {
                    return true;

                }
            }
            return false;

        }
    }
}
