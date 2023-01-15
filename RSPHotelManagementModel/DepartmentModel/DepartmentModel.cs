using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSPHotelManagementModel.DepartmentModel
{
    public class DepartmentModel
    {
        public Guid RommDepartmentUUID { get; set; }
        public Guid UserUUID { get; set; }
        public string RoomDepartmentName{ get; set; }
        public string Description { get; set; }
        public double RoomPrice { get; set; }
        public bool IsActive{ get; set; }
        public bool IsDeleted{ get; set; }
        public bool IsUpdated{ get; set; }
        public bool CreatedBy { get; set; }
        public bool CreatedOn { get; set; }
        public bool LastUpdatedBy { get; set; }
        public bool LastUpdatedOn { get; set; }

    }
}
