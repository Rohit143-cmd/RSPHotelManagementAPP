using RSPHotelManagementBAL.Interface.NavigationMenu;
using RSPHotelManagementDAL.Interface.NavigationMenu;
using RSPHotelManagementModel.NavigationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSPHotelManagementBAL.Service.NavigationMenu
{
    public class NavigationService : ServiceBase, INavigationService
    {
        INavigationRepository _navigationRepository;
        public NavigationService()
        {
            _navigationRepository = UnitOfWork.NavigationRepositoy;
        }
        public List<NavigationModel> GetAll()
        {
            try
            {
                var result = _navigationRepository.GetAll();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
