using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity.MenuContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ezBusDb.MenuItems")]
    public partial class MenuItem
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string FormID { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(100)]
        public string FormName { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(200)]
        public string UnicodeName { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string ParentFormID { get; set; }

        public int Sno { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string frmName { get; set; }

        public int CheckRight { get; set; }

        public int Show { get; set; }

        public int Report { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(5)]
        public string ShowType { get; set; }

        public int Levels { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string TableName { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string Fields { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(100)]
        public string Captions { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(100)]
        public string FunctionName { get; set; }

        public int ModalForm { get; set; }

        public int NotForUser { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(200)]
        public string AllMasterQuery { get; set; }

        public int UserDefined { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string ManualCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string CmpyCode { get; set; }

        public string NavURL { get; set; }
    }
}
