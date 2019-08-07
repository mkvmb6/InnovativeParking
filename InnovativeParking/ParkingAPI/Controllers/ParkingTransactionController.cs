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

        [HttpGet]
        public IHttpActionResult RunLottery()
        {
            List<dynamic> result = _parkingRepository.AllotParking();

            dynamic ptempList = result[0];
            dynamic etempList = result[1];

            List<ParkingEntity> pList = new List<ParkingEntity>();
            foreach (dynamic p in ptempList)
            {
                ParkingEntity pen = new ParkingEntity();
                pen.PID = p.ParkingSlotID;
                pen.Wing = p.ParkingSlotWing;

                pList.Add(pen);
            }

            List<EmployeeEntity> eList = new List<EmployeeEntity>();
            foreach (dynamic e in etempList)
            {
                EmployeeEntity een = new EmployeeEntity();
                een.Id = e.EmployeeID;
                een.RoleTitle = e.RoleTitle;

                eList.Add(een);
            }

            if (pList.Count > eList.Count)
            {
                //assign parking slot to each employee randomly

            }
            else
            {
                //assign parking slot for random employee
            }
            return Ok();
        }

        public class ParkingEntity
        {
            public int PID;
            public string Wing;
        }
    }
}
