using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSPHotelManagementModel.NavigationModel
{
    [Serializable]
    public class NavigationModel
    {
        public Guid SystemMenuUUID;
        public string Name;
        public string Description;
        public string URL;
        public Guid? ChildMenuUUID;
        public bool IsChild; 
        public bool IsActive; 
    }
}
