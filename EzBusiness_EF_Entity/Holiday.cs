using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
  public partial class Holiday
    {

        public DateTime? Dates { get; set; }

   
        public string HRPH001_UID { get; set; }
        public string HRPH001_CODE  { get; set; }

        public string CMPYCODE { get; set; }

        public string LEAVE_TYPEYCODE { get; set; }


        public string Description  { get; set; }

        public string COUNTRY  { get; set; }

        public int srno { get; set; }



    }
}
