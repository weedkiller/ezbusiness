namespace EzBusiness_EF_Entity.MenuContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ezBusDb.MetaSettings")]
    public partial class MetaSetting
    {
        [StringLength(20)]
        public string CmpyCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? StockUpdateOnInvoice { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? StockReconcillationAgainstAC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OnlineTrans { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ChequeValidity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AutoPOConfirm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MaxOT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OTRate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? HOTRate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AllowNegativeStock { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MaxHOT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UseOTRate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UseHOTRate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CheckCreditLimit { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LeaveSettlementMultipleEntry { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LeaveSettlementFromDailyTimeSheet { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UseCriteriaForEL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LeaveSalaryOnBasic { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LeaveSalaryOnHRA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CalculateSalaryOnLastSalary { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IncludeDayOfTravelling { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ReserveGreaterThanOrder { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ShowReportFormOnPrintRelation { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AutoNewOnOpen { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(2)]
        public string DefaultSalaryMode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CustomerWiseSaleDiscount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OTHOTSameDay { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LSMaxLeaveDays { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LSLeaveSalaryLastResumeDate { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(30)]
        public string FontName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FontSize { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UseDefFont { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AutoFillCombo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DecimalSpace { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PQShowBrand { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PQShowItemCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PQShowSupplier { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PQShowClass { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PQShowModel { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PQShowColor { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PQShowSize { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ShowSaveAs { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AllowCustomSearch { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AllowMultipleMachinePOSEdit { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AllowSerialNumber { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MultiSegmentedQuotation { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(30)]
        public string DrillDownBackColor { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BarCodeAutoEntry { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? POSShowMsgAfterWrongItem { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ProductReorderQty { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DocExpNotificationDays { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RightToLeft { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MinCustomerOutstanding { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UseCustomCaption { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ShowAlertOnStartup { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ShowInquiry { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UseVAT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UseStockReserve { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UsePOS { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(30)]
        public string DefLocCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AllowFocusOnLockedColumn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ForceBatchEntry { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AllowBatchEntry { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ForceSerialNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PDCPAlertDays { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PDCRAlertDays { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? QuoFromSupp { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SuppInqQuoFromSupp { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SuppInqQuoComp { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? QuoFromSuppComp { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UseProject { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UseProjectAnlysisPO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UseProjectAnlysisGRV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UseProjectAnlysisPI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UseProjectAnlysisSO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UseProjectAnlysisGIV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UseProjectAnlysisSI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AllowUnitFactor { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string COGS { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string useForeignPO { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal UseResizer { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal AutoMaxIfResizer { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal UseTitleCaseNames { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(30)]
        public string DefaultShipmentTypeSO { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(30)]
        public string DefaultPaymentTypeSO { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(30)]
        public string DefaultShipmentTypePO { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(30)]
        public string DefaultPaymentTypePO { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "numeric")]
        public decimal UsePrintOnSave { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string ItemPropertyValue { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "numeric")]
        public decimal UseTAXFunctionality { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(1)]
        public string DefaultVisaType { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(30)]
        public string defaultcurrency { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string weekdays { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "numeric")]
        public decimal LSLeaveEntitledLowerLimit { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "numeric")]
        public decimal LSLeaveEntitledUpperLimit { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "numeric")]
        public decimal LSLeaveEntitledDays1 { get; set; }

        [Key]
        [Column(Order = 9, TypeName = "numeric")]
        public decimal LSLeaveEntitledDays2 { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(10)]
        public string DefaultLanguage { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BatchDateOrder { get; set; }

        [Key]
        [Column(Order = 10, TypeName = "numeric")]
        public decimal POAllocation { get; set; }

        [Key]
        [Column(Order = 11, TypeName = "numeric")]
        public decimal ChangeCurrencyInSO_SID { get; set; }

        [Key]
        [Column(Order = 12, TypeName = "numeric")]
        public decimal ShowVisa { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(10)]
        public string BatchEntryType { get; set; }

        [Key]
        [Column(Order = 14, TypeName = "numeric")]
        public decimal OverRideBatchEntry { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(500)]
        public string ProjectCaption { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(500)]
        public string AnalysisCaption { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(500)]
        public string AnalysisWindowCaption { get; set; }

        [Key]
        [Column(Order = 15, TypeName = "numeric")]
        public decimal ChangeCurrencyInPO_PID { get; set; }

        [Key]
        [Column(Order = 16, TypeName = "numeric")]
        public decimal POSBankCharges { get; set; }

        [Key]
        [Column(Order = 17, TypeName = "numeric")]
        public decimal UseItemDropDown { get; set; }

        [Key]
        [Column(Order = 18, TypeName = "numeric")]
        public decimal DirectGRV { get; set; }

        [Key]
        [Column(Order = 19, TypeName = "numeric")]
        public decimal DirectGIV { get; set; }

        [Key]
        [Column(Order = 20, TypeName = "numeric")]
        public decimal APercent { get; set; }

        [Key]
        [Column(Order = 21, TypeName = "numeric")]
        public decimal BPercent { get; set; }

        [Key]
        [Column(Order = 22, TypeName = "numeric")]
        public decimal CPercent { get; set; }

        [Key]
        [Column(Order = 23, TypeName = "numeric")]
        public decimal XPercent { get; set; }

        [Key]
        [Column(Order = 24, TypeName = "numeric")]
        public decimal YPercent { get; set; }

        [Key]
        [Column(Order = 25, TypeName = "numeric")]
        public decimal ZPercent { get; set; }

        [Key]
        [Column(Order = 26)]
        [StringLength(10)]
        public string ABCPercent { get; set; }

        [Key]
        [Column(Order = 27)]
        [StringLength(10)]
        public string XYZPercent { get; set; }

        [Key]
        [Column(Order = 28, TypeName = "numeric")]
        public decimal UseReminder { get; set; }

        [Key]
        [Column(Order = 29)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DisplayFreeItem { get; set; }

        [Key]
        [Column(Order = 30, TypeName = "numeric")]
        public decimal OverRidePOItems { get; set; }

        [Key]
        [Column(Order = 31, TypeName = "numeric")]
        public decimal UseProduction { get; set; }

        [Key]
        [Column(Order = 32, TypeName = "numeric")]
        public decimal UseActivity { get; set; }

        [Key]
        [Column(Order = 33, TypeName = "numeric")]
        public decimal UseBOM { get; set; }

        [Key]
        [Column(Order = 34, TypeName = "numeric")]
        public decimal UseIndirectCostinJobOrder { get; set; }

        [Key]
        [Column(Order = 35, TypeName = "numeric")]
        public decimal UseEnglishCustomCaption { get; set; }

        [Key]
        [Column(Order = 36, TypeName = "numeric")]
        public decimal APurPercent { get; set; }

        [Key]
        [Column(Order = 37, TypeName = "numeric")]
        public decimal BPurPercent { get; set; }

        [Key]
        [Column(Order = 38, TypeName = "numeric")]
        public decimal CPurPercent { get; set; }

        [Key]
        [Column(Order = 39, TypeName = "numeric")]
        public decimal XPurPercent { get; set; }

        [Key]
        [Column(Order = 40, TypeName = "numeric")]
        public decimal YPurPercent { get; set; }

        [Key]
        [Column(Order = 41, TypeName = "numeric")]
        public decimal ZPurPercent { get; set; }

        [Key]
        [Column(Order = 42)]
        [StringLength(10)]
        public string ABCPurPercent { get; set; }

        [Key]
        [Column(Order = 43)]
        [StringLength(10)]
        public string XYZPurPercent { get; set; }

        [Key]
        [Column(Order = 44, TypeName = "numeric")]
        public decimal UseJobOrderApproval { get; set; }

        [Key]
        [Column(Order = 45, TypeName = "numeric")]
        public decimal UseJobOrderRelease { get; set; }

        [Key]
        [Column(Order = 46, TypeName = "numeric")]
        public decimal UseWorkCenterRelease { get; set; }

        [Key]
        [Column(Order = 47, TypeName = "numeric")]
        public decimal UseWorkCenterProcess { get; set; }

        [Key]
        [Column(Order = 48, TypeName = "numeric")]
        public decimal UseMaterialIssue { get; set; }

        [Key]
        [Column(Order = 49, TypeName = "numeric")]
        public decimal UseQCApproval { get; set; }

        [Key]
        [Column(Order = 50, TypeName = "numeric")]
        public decimal UseJobCompletion { get; set; }

        [Key]
        [Column(Order = 51, TypeName = "numeric")]
        public decimal ShowIncentiveOT { get; set; }

        [Key]
        [Column(Order = 52, TypeName = "numeric")]
        public decimal IncentiveOTRatePer { get; set; }

        [Key]
        [Column(Order = 53, TypeName = "numeric")]
        public decimal OverrideJobQtyForMI { get; set; }

        [Key]
        [Column(Order = 54, TypeName = "numeric")]
        public decimal ForceBOM { get; set; }

        [Key]
        [Column(Order = 55, TypeName = "numeric")]
        public decimal OverrideBOM { get; set; }

        [Key]
        [Column(Order = 56, TypeName = "numeric")]
        public decimal JOWithoutSO { get; set; }

        [Key]
        [Column(Order = 57, TypeName = "numeric")]
        public decimal PFUpperLimit { get; set; }

        [Key]
        [Column(Order = 58, TypeName = "numeric")]
        public decimal PFEmpPerc { get; set; }

        [Key]
        [Column(Order = 59, TypeName = "numeric")]
        public decimal PFEmprPerc { get; set; }

        [Key]
        [Column(Order = 60, TypeName = "numeric")]
        public decimal ESIUpperLimit { get; set; }

        [Key]
        [Column(Order = 61, TypeName = "numeric")]
        public decimal ESIEmpPerc { get; set; }

        [Key]
        [Column(Order = 62, TypeName = "numeric")]
        public decimal ESIEmprPerc { get; set; }

        [Key]
        [Column(Order = 63, TypeName = "numeric")]
        public decimal OverrideByProductInWCC { get; set; }

        [Key]
        [Column(Order = 64, TypeName = "numeric")]
        public decimal ShowCancelledEmployee { get; set; }

        [Key]
        [Column(Order = 65, TypeName = "numeric")]
        public decimal UseConstruction { get; set; }

        [Key]
        [Column(Order = 66, TypeName = "numeric")]
        public decimal ShowApprovalHistory { get; set; }

        [Key]
        [Column(Order = 67, TypeName = "numeric")]
        public decimal UseApproval { get; set; }

        [Key]
        [Column(Order = 68, TypeName = "numeric")]
        public decimal UseBin { get; set; }

        [Key]
        [Column(Order = 69, TypeName = "numeric")]
        public decimal ForceBIN { get; set; }

        [Key]
        [Column(Order = 70, TypeName = "numeric")]
        public decimal UseSubContracting { get; set; }

        [Key]
        [Column(Order = 71, TypeName = "numeric")]
        public decimal UseExport { get; set; }

        [Key]
        [Column(Order = 72, TypeName = "numeric")]
        public decimal UsePayroll { get; set; }

        [Key]
        [Column(Order = 73)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UseMachineMaintenance { get; set; }

        [Key]
        [Column(Order = 74)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProfTax { get; set; }

        [Key]
        [Column(Order = 75)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Welfare { get; set; }

        [Key]
        [Column(Order = 76)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IncomeTax { get; set; }

        [Key]
        [Column(Order = 77)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PFApplicable { get; set; }

        [Key]
        [Column(Order = 78)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ESICApplicable { get; set; }

        [Key]
        [Column(Order = 79, TypeName = "numeric")]
        public decimal UsePurchase { get; set; }

        [Key]
        [Column(Order = 80, TypeName = "numeric")]
        public decimal UseSale { get; set; }

        [Key]
        [Column(Order = 81, TypeName = "numeric")]
        public decimal UseInventory { get; set; }

        [Key]
        [Column(Order = 82, TypeName = "numeric")]
        public decimal UseAccounts { get; set; }

        [Key]
        [Column(Order = 83, TypeName = "numeric")]
        public decimal AgeningDays1 { get; set; }

        [Key]
        [Column(Order = 84, TypeName = "numeric")]
        public decimal AgeningDays2 { get; set; }

        [Key]
        [Column(Order = 85, TypeName = "numeric")]
        public decimal AgeningDays3 { get; set; }

        [Key]
        [Column(Order = 86, TypeName = "numeric")]
        public decimal AgeningDays4 { get; set; }

        [Key]
        [Column(Order = 87, TypeName = "numeric")]
        public decimal AgeningDays5 { get; set; }

        [Key]
        [Column(Order = 88)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AdditionalInformation { get; set; }

        [Key]
        [Column(Order = 89)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BreakInOutApplicable { get; set; }

        [Key]
        [Column(Order = 90)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InOutApplicable { get; set; }

        [Key]
        [Column(Order = 91)]
        [StringLength(1)]
        public string WBSCodeSeperator { get; set; }

        [Key]
        [Column(Order = 92)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WBSCodeDigits { get; set; }

        [Key]
        [Column(Order = 93, TypeName = "numeric")]
        public decimal AllowSubCodeEntry { get; set; }

        [Key]
        [Column(Order = 94)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UseProjectScheduling { get; set; }

        [Key]
        [Column(Order = 95)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UseProjectManagement { get; set; }

        [Key]
        [Column(Order = 96)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ForceProjectInTransaction { get; set; }

        [Key]
        [Column(Order = 97, TypeName = "numeric")]
        public decimal AllowUserLocation { get; set; }

        [Key]
        [Column(Order = 98)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UnlockTaxTypeValue { get; set; }

        [Key]
        [Column(Order = 99)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserProject { get; set; }

        [Key]
        [Column(Order = 100)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AutoWIPScrapIntoStock { get; set; }

        [Key]
        [Column(Order = 101)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MultiCmpyUnit { get; set; }

        [Key]
        [Column(Order = 102)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaxItemInSI { get; set; }

        [Key]
        [Column(Order = 103)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InhouseJobDifferentSeries { get; set; }

        [Key]
        [Column(Order = 104)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExChallanExpiryReminderDays { get; set; }

        [Key]
        [Column(Order = 105)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserDefinedForms { get; set; }

        [Key]
        [Column(Order = 106)]
        [StringLength(10)]
        public string FinalSettlementType { get; set; }

        [Key]
        [Column(Order = 107)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UseCalculationTemplate { get; set; }

        [Key]
        [Column(Order = 108)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UseAsset { get; set; }

        [Key]
        [Column(Order = 109)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UseFleet { get; set; }

        [Key]
        [Column(Order = 110)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UseHR { get; set; }

        [Key]
        [Column(Order = 111)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UseProperty { get; set; }

        [Key]
        [Column(Order = 112)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AllowBackDateCheque { get; set; }

        [Key]
        [Column(Order = 113)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UsePVDifferentSrNo { get; set; }

        [Key]
        [Column(Order = 114)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UseRVDifferentSrNo { get; set; }

        [Key]
        [Column(Order = 115)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MultiplePaymentVouchers { get; set; }

        [Key]
        [Column(Order = 116)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MultipleReceiptVouchers { get; set; }

        [Key]
        [Column(Order = 117)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CenvatUpdationOnInvoice { get; set; }

        [Key]
        [Column(Order = 118)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UseSeparateExciseSNo { get; set; }

        [Key]
        [Column(Order = 119)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UseInwardQCGrn { get; set; }

        [Key]
        [Column(Order = 120)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UseSurplusQuantity { get; set; }

        [Key]
        [Column(Order = 121)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UsePreventiveMaintenance { get; set; }

        [Key]
        [Column(Order = 122)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RequiredItemsInquiry { get; set; }

        [Key]
        [Column(Order = 123)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UseSiteRequest { get; set; }

        [Key]
        [Column(Order = 124)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DropShipment { get; set; }

        [Key]
        [Column(Order = 125)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShowWPSReport { get; set; }

        [Key]
        [Column(Order = 126)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int A { get; set; }

        [Key]
        [Column(Order = 127)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BO { get; set; }

        [Key]
        [Column(Order = 128)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int C { get; set; }

        [Key]
        [Column(Order = 129)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FC { get; set; }

        [Key]
        [Column(Order = 130)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FM { get; set; }

        [Key]
        [Column(Order = 131)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FB { get; set; }

        [Key]
        [Column(Order = 132)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FP { get; set; }

        [Key]
        [Column(Order = 133)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int O { get; set; }

        [Key]
        [Column(Order = 134)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int P { get; set; }

        [Key]
        [Column(Order = 135)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int R { get; set; }

        [Key]
        [Column(Order = 136)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int S { get; set; }

        [Key]
        [Column(Order = 137)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int T { get; set; }

        [Key]
        [Column(Order = 138)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SF { get; set; }

        [Key]
        [Column(Order = 139)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SV { get; set; }

        [Key]
        [Column(Order = 140)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InterCompanyTransaction { get; set; }

        [Key]
        [Column(Order = 141)]
        [StringLength(10)]
        public string MonthDaysType { get; set; }

        [Key]
        [Column(Order = 142)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MonthDays { get; set; }

        [Key]
        [Column(Order = 143)]
        [StringLength(10)]
        public string LSLEcalcType { get; set; }

        [Key]
        [Column(Order = 144)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UseFacility { get; set; }

        [Key]
        [Column(Order = 145)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AssetAlert { get; set; }

        [Key]
        [Column(Order = 146)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CreateSiteRequestFromProjectSchedule { get; set; }

        [Key]
        [Column(Order = 147, TypeName = "numeric")]
        public decimal JobOrderAgainstProject { get; set; }

        [Key]
        [Column(Order = 148)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AutoDispatch { get; set; }

        [Key]
        [Column(Order = 149)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UseGradeForSalary { get; set; }

        [Key]
        [Column(Order = 150)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FinalSettlementAcc { get; set; }

        [Key]
        [Column(Order = 151)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UseRackBin { get; set; }

        [Key]
        [Column(Order = 152, TypeName = "numeric")]
        public decimal EmpTransferAlertDays { get; set; }

        [Key]
        [Column(Order = 153)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DecimalSpaceGrid { get; set; }

        [Key]
        [Column(Order = 154)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LeaveSettlementAcc { get; set; }
    }
}
