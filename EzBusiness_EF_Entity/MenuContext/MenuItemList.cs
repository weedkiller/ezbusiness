namespace EzBusiness_EF_Entity.MenuContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ezBusDb.MENUITEMLIST015")]
    public partial class MenuItemList
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string MenuName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string MenuId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string ArabicName { get; set; }

        public int? MenuIndex { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(100)]
        public string Fields { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(15)]
        public string VType { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(20)]
        public string CmpyCode { get; set; }
    }
}
