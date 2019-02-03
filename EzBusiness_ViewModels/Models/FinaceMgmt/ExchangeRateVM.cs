using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;


namespace EzBusiness_ViewModels.Models.FinaceMgmt
{
    public class ExchangeRateVM
    {

        public string CmpyCode { get; set; }

        public string CurCode { get; set; }

        public string CurName { get; set; }


        public string CurRate { get; set; }


        public bool SaveFlag { get; set; }

        public bool EditFlag { get; set; }

        public string ErrorMessage { get; set; }

        public string UserName { get; set; }

    }
}
