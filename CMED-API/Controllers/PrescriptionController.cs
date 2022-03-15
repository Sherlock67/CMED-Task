using CMED_BusinessLayer.Service;
using CMED_DataAcessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CMED_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly PrescriptionService _prescription;
        public PrescriptionController(PrescriptionService prescription)
        {
            _prescription = prescription;

        }
        [HttpPost("CreatePrescription")]
        public async Task<Object> CreatePrescription([FromBody] Prescription prescription)
        {
            try
            {
                await _prescription.AddNewPrescription(prescription);
                return true;
                
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpGet("GetAllPrescription")]
        public Object GetAllPrescription()
        {
            var data = _prescription.GetAllPrescriptions();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
        [HttpDelete("DeletePerson")]
        public bool DeletePrescription(int id)
        {
            try
            {
                _prescription.DeletePrescription(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPut("UpdatePrescription")]
        public bool UpdatePrescription(int id)
        {
            try
            {
                _prescription.UpdatePrescription(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
