using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingDAL
{
    public interface ISQLAdapter
    {
        int Execute(string sqlCommand);

        IEnumerable<dynamic> Query(string sqlCommand);
    }
}
