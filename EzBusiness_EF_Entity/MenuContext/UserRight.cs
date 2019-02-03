namespace EzBusiness_EF_Entity.MenuContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ezBusDb.UserRights")]
    public partial class UserRight
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string CmpyCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string user_name { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string FormId { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(150)]
        public string FormName { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(150)]
        public string UnicodeName { get; set; }

        public short SelAll { get; set; }

        public short NewIt { get; set; }

        public short ViewIt { get; set; }

        public short EditIt { get; set; }

        public short DeleteIt { get; set; }

        public short PrintIt { get; set; }

        public short Froms { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string Mod { get; set; }

        public int PostIt { get; set; }
    }
}
