using CMED_DataAcessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CMED_WEB.Controllers
{
    public class UserController : Controller
    {
        private static string url = "https://localhost:7075/";
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(Registration registration)
        {
            string custommsg = string.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMsg = await client.PostAsJsonAsync("/api/Prescription/CreateUser", registration);
                if (responseMsg != null)
                {
                    var res = responseMsg.Content.ReadAsStringAsync().Result;
                    custommsg = JsonConvert.DeserializeObject<string>(res);
                }
            }
            return View();
        }
    }
}
