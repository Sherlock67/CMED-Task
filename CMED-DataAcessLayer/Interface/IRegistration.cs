﻿using CMED_DataAcessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMED_DataAcessLayer.Interface
{
    public interface IRegistration : IRepository<Registration>
    {
        Task<Registration> GetUserByEmailId(string EmailId);
    }
}
