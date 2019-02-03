namespace EzBusiness_EF_Entity.MenuContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ezBusDb.CompanyMaster")]
    public partial class CompanyMaster
    {
        [Key]
        [StringLength(20)]
        public string CmpyCode { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(10)]
        public string Fyear { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(250)]
        public string Address { get; set; }

        public DateTime? AcctYrStart { get; set; }

        public DateTime? AcctYrEnd { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(1)]
        public string PeriodsRqd { get; set; }

        public int? NoOfPeriods { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string ContinueNextYear { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string SuperUser { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string Passwords { get; set; }

        public DateTime? PStartDate { get; set; }

        public DateTime? PEndDate { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(1)]
        public string Status { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string PostBox { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string Tel { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string Fax { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(100)]
        public string Email { get; set; }

        [Column(TypeName = "image")]
        public byte[] Logo { get; set; }

        public double? ProfitMargin { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FastMovingPerc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FastMovingQty { get; set; }

        public DateTime? SystemStartDate { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string IndustryCode { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string DefCurrency { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(250)]
        public string Address2 { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string Website { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string IECertificateNo { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string CurCode { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string FirstWeeklyOff { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string SecondWeeklyOff { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string PANNo { get; set; }

        public int RetirementAge { get; set; }

        [Column(TypeName = "image")]
        public byte[] AthenLogo { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string TDSNo { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string TDSAccNo { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string TDSPANNo { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string TDSCircle { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string ECCNo { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string ExciseRange { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string ExciseDivision { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string Commissionarate { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string PLANo { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string RangeAddress { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string DivisionAddreess { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string CommAddress { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string VATTINNo { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string CSTTINNo { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string ServiceTaxNo1 { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string ServiceTaxNo2 { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string ServiceProviding1 { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string ServiceProviding2 { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string PFRegistrationNo { get; set; }

        public DateTime? PFRegistrationDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PFLimit { get; set; }

        [Column(TypeName = "numeric")]
        public decimal FPFAgeLimit { get; set; }

        [Column(TypeName = "numeric")]
        public decimal EmployeePF { get; set; }

        [Column(TypeName = "numeric")]
        public decimal EmployerPF { get; set; }

        [Column(TypeName = "numeric")]
        public decimal EmployeeFPF { get; set; }

        [Column(TypeName = "numeric")]
        public decimal EmployerFPF { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PFAccNo1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PFAccNo2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PFAccNo3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PFAccNo4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PFAccNo5 { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string ESICRegistrationNo { get; set; }

        public DateTime? ESICRegistrationDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ESICLimit { get; set; }

        [Column(TypeName = "numeric")]
        public decimal EmployeeESIC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal EmployerESIC { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string WFRegistrationNo { get; set; }

        public DateTime? WFRegistrationDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Regular { get; set; }

        [Column(TypeName = "numeric")]
        public decimal WeeklyOff { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Holiday { get; set; }

        [Column(TypeName = "numeric")]
        public decimal MinimumOTHrs { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(75)]
        public string AuthorizedSignatory { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string Designation { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(1)]
        public string IncomeTaxCW { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(1)]
        public string DeductorTypeCG { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(100)]
        public string DeducteeName { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(100)]
        public string DeducteeDesignation { get; set; }

        [Column(TypeName = "numeric")]
        public decimal NormalOTHrs { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(100)]
        public string DeductionMonths { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string StateCode { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(2)]
        public string GroupCode { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string Guardian { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(100)]
        public string ArabicName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ExtraOTRate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal FExtraOTRate { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(500)]
        public string EmployerID { get; set; }
    }
}
