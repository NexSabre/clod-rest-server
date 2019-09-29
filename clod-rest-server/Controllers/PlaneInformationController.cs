using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Reflection;

namespace clod_rest_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaneInformationController : ControllerBase
    {
        [HttpGet]
        public ServerInformation Get()
        {
            return new ServerInformation()
            {
                PlaneInformation = DictionaryToObject<PlaneInformation>(RefreshData())
        };
        }

        private Dictionary<string, double?> RefreshData()
        {
            var gameCommunications = new GameCommunications();
            var dataDict = new Dictionary<string, double?> { };

            foreach (GameCommunications.ParameterTypes parameter in (GameCommunications.ParameterTypes[])Enum.GetValues(typeof(GameCommunications.ParameterTypes)))
            {
                try
                {
                    dataDict.Add(parameter.ToString(), gameCommunications.GetParameter(Convert.ToInt32(parameter), 0));
                }
                catch
                {
                    dataDict.Add(parameter.ToString(), null);
                }

            }

            return dataDict;
        }

        private static T DictionaryToObject<T>(IDictionary<string, double?> dict) where T : new()
        {
            var t = new T();
            PropertyInfo[] properties = t.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (!dict.Any(x => x.Key.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase)))
                    continue;

                KeyValuePair<string, double?> item = dict.First(x => x.Key.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase));

                // Find which property type (int, string, double? etc) the CURRENT property is...
                Type tPropertyType = t.GetType().GetProperty(property.Name).PropertyType;

                // Fix nullables...
                Type newT = Nullable.GetUnderlyingType(tPropertyType) ?? tPropertyType;

                // ...and change the type
                object newA = Convert.ChangeType(item.Value, newT);
                t.GetType().GetProperty(property.Name).SetValue(t, newA, null);
            }
            return t;
        }

    }
}
