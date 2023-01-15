using CollegeManagementComman.APIURLConstant;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RSPHotelManagementAPP.Helpers;
using RSPHotelManagementModel.NavigationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RSPHotelManagementAPP.HeaderAndFooter
{
    public partial class Header : System.Web.UI.UserControl
    {
        public List<NavigationModel> navigationModels
        {
            get
            {
                return ViewState["navigationModels"] != null ? (List<NavigationModel>)ViewState["navigationModels"] : new List<NavigationModel>();
            }
            set
            {
                ViewState["navigationModels"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAll();
        }
        public List<NavigationModel> GetAll()
        {
            var getURL = APIURLConstant.NavigationBar_GetAll;
            var response = RequestHelper.Get(getURL);
            var result = new List<NavigationModel>();
            if(response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<List<NavigationModel>>(JObject.Parse(response.Content)["data"].ToString());
            }
            navigationModels = result;
            return result;
        }

        protected void searchbtn_Click(object sender, EventArgs e)
        {

        }
    }
}