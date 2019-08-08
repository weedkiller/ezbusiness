using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_ViewModels.Models.FreightManagement
{
   public  class UTM0001_VM
    {
        public string Cmpycode { get; set; }
        public string Branchcode { get; set; }
        public string Tablename { get; set; }

        public string Module_Type { get; set; }
        public string UTI0001_CODE { get; set; }
        public string PREFIX_CODE { get; set; }

        public string Page_Name { get; set; }
        public string Starting_No { get; set; }
        public string Total_length { get; set; }
        public string Last_No { get; set; }
        public string Auto_increment { get; set; }

        public bool SaveFlag { get; set; }
        public bool EditFlag { get; set; }
        public string ErrorMessage { get; set; }
        public string UserName { get; set; }

        public UTI0002New UTI0002 { get; set; }
        public List<UTI0002New> UTI0002Detail { get; set; }
    }
    public class UTI0002New
    {
        public string UTI0001_CODE { get; set; }
        public string Cmpycode { get; set; }
        public string Branchcode { get; set; }
        public string Tablename { get; set; }
        public int sno { get; set; }
        public string APPROVER_ID { get; set; }
        public string APPROVER_NAME { get; set; }
        public string REJECTED_ALLOW { get; set; }

        public string UNAPPROVE_ALLOW { get; set; }

        public string APPROVE_ALLOW { get; set; }
    }
    }

