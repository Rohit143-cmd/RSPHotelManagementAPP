using RSPHotelManagementComman.Utility;
using RSPHotelManagementDAL.Comman;
using RSPHotelManagementDAL.Interface.NavigationMenu;
using RSPHotelManagementModel.NavigationModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSPHotelManagementDAL.Repository.NavigationMenu
{
    public class NavigationRepositoy: RepositoryBase<NavigationModel>, INavigationRepository
    {
        public NavigationRepositoy()
        {
            base.ConnectionString = base.GetTestDBConnectionString();
        }
        public List<NavigationModel> GetAll()
        {
            try
            {
                var sqlParameters = new List<SqlParameter>();
                //sqlParameters.Add(new SqlParameter("@ID", 2));
                return this.ExecuteReader("[dbo].[GetAllNavigation]", sqlParameters, NavigationMapping, Utility.GetCommandTimeOut());
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void NavigationMapping(NavigationModel model, SqlDataReader dataReader, string[] columnNameList)
        {
            int SystemMenuUUIDindex = this.GetColumnOrdinal(columnNameList, "SystemMenuUUID");
            if(SystemMenuUUIDindex >= 0 && !dataReader.IsDBNull(SystemMenuUUIDindex))
            {
                model.SystemMenuUUID = dataReader.GetFieldValue<Guid>(SystemMenuUUIDindex);
            }
            int Nameindex = this.GetColumnOrdinal(columnNameList, "Name");
            if(Nameindex >= 0 && !dataReader.IsDBNull(Nameindex))
            {
                model.Name = dataReader.GetFieldValue<string>(Nameindex);
            }
            int Descriptionindex = this.GetColumnOrdinal(columnNameList, "Description");
            if(Descriptionindex >= 0 && !dataReader.IsDBNull(Descriptionindex))
            {
                model.Description = dataReader.GetFieldValue<string>(Descriptionindex);
            }
            int URLindex = this.GetColumnOrdinal(columnNameList, "URL");
            if(URLindex >= 0 && !dataReader.IsDBNull(URLindex))
            {
                model.URL = dataReader.GetFieldValue<string>(URLindex);
            }
            int ChildMenuUUIDindex = this.GetColumnOrdinal(columnNameList, "ChildMenuUUID");
            if(ChildMenuUUIDindex >= 0 && !dataReader.IsDBNull(ChildMenuUUIDindex))
            {
                model.ChildMenuUUID = dataReader.GetFieldValue<Guid?>(ChildMenuUUIDindex);
            }
            int IsActiveindex = this.GetColumnOrdinal(columnNameList, "IsActive");
            if(IsActiveindex >= 0 && !dataReader.IsDBNull(IsActiveindex))
            {
                model.IsActive = dataReader.GetFieldValue<bool>(IsActiveindex);
            }
            int IsChildindex = this.GetColumnOrdinal(columnNameList, "IsChild");
            if(IsChildindex >= 0 && !dataReader.IsDBNull(IsChildindex))
            {
                model.IsChild = dataReader.GetFieldValue<bool>(IsChildindex);
            }
        }
    }
}
