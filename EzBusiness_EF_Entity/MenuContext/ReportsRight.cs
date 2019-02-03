namespace EzBusiness_EF_Entity.MenuContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ezBusDb.ReportsRights")]
    public partial class ReportsRight
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string Cmpycode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string user_name { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Code { get; set; }


        [Required(AllowEmptyStrings = true)]
        [StringLength(70)]
        public string ReportName { get; set; }

        public short Viewit { get; set; }


        [Required(AllowEmptyStrings = true)]
        [StringLength(30)]
        public string module { get; set; }
    }
}
