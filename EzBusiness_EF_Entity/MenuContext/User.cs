namespace EzBusiness_EF_Entity.MenuContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ezBusDb.Users")]
    public partial class User
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string CmpyCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string user_name { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(80)]
        public string passwords { get; set; }

        public int types { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(1)]
        public string Utype { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(10)]
        public string FullName { get; set; }

        [Column(TypeName = "image")]
        public byte[] Signature { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string EmpCode { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string ProjectCode { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string Designation { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(30)]
        public string ContactNo { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(1)]
        public string CostView { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(1)]
        public string AcctTabView { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(1)]
        public string Posting { get; set; }

        [Required]
        [StringLength(1)]
        public string StockPosting { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(1)]
        public string ShowSalary { get; set; }

        public bool IsLogged { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string AgreementClose { get; set; }
    }
}
