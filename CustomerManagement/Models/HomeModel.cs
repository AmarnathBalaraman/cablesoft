using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerManagement.Models
{
    public class HomeModel
    {
    }

    public class DashboardModels
    {
        public string UsersList { get; set; }
        public string ActiveUsers { get; set; }
        public string InActiveUsers { get; set; }
        public string ArchivedUsers { get; set; }

    }

    public class Menu_List
    {
        public int M_ID { get; set; }
        public int? M_P_ID { get; set; }
        public string M_NAME { get; set; }
        public string CONTROLLER_NAME { get; set; }
        public string ACTION_NAME { get; set; }
    }

    public class MenuModels
    {

        public string MainMenuName { get; set; }
        public int MainMenuId { get; set; }
        public string SubMenuName { get; set; }
        public int SubMenuId { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
    }  
}