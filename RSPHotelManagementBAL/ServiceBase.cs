using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSPHotelManagementDAL.UnitOfWork;
namespace RSPHotelManagementBAL
{
    public class ServiceBase
    {
        protected static readonly RSPHotelManagementDAL.UnitOfWork.UnitOfWork UnitOfWork = new RSPHotelManagementDAL.UnitOfWork.UnitOfWork();
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            GC.SuppressFinalize(this);
        }
    }
}
