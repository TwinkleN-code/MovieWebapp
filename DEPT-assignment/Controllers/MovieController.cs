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
        //public HttpClient client = new HttpClient();
        public Root movieData = new Root();

        //public IActionResult Index(string search)
        //{
        //    var task = GetData();

        //    //search = "Life and a Day"; //weghalen
        //    foreach(string item in movieData.title)
        //    {
        //        if (item == search)
        //        {
        //            return View(movieData);

        //        }
        //    }
        //    return Ok("Movie not found");

        //return View(movieData.title.Where(x => x.movieData.Contains(search)).ToList());
        //}

        //public string Index()
        //{
        //    var task = GetData();

        //    return movieData.title.ToString() + "  " + movieData.title[1].ToString();
        //}

        public async Task<IActionResult> Index(string search)
        {
            if (search != null)
            {
                using (var client = new HttpClient())
                {
                    //search = "Inception";
                    string path = "https://imdb-api.com/en/API/SearchMovie/k_z0vxj45u/" + search;
                    HttpResponseMessage response = await client.GetAsync(path);
                    response.EnsureSuccessStatusCode();
                    string data = await response.Content.ReadAsStringAsync();

                    movieData = JsonSerializer.Deserialize<Root>(data);
                }
            }
            //foreach (var item in movieData.title)
            //{
            //    if (movieData.title == "The life Of Pie")
            //    {
            //        return View(item);
            //    }
            //}
            
            return View(movieData); 
        }
    }
}
