using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;

namespace EzBusiness_ViewModels.Models.Login
{
    public class LoginVM
    {
        public string user_name { get; set; }
        public string PassW { get; set; }
        public string CmpyCode { get; set; }
        public string DivCode { get; set; }
        public string BraCode { get; set; }
        public string DepCode { get; set; }     
        public bool IsLogOutFlag { get; set; }
        public bool IsLogInFlag { get; set; }
        public string ErrorMessage { get; set; }
        public string PhotoPath { get; set; }
        public string EmpName { get; set; }

        //public List<SessionListnew> SessionListnew { get; set; }
        //public SessionListnew SessionDet { get; set; }


    }

    //public class SessionListnew
    //{
    //    public string user_name { get; set; }
    //    public string CmpyCode { get; set; }

    //    public string Divcode { get; set; }
    //    public string BraCode { get; set; }

    //    public string DepCode { get; set; }
    //}
}
