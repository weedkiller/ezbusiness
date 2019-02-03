namespace EzBusiness_EF_Entity.MenuContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ezBusDb.MenuItemSettings")]
    public partial class MenuItemSetting
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string FormID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string SettingName { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(10)]
        public string DisplayOn { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string CmpyCode { get; set; }
    }
}
