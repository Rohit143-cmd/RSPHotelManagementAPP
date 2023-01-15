using RSPHotelManagementModel.NavigationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSPHotelManagementDAL.Interface.NavigationMenu
{
    public interface INavigationRepository
    {
        List<NavigationModel> GetAll();
    }
}
