using CMED_DataAcessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

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
            TempData["success"] = "Prescription Created";
            return View();
            
        }

        public async Task<ActionResult> DeletePrescription(int? id)
        {
            string custommsg = string.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMsg = await client.DeleteAsync("/api/Prescription/DeletePrescription?id=" + id);
                if (responseMsg.IsSuccessStatusCode)
                {
                    var res = responseMsg.Content.ReadAsStringAsync().Result;
                    custommsg = JsonConvert.DeserializeObject<string>(res);
                }
            }
            TempData["success"] = "Prescription Deleted";
            return RedirectToAction("AllPrescription");
            
        }
        [HttpGet]
        public async Task<IActionResult> UpdatePrescription(int id)
        {
            Prescription prescription = new Prescription();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var prescriptionId = await client.GetAsync("/api/Prescription/GetPrescriptionById?id=" +id);
                if (prescriptionId.IsSuccessStatusCode)
                {
                    var prescriptionlist = prescriptionId.Content.ReadAsStringAsync().Result;
                    prescription = JsonConvert.DeserializeObject<Prescription>(prescriptionlist);
                }
              
            }
            return View(prescription);
          
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePrescription(Prescription prescription)
        {
            
            string custommsg = string.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMsg = await client.PutAsJsonAsync("/api/Prescription/UpdatePrescription", prescription);
                if (responseMsg.IsSuccessStatusCode)
                {
                    var res = responseMsg.Content.ReadAsStringAsync().Result;
                    custommsg = JsonConvert.DeserializeObject<string>(res);
                }
            }
            TempData["success"] = "Prescription Edited";
            return RedirectToAction("AllPrescription");
            
        }

    }
}
