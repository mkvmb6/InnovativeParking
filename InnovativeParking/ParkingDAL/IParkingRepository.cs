using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingEntity;

namespace ParkingDAL
{
    public interface IParkingRepository
    {
        EmployeeEntity IsUserAuthenticted(string userName, string passWord);
    }
}
