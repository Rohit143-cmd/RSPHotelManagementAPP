using RSPHotelManagementModel.NavigationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSPHotelManagementBAL.Interface.NavigationMenu
{
    public interface INavigationService
    {
        List<NavigationModel> GetAll();
    }
}
