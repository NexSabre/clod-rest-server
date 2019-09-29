using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clod_rest_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase 
    {
        class PlaneType
        {
            public string C_PlaneType { get; set; }
        }

        [HttpGet]
        public IEnumerable<HomeController> Get()
        //public Dictionary<string, HomeController.PlaneType> Get()
        {
            var dataDict = new Dictionary<string, HomeController.PlaneType>()
            { {"one", new PlaneType { C_PlaneType="asd" } } };
            //return dataDict;
            return Enumerable.Range(1, 4).Select(index => new HomeController { }).ToArray();
        }
        //// GET: /<controller>/        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
