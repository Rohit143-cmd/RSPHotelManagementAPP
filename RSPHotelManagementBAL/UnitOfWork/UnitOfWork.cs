using RSPHotelManagementBAL.Service.NavigationMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSPHotelManagementBAL.UnitOfWork
{
    public class UnitOfWork
    {
        private NavigationService _navigationService;
        public NavigationService NavigationService
        {
            get { return _navigationService ?? (_navigationService = new NavigationService()); }
        }
    }
}
