using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ParkingEntity;
using ParkingDAL;


namespace ParkingAPI.Controllers
{
    public class ParkingTransactionController : ApiController
    {
        private IParkingRepository _parkingRepository = null;
        ParkingTransactionController()
        {
            _parkingRepository = new ParkingRepository();
        }

        [Route("api/parkingtransaction/addparkingrequest")]
        [HttpPost, HttpGet]
        public int AddParkingRequest(int empId)
        {
            return _parkingRepository.AddParkingRequest(empId, DateTime.Now);
        }

        [Route("api/parkingtransaction/releaseparkingspot")]
        [HttpPost, HttpGet]
        public int ReleaseParkingSpot(int empId)
        {
            return _parkingRepository.ReleaseParkingSpot(empId);
        }
    }
}
