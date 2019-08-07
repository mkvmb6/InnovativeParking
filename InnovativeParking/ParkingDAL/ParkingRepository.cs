using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingEntity;
using Mapster;

namespace ParkingDAL
{
    public class ParkingRepository : IParkingRepository
    {
        private ISQLAdapter _sqlAdapter = null;

        public ParkingRepository(): this(null)
        {

        }

        public ParkingRepository(SQLAdapter sQLAdapter)
        {
            _sqlAdapter = sQLAdapter ?? new SQLAdapter();
        }

        public EmployeeEntity IsUserAuthenticted(string userName, string passWord)
        {
            var sqlCommand = "Select EmployeeID, EmployeeFirstName, EmployeeLastName  from MasterEmployee where EmployeeEmail ='" + userName + "' and EmployeePwd='" + passWord + "'";
            dynamic resultVal = _sqlAdapter.Query(sqlCommand).First();

            return new EmployeeEntity
            {
                Id = resultVal.EmployeeID,
                EmpName = resultVal.EmployeeFirstName + " " + resultVal.EmployeeLastName
            };
        }

        public void AddParkingRequest(int empId, DateTime requestDateTime)
        {
               
        }

        public void AllotParking()
        {

        }

        public void ReleaseParkingSpot(int empId)
        {
            
        }

        
    }
}
