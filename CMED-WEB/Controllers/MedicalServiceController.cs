using CMED_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CMED_WEB.Controllers
{
    public class MedicalServiceController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Root> Service = new List<Root>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://rxnav.nlm.nih.gov/REST/interaction/interaction.json?rxcui=341248"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Service = JsonConvert.DeserializeObject<List<Root>>(apiResponse);
                }
            }
            return View(Service);
        }

    }
}
