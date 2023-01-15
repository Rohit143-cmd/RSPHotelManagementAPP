using RSPHotelManagementDAL.Repository.NavigationMenu;
using RSPHotelManagementDAL.Repository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSPHotelManagementDAL.UnitOfWork
{
    public class UnitOfWork
    {
        private UserRepository _userRepository;
        public UserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository()); }
        }
        private NavigationRepositoy _navigationRepositoy;
        public NavigationRepositoy NavigationRepositoy
        {
            get { return _navigationRepositoy ?? (_navigationRepositoy = new NavigationRepositoy()); }
        }
    }
}
