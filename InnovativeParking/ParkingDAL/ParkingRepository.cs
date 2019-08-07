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
            var sqlCommand = "Select E.EmployeeID, E.EmployeeFirstName, E.EmployeeLastName, R.RoleTitle " +
                "from MasterEmployee E inner join MasterRoles R on R.RoleID = E.RoleID" +
                " where E.EmployeeEmail ='" + userName + "' and E.EmployeePwd='" + passWord + "'";
            dynamic resultVal = _sqlAdapter.Query(sqlCommand).First();

            return new EmployeeEntity
            {
                Id = resultVal.EmployeeID,
                EmpName = resultVal.EmployeeFirstName + " " + resultVal.EmployeeLastName,
                RoleTitle = resultVal.RoleTitle
            };
        }

        public int AddParkingRequest(int empId, DateTime requestDateTime)
        {
            var sqlCommand = "Insert into ParkingRequest Values(" + empId + ",'" + requestDateTime +"')";
            return _sqlAdapter.Execute(sqlCommand);
        }

        public int ReleaseParkingSpot(int empId)
        {
            var sqlCommand = "Insert into Release (EmployeeID, ParkingSlotID, CreatedDate, ReleaseDate)" +
                "Select EmployeeID, ParkingSlotID, GetDate(), GetDate() + 1 from MasterReservedSlots " +
                "where EmployeeID = " + empId;
            return _sqlAdapter.Execute(sqlCommand);
        }


        public List<dynamic> AllotParking()
        {
            List<dynamic> myList = new List<dynamic>();
            string query = @"select * from MasterParkingSlots where ParkingSlotID NOT IN(
                                select ParkingSlotID from MasterReservedSlots
                                UNION
                                select ParkingSlotID from TranParking 
                                    where Cast(DateAllotted as date)= cast(GETDATE() + 1 as date))
                            UNION
                            (select p.* from Release r inner join MasterParkingSlots p 
                            on r.ParkingSlotID = p.ParkingSlotID
                            where Cast(ReleaseDate as date) = cast(GETDATE() + 1 as date))";
            string sqlCommand = @"select e.EmployeeID, Year(e.EmployeeDOJ)-Year(GetDate()) as Experience 
                                from ParkingRequest r inner join MasterEmployee e
                                on r.EmployeeID=e.EmployeeID";

            myList.Add(_sqlAdapter.Query(query));
            myList.Add(_sqlAdapter.Query(sqlCommand));

            return myList;
        }
    }
}
