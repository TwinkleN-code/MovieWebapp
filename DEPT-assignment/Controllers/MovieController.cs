using DEPT_assignment.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DEPT_assignment.Controllers
{
    public class MovieController : Controller
    {
        public Root movieData = new Root();
        public async Task<IActionResult> Index(string search)
        {
            if (search != null)
            {
                using (var client = new HttpClient())
                {
                    string path = "https://imdb-api.com/en/API/SearchMovie/k_z0vxj45u/" + search;
                    HttpResponseMessage response = await client.GetAsync(path);
                    response.EnsureSuccessStatusCode();
                    string data = await response.Content.ReadAsStringAsync();

                    movieData = JsonSerializer.Deserialize<Root>(data);
                }
            }
            return View(movieData); 
        }
    }
}
