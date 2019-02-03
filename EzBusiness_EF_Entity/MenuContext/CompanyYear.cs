namespace EzBusiness_EF_Entity.MenuContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ezBusDb.CompanyYear")]
    public partial class CompanyYear
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string CmpyCode { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int Locked { get; set; }

        public int SNo { get; set; }
    }
}
