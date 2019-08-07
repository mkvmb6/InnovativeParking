using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ParkingDAL;
using ParkingEntity;
using Newtonsoft;

namespace ParkingAPI.Controllers
{
    public class UserController : ApiController
    {
        private IParkingRepository _parkingRepository = null;
        public UserController()
        {
            _parkingRepository = new ParkingRepository();
        }

        [HttpGet]
        public string IsUserAuthenticated(string userName, string passWord)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(_parkingRepository.IsUserAuthenticted(userName, passWord));
            
        }
    }
}
