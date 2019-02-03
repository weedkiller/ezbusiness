using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
   public partial class UserRights
    {
        public string CmpyCode { get; set; }
        public string user_name { get; set; }
        public string FormId { get; set; }
        public string FormName { get; set; }
        public string UnicodeName { get; set; }
        public int SelAll { get; set; }
        public int NewIt { get; set; }
        public int ViewIt { get; set; }
        public int EditIt { get; set; }
        public int DeleteIt { get; set; }
        public int PrintIt { get; set; }
        public int Froms { get; set; }
        public string Mod { get; set; }
        public int PostIt { get; set; }

        public string ParentFormId { get; set; }





    }
}
