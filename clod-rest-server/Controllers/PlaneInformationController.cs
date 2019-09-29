using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace clod_rest_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaneInformationController : ControllerBase
    {

        private PlaneInformation RefreshData()
        {
            var planeInformation = new PlaneInformation();
            var gameCommunications = new GameCommunications();
            planeInformation.I_EngineRPM = gameCommunications.GetParameter(GameCommunications.ParameterTypes.I_EngineRPM, 0);
            return planeInformation;
        }

        [HttpGet]
        public ServerInformation Get()
        {
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new PlaneInformation
            //{})
            //.ToArray();

            return new ServerInformation()
            {
                planeInformation = RefreshData()
            };
        }
    }
}
