using RSPHotelManagementBAL.Interface.NavigationMenu;
using RSPHotelManagementModel.NavigationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RSPHotelManagementAPI.Controllers.NavigationMenu
{
    public class NavigationController : BaseController
    {
        INavigationService _navigationService;
        public NavigationController()
        {
            _navigationService = UnitOfWork.NavigationService;
        }
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            HttpResponseMessage response = HttpResponse(HttpStatusCode.InternalServerError); 
            try
            {
                var result = _navigationService.GetAll();
                response = SuccessResponses(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}
