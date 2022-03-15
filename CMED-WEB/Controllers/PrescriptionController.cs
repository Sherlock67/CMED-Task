using CMED_DataAcessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CMED_WEB.Controllers
{
    public class PrescriptionController : Controller
    {
        private static string url = "https://localhost:7075/";
        
        public async Task<IActionResult> AllPrescription()
        {
            List<Prescription> listprescription = new List<Prescription>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMsg = await client.GetAsync("/api/Prescription/GetAllPrescription");
                if (responseMsg!=null)
                {
                    var prescriptionlist = responseMsg.Content.ReadAsStringAsync().Result;
                    listprescription = JsonConvert.DeserializeObject<List<Prescription>>(prescriptionlist);
                }
            }
            
            return View(listprescription);
        }
        [HttpGet]
        public IActionResult AddPrescription()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPrescription(Prescription prescription)
        {
            string custommsg = string.Empty;
            using(var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMsg = await client.PostAsJsonAsync("/api/Prescription/CreatePrescription", prescription);
                if (responseMsg!= null)
                {
                    var res = responseMsg.Content.ReadAsStringAsync().Result;
                    custommsg = JsonConvert.DeserializeObject<string>(res);
                }
            }
            return View();
        }

    }
}
