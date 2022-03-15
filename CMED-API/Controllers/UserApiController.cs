using CMED_BusinessLayer.Service;
using CMED_DataAcessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMED_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly RegistrationService _registration;
        public UserApiController(RegistrationService registration)
        {
            _registration = registration;

        }
        [HttpPost("CreateUser")]
        public async Task<Object> CreateUser([FromBody] Registration registration)
        {
            try
            {
                await _registration.AddUserAsync(registration);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        //[HttpGet("UserLogin")]
        //public async Task<RedirectToActionResult> UserLogin(Login login)
        //{
            
        //    var obj = _registration.VerifyUserAsync(login);
            
        //    if (obj !=null)
        //    {
        //        return RedirectToAction("AllPrescription","Prescription");
        //    }
        //    else
        //    {
        //        return RedirectToAction("AddUser", "User");
        //    }
           
           
        //}



    }
}
