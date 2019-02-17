using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.PurchaseMgmt;
using System.Data;
using System.Data.SqlClient;
using EzBusiness_ViewModels;

namespace EzBusiness_DL_Repository
{
    public class PurchaseMgmtORepository : IPurchaseMgmtORepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        public bool DeletePurchaseOrder(string CmpyCode, string POCode)
        {
            int unit = _EzBusinessHelper.ExecuteScalar("Select count(*) from PoHeader where CmpyCode='" + CmpyCode + "' and PONumber='" + POCode + "'");
            if (unit != 0)
            {
                _EzBusinessHelper.ExecuteNonQuery("delete from PODetail where CmpyCode='" + CmpyCode + "' and PONumber='" + POCode + "'");
                _EzBusinessHelper.ExecuteNonQuery("delete from PoHeader where CmpyCode='" + CmpyCode + "' and PONumber='" + POCode + "'");
                return true;
            }
            return false;
        }

        //public List<ExchangeRates> GetPOReqList(string CmpyCode)
        //{

        //}
        public List<ExchangeRates> GetCurList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("SELECT CurCode, CurName,CurRate FROM ExchangeRates WHERE Cmpycode ='" + CmpyCode + "' Order By Curcode ");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<ExchangeRates> ObjList = new List<ExchangeRates>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new ExchangeRates()
                {
                    CurCode = dr["CurCode"].ToString(),
                    CurName = dr["CurName"].ToString(),
                    CurRate = Convert.ToDecimal(dr["CurRate"]),
                });

            }
            return ObjList;
        }

       

        public List<Division> GetDivisionList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("SELECT DivisionCode, DivisionName FROM Division WHERE Cmpycode ='" + CmpyCode + "' Order By DivisionCode ");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Division> ObjList = new List<Division>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new Division()
                {
                    DivisionCode = dr["DivisionCode"].ToString(),
                    DivisionName = dr["DivisionName"].ToString(),
                });

            }
            return ObjList;
        }

        public PurchaseOrderDetailnew GetItemCodeDescription(string CmpyCode, string itemCode, string restyp)
        {
            if (restyp == "A")
            {
                ds = _EzBusinessHelper.ExecuteDataSet("Select SelfGenCode as [ItemCode],Code as [Description],'NOS' as [Unit] from AssetTree where Cmpycode='" + CmpyCode + "' and SelfGenCode='" + itemCode + "' ");
            }
            else
            {
                ds = _EzBusinessHelper.ExecuteDataSet("Select ItemCode,Description,Unit from Products where Cmpycode='" + CmpyCode + "' and ItemCode='" + itemCode + "' and ShowInPurchase != 0 and PrdType='" + PurchaseMgmtConstants.PrdType + "'");
            }
            dt = ds.Tables[0];
            PurchaseOrderDetailnew po = new PurchaseOrderDetailnew();
            foreach (DataRow dr in dt.Rows)
            {
                po.ItemCode = dr["ItemCode"].ToString();
                po.Description = dr["Description"].ToString();
                po.Unit = dr["Unit"].ToString();
            }
            return po;
        }

        public List<Product> GetItemCodeList(string CmpyCode, string restyp)
        {
            SqlParameter[] param = {new SqlParameter("@Cmpycode1", CmpyCode),
                        new SqlParameter("@xResourceType", restyp)};

            ds = _EzBusinessHelper.ExecuteDataSet("GF_Show_Item_Drop_Down", CommandType.StoredProcedure, param);
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Product> ObjList = new List<Product>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new Product()
                {
                    ItemCode = dr["ItemCode"].ToString(),
                });

            }
            return ObjList;
        }

        public List<Location> GetLocationList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select LocCode,LocName from Location where CmpyCode='" + CmpyCode + "' ");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Location> ObjList = new List<Location>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new Location()
                {
                    LocCode = dr["LocCode"].ToString(),
                    LocName = dr["LocName"].ToString(),
                });

            }
            return ObjList;
        }

        public List<PODetail> GetPODetailsList(string CmpyCode, string POCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PODetail where CmpyCode='" + CmpyCode + "' and PoNumber='" + POCode + "' ");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<PODetail> ObjList = new List<PODetail>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new PODetail()
                {

                    ItemCode = dr["ItemCode"].ToString(),
                    Description = dr["Description"].ToString(),
                    QtyOrdered = Convert.ToDecimal(dr["QtyOrdered"].ToString()),
                    Specification = dr["Specification"].ToString(),
                    Unit = dr["Unit"].ToString(),
                    UnitPrice= Convert.ToDecimal(dr["UnitPrice"].ToString()),
                    ItemTotal= Convert.ToDecimal(dr["ItemTotal"].ToString()),
                    DiscountP = Convert.ToDecimal(dr["DiscountP"].ToString()),
                    Discount = Convert.ToDecimal(dr["Discount"].ToString()),
                    NetAmount = Convert.ToDecimal(dr["NetAmount"].ToString()),
                    LNetAmount = Convert.ToDecimal(dr["LNetAmount"].ToString()),

                }

                    );


            }
            return ObjList;
        }

        public List<CommonTable> GetPOFromList(string type)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select Code,Name from CommonTable where Type='" + type + "' ");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<CommonTable> ObjList = new List<CommonTable>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new CommonTable()
                {
                    Code = dr["Code"].ToString(),
                    Name = dr["Name"].ToString(),
                });

            }
            return ObjList;
        }

        public List<MReqHeader> GetPOItemReqDetList(string CmpyCode, string MRCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from MReqHeader where CmpyCode='" + CmpyCode + "' and MRCode='" + MRCode + "' ");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<MReqHeader> ObjList = new List<MReqHeader>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new MReqHeader()
                {
                   ResourceType = dr["ResourceType"].ToString(),
                    LocCode = dr["LocCode"].ToString(),
                    EmpCode = dr["EmpCode"].ToString(),
                    ProjectCode = dr["ProjectCode"].ToString(),                   
                });
            }
            return ObjList;
        }

        public List<MReqDetail> GetPOItemReqList(string CmpyCode, string MRCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from MReqDetail where CmpyCode='" + CmpyCode + "' and MRCode='" + MRCode + "' ");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<MReqDetail> ObjList = new List<MReqDetail>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new MReqDetail()
                {

                    ItemCode = dr["ItemCode"].ToString(),
                    Description = dr["Description"].ToString(),
                    Qty = Convert.ToDecimal(dr["Qty"].ToString()),
                    Specification = dr["Specification"].ToString(),
                    Unit = dr["Unit"].ToString(),

                }

                    );


            }
            return ObjList;
        }

        public PurchaseOrderVM GetPOItemReqListnew(string CmpyCode, string MRCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from MReqHeader where CmpyCode='" + CmpyCode + "' and MRCode='" + MRCode + "' ");

            dt = ds.Tables[0];
            PurchaseOrderVM pr = new PurchaseOrderVM();

            foreach (DataRow dr in dt.Rows)
            {
                pr.CmpyCode = dr["CmpyCode"].ToString();
              
                pr.Description = dr["Description"].ToString();
                pr.LocCode = dr["LocCode"].ToString();
                pr.POReq = dr["MRCode"].ToString();
                pr.POFrom = "M";
                //pr.PODate = Convert.ToDateTime(DateTime.ParseExact(dr["Dates"].ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture));
               // pr.PreparedBy = dr["PreparedBy"].ToString();
                pr.ProjectCode = dr["ProjectCode"].ToString();
                pr.ReqtBy = dr["EmpCode"].ToString();
                pr.ResourceType = dr["ResourceType"].ToString();

            }
            return pr;
        }

        public PurchaseOrderVM GetPOMasterDetailsEdit(string CmpyCode, string PoCode,string resttyp)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PoHeader where CmpyCode='" + CmpyCode + "' and PoNumber='" + PoCode + "' ");

            dt = ds.Tables[0];
            PurchaseOrderVM pr = new PurchaseOrderVM();
            foreach (DataRow dr in dt.Rows)
            {
                pr.CmpyCode = dr["CmpyCode"].ToString();
                pr.PONumber = dr["PONumber"].ToString();
                //pr.Description = dr["Description"].ToString();
                pr.LocCode = dr["LocCode"].ToString();
                pr.Dates = Convert.ToDateTime(dr["Dates"].ToString());
                pr.PreparedBy = dr["PreparedBy"].ToString();
                pr.ProjectCode = dr["ProjectCode"].ToString();
                pr.ReqtBy = dr["ReqtBy"].ToString();
                pr.ResourceType = dr["ResourceType"].ToString();
                pr.POFrom = dr["POFrom"].ToString();
                pr.SupplierCode = dr["SupplierCode"].ToString();
                pr.CurCode = dr["CurCode"].ToString();
                pr.ExpectedDeliveryDate = Convert.ToDateTime(dr["ExpectedDeliveryDate"].ToString());
                pr.DivisionCode = dr["DivisionCode"].ToString();
            }
            return pr;
        }

        public List<MReqHeader> GetPOReqList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from MReqHeader where CmpyCode='" + CmpyCode + "' ");



            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<MReqHeader> ObjList = new List<MReqHeader>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new MReqHeader()
                {                                       
                    Dates = Convert.ToDateTime(dr["Dates"].ToString()),                                        
                    EmpCode = dr["EmpCode"].ToString(),                                     
                    JobNo = dr["JobNo"].ToString(),
                    LocCode = dr["LocCode"].ToString(),
                    MRCode = dr["MRCode"].ToString(),                  
                }
              );
            }
            return ObjList;
        }

        public List<CostCenterHeader> GetProjects(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select Name,Code from CostCenterHeader where CmpyCode='" + CmpyCode + "' ");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<CostCenterHeader> ObjList = new List<CostCenterHeader>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new CostCenterHeader()
                {
                    Name = dr["Name"].ToString(),
                    Code = dr["Code"].ToString(),
                });

            }
            return ObjList;
        }

        public List<POHeader> GetPurchaseOrderList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PoHeader where CmpyCode='" + CmpyCode + "' ");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<POHeader> ObjList = new List<POHeader>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new POHeader()
                {

                    CmpyCode = dr["CmpyCode"].ToString(),
                    ApprovalYN = dr["ApprovalYN"].ToString(),
                    Dates = Convert.ToDateTime(dr["Dates"].ToString()),
                    //Description = dr["Description"].ToString(),
                    //DontShowJobInList = Convert.ToInt16(dr["DontShowJobInList"].ToString()),
                    ReqtBy = dr["ReqtBy"].ToString(),
                    SupplierCode = dr["SupplierCode"].ToString(),
                    LocCode = dr["LocCode"].ToString(),
                    PONumber = dr["PONumber"].ToString(),
                    POFrom = dr["POFrom"].ToString(),
                    PreparedBy = dr["PreparedBy"].ToString(),
                    POPriority = dr["POPriority"].ToString(),
                    ProjectCode = dr["ProjectCode"].ToString(),
                    ResourceType = dr["ResourceType"].ToString(),
                    CurCode = dr["CurCode"].ToString(),
                    CurRate =Convert.ToDecimal(dr["CurRate"].ToString()),
                    Status = dr["Status"].ToString(),
                    WONO = dr["WONo"].ToString(),
                    ExpectedDeliveryDate= Convert.ToDateTime(dr["ExpectedDeliveryDate"].ToString()),
                    RevisionNo=Convert.ToInt16(dr["RevisionNo"].ToString()),
                    YourRef=dr["YourRef"].ToString(),
                    ValidityDate= Convert.ToDateTime(dr["ValidityDate"].ToString()),
                    SupplierContactPerson =dr["SupplierContactPerson"].ToString(),



                }
              );
            }
            return ObjList;
        }

        public List<Employee> GetRequesterList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select empName,empcode from Employee where CmpyCode='" + CmpyCode + "' and WorkingStatus = '" + PurchaseMgmtConstants.WorkingStatus + "' ");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Employee> ObjList = new List<Employee>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new Employee()
                {
                    Empname = dr["Empname"].ToString(),
                    EmpCode = dr["EmpCode"].ToString(),
                });

            }
            return ObjList;
        }

        public List<Supplier> GetSupplierList(string Cmpycode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select Name,Suppliercode from Suppliers where CmpyCode='" + Cmpycode + "'  AND SupplierType='S' ");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Supplier> ObjList = new List<Supplier>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new Supplier()
                {
                    Name = dr["Name"].ToString(),
                    Suppliercode = dr["Suppliercode"].ToString(),
                });

            }
            return ObjList;

        }

       

        public PurchaseOrderVM SavePurchaseOrder(PurchaseOrderVM po)
        {
            int n;
            string dtstr,dtstr1 = null;

            //try
            //{
            var counter = 1;
            if (!po.IsEditMode)
            {
                // var pt = _materialMgmtContext.ParamTables.FirstOrDefault(m => m.Cmpycode == po.CmpyCode && m.Code.Equals(PurchaseMgmtConstants.MRHeader));

                ds = _EzBusinessHelper.ExecuteDataSet("Select Nos from PARTTBL001 where CmpyCode='" + po.CmpyCode + "' and Code='" + PurchaseMgmtConstants.POHeader + "' ");
                POHeader pt = new POHeader();
                dt = ds.Tables[0];
                int pno = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    pno = Convert.ToInt16(dr["Nos"]);
                }
                    pt.PONumber = string.Concat(PurchaseMgmtConstants.POHeader, "-", (Convert.ToInt16(pno)).ToString().PadLeft(4, '0')).ToString();
                    pt.CmpyCode = po.CmpyCode;
                    pt.ResourceType = po.ResourceType;
                // pt.Dates = po.Dates ;

                DateTime dt1 = Convert.ToDateTime(po.Dates.ToString());

                dtstr = dt1.ToString("yyyy-MM-dd hh:mm:ss tt");

                DateTime dt2 = Convert.ToDateTime(po.Dates.ToString());

                dtstr1 = dt2.ToString("yyyy-MM-dd hh:mm:ss tt");

                // pt.Description = po.Description;
                    pt.ReqtBy = po.ReqtBy;
                    pt.LocCode = po.LocCode;
                    pt.ProjectCode = po.ProjectCode;
                    pt.ApprovalYN = PurchaseMgmtConstants.ApprovalYN;
                    //pt.MRFrom = PurchaseMgmtConstants.MRFrom;
                    pt.Status = PurchaseMgmtConstants.Status;
                    //pt.DontShowJobInList = 0;
                    //pt.GenerateInquiry = string.Empty;
                    //pt.IsPopUpCheckedByUser = 0;
                    //pt.JobNo = string.Empty;
                    pt.PreparedBy = "EASY";
                    pt.POPriority = po.POPriority;
                    pt.ResourceType = po.ResourceType;
                    pt.WONO = po.WONO;

                    pt.SupplierCode = po.SupplierCode;
                    pt.CurCode = po.CurCode;
                    pt.Status = po.Status;
                   // pt.ExpectedDeliveryDate = po.ExpectedDeliveryDate;
                    pt.DivisionCode = po.DivisionCode;
                    pt.POFrom = po.POFrom;

                pt.NetAmount = po.NetAmount;
                pt.LAmount = po.LAmount;

               




                List<PODetail> ObjList = new List<PODetail>();

                ObjList.AddRange(po.PurchaseOrderDetailsnew.Select(m => new PODetail
                {

                    CmpyCode = po.CmpyCode,
                    PoNumber = pt.PONumber,
                    Description = m.Description,
                    BaseUnitQty = 1,
                    BOQSno = 1,
                    Specification = m.Specification ?? string.Empty,
                    Sno = counter++,
                    ItemCode = m.ItemCode,
                    Unit = m.Unit,
                    LocCode = pt.LocCode,
                    AnalysisCode =string.Empty,
                    Asses_Amt =0,
                    AvgCost =0,
                    BaseDamage =0,
                    BaseOrder =0,
                    BaseReceived =0,                    
                    BoxOrdered =0,                    
                    CostCode =string.Empty,
                    Cust_Item_Code = string.Empty,
                    Cust_Item_Name = string.Empty,                    
                    Discount = m.DiscAmt.Value,
                    DiscountP = m.Discper.Value,
                    Ex_Duty_Amt = 0,
                    Ex_Duty_Per = 0,
                    Ex_Ed_Cess_Amt = 0,
                    Ex_Ed_Cess_Per = 0,
                    Ex_H_Ed_Cess_Amt = 0,
                    Ex_H_Ed_Cess_Per = 0,
                    FileType = string.Empty,
                    GrnInQty = 0,
                    IncludingVAT = 0,
                    InqNumber = string.Empty,
                    InvItemSno = counter++,
                    ItemActualCost = m.ItemPriceTotal.Value,                    
                    ItemSno = counter++,
                    ItemTotal = m.ItemPriceTotal.Value,
                    LNetAmount = m.NetAmt.Value,                    
                    NetAmount = m.NetAmt.Value,
                    NetAmountWithTax = 0,
                    NetPurchase = m.NetAmt.Value,
                    Notes = string.Empty,
                    OnOrderDiscAmt = 0,
                    OnOrderDiscPerc = 0,
                    Other_Amt = 0,
                    Other_Per = 0,
                    OverBudget =0,
                    PackageSno = 0,
                    Packing = string.Empty,
                    PerformaInvNo = string.Empty,                    
                    PoQtyAdd = 0,
                    PoQtyShort = 0,
                    ProcessCode = string.Empty,
                    ProcessName = string.Empty,
                    Product_Img = new byte[1],
                    ProjectCode = pt.ProjectCode,
                    QtyDamage = 0,
                    QtyOrdered = m.Quantity.Value,
                    QtyReceived = 0,
                    QtyShip = 0,
                    ReOpenQty = 0,
                    ReOpenReason = string.Empty,
                    RevisionNo = 0,
                    Select_Img = string.Empty,
                    Ser_Duty_Amt = 0,
                    Ser_Duty_Per = 0,
                    Ser_Ed_Cess_Amt = 0,
                    Ser_Ed_Cess_Per = 0,
                    Ser_H_Ed_Cess_Amt = 0,
                    Ser_H_Ed_Cess_Per = 0,                                       
                    Tax_Amt = 0,
                    Tax_per = 0,
                    Taxable_Amt = 0,
                    TaxAmount = 0,                    
                    UnitPrice = m.ItemPrice.Value,
                    VATAmount = 0,
                    VATPerc =0,
                    WoNumber = string.Empty

                }).ToList());

                StringBuilder sb = new StringBuilder();
                sb.Append("(CmpyCode,");
                sb.Append("PONumber,");
                sb.Append("LocCode,");
                sb.Append("Dates,");
                sb.Append("SupplierCode,");
                sb.Append("Status,");
                sb.Append("GrnStat,");
                sb.Append("CurCode,");
                sb.Append("CurRate,");
                sb.Append("YourRef,");
                sb.Append("GAmount,");
                sb.Append("DiscountP,");
                sb.Append("Discount,");
                sb.Append("NetAmount,");
                sb.Append("LAmount,");
                sb.Append("Remarks,");
                sb.Append("Att,");
                sb.Append("ProjectCode,");
                sb.Append("DivisionCode,");
                sb.Append("PerformaInvYN,");
                sb.Append("ShipDate,");
                sb.Append("SoNumber,");
                sb.Append("SalesManCode,");
                sb.Append("ProformaDates,");
                sb.Append("PaymentCode,");
                sb.Append("ModeOfPay,");
                sb.Append("DiscPerc,");
                sb.Append("PerformaInvNo,");
                sb.Append("ConsultCode,");
                sb.Append("ContractCode,");
                sb.Append("CC,");
                sb.Append("InquiryNo,");
                sb.Append("FullClear,");
                sb.Append("PoConfirm,");
                sb.Append("ReadyToShip,");
                sb.Append("Weight,");
                sb.Append("FollowUpStatus,");
                sb.Append("PoSchedule,");
                sb.Append("PoType,");
                sb.Append("POCloseManual,");
                sb.Append("AdditionalTerms,");
                sb.Append("InvStatus,");
                sb.Append("OnOrderTax,");
                sb.Append("POFrom,");
                sb.Append("QuotCode,");
                sb.Append("ApprovalYN,");
                sb.Append("ExpectedDeliveryDate,");
                sb.Append("TaxCalculationCode,");
                sb.Append("Asses_Amt,");
                sb.Append("Ex_Duty_Per,");
                sb.Append("Ex_Duty_Amt,");
                sb.Append("Ex_Ed_Cess_Per,");
                sb.Append("Ex_Ed_Cess_Amt,");
                sb.Append("Ex_H_Ed_Cess_Per,");
                sb.Append("Ex_H_Ed_Cess_Amt,");
                sb.Append("Ser_Duty_Per,");
                sb.Append("Ser_Duty_Amt,");
                sb.Append("Ser_Ed_Cess_Per,");
                sb.Append("Ser_Ed_Cess_Amt,");
                sb.Append("Ser_H_Ed_Cess_Per,");
                sb.Append("Ser_H_Ed_Cess_Amt,");
                sb.Append("Taxable_Amt,");
                sb.Append("Tax_per,");
                sb.Append("Tax_Amt,");
                sb.Append("Round_Off,");
                sb.Append("Insurance_Policy,");
                sb.Append("POScheduleTYpe,");
                sb.Append("IsSubContractor,");
                sb.Append("LCCode,");
                sb.Append("LCAmount,");
                sb.Append("LCBalanceAmount,");
                sb.Append("TotCharges,");
                sb.Append("IsInternal,");
                sb.Append("ResourceType,");
                sb.Append("PreparedBy,");
                sb.Append("PrepareDate,");
                sb.Append("RevisionNo,");
                sb.Append("Scope,");
                sb.Append("ContractType,");
                sb.Append("RetentionPer,");
                sb.Append("IsNotLastPCRetention,");
                sb.Append("ContractValue,");
                sb.Append("SecurityDepositPer,");
                sb.Append("AdvancePer,");
                sb.Append("LCurCode,");
                sb.Append("LGAmount,");
                sb.Append("LNetAmount,");
                sb.Append("DisAmount,");
                sb.Append("DiscountType,");
                sb.Append("SupplierContactPerson,");
                sb.Append("OnOrderDisc,");
                sb.Append("InterNetValue,");
                sb.Append("WONO,");
                sb.Append("POPriority,");
                sb.Append("ValidityDate,");
                sb.Append("ReqtBy,");
                sb.Append("ProjectLocation)");
                sb.Append(" values(");

                //'---
                sb.Append("'" + pt.CmpyCode + "',");
                sb.Append("'" + pt.PONumber + "',");
                sb.Append("'" + pt.LocCode + "',");
                sb.Append("'" + dtstr + "',");
                sb.Append("'" + pt.SupplierCode + "',");
                sb.Append("'" + pt.Status + "',");
                sb.Append("'" + pt.GrnStat + "',");
                sb.Append("'" + pt.CurCode + "',");
                sb.Append("'" + pt.CurRate + "',");
                sb.Append("'" + pt.YourRef + "',");
                sb.Append("'" + pt.GAmount + "',");
                sb.Append("'" + pt.DiscountP + "',");
                sb.Append("'" + pt.Discount + "',");
                sb.Append("'" + pt.NetAmount + "',");
                sb.Append("'" + pt.LAmount + "',");
                sb.Append("'" + pt.Remarks + "',");
                sb.Append("'" + pt.Att + "',");
                sb.Append("'" + pt.ProjectCode + "',");
                sb.Append("'" + pt.DivisionCode + "',");
                sb.Append("'" + pt.PerformaInvYN + "',");
                sb.Append("'" + pt.ShipDate + "',");
                sb.Append("'" + pt.SoNumber + "',");
                sb.Append("'" + pt.SalesManCode + "',");
                sb.Append("'" + pt.ProformaDates + "',");
                sb.Append("'" + pt.PaymentCode + "',");
                sb.Append("'" + pt.ModeOfPay + "',");
                sb.Append("'" + pt.DiscPerc + "',");
                sb.Append("'" + pt.PerformaInvNo + "',");
                sb.Append("'" + pt.ConsultCode + "',");
                sb.Append("'" + pt.ContractCode + "',");
                sb.Append("'" + pt.CC + "',");
                sb.Append("'" + pt.InquiryNo + "',");
                sb.Append("'" + pt.FullClear + "',");
                sb.Append("'" + pt.PoConfirm + "',");
                sb.Append("'" + pt.ReadyToShip + "',");
                sb.Append("'" + pt.Weight + "',");
                sb.Append("'" + pt.FollowUpStatus + "',");
                sb.Append("'" + pt.PoSchedule + "',");
                sb.Append("'" + pt.PoType + "',");
                sb.Append("'" + pt.POCloseManual + "',");
                sb.Append("'" + pt.AdditionalTerms + "',");
                sb.Append("'" + pt.InvStatus + "',");
                sb.Append("'" + pt.OnOrderTax + "',");
                sb.Append("'" + pt.POFrom + "',");
                sb.Append("'" + pt.QuotCode + "',");
                sb.Append("'" + pt.ApprovalYN + "',");
                sb.Append("'" + dtstr1 + "',");
                sb.Append("'" + pt.TaxCalculationCode + "',");
                sb.Append("'" + pt.Asses_Amt + "',");
                sb.Append("'" + pt.Ex_Duty_Per + "',");
                sb.Append("'" + pt.Ex_Duty_Amt + "',");
                sb.Append("'" + pt.Ex_Ed_Cess_Per + "',");
                sb.Append("'" + pt.Ex_Ed_Cess_Amt + "',");
                sb.Append("'" + pt.Ex_H_Ed_Cess_Per + "',");
                sb.Append("'" + pt.Ex_H_Ed_Cess_Amt + "',");
                sb.Append("'" + pt.Ser_Duty_Per + "',");
                sb.Append("'" + pt.Ser_Duty_Amt + "',");
                sb.Append("'" + pt.Ser_Ed_Cess_Per + "',");
                sb.Append("'" + pt.Ser_Ed_Cess_Amt + "',");
                sb.Append("'" + pt.Ser_H_Ed_Cess_Per + "',");
                sb.Append("'" + pt.Ser_H_Ed_Cess_Amt + "',");
                sb.Append("'" + pt.Taxable_Amt + "',");
                sb.Append("'" + pt.Tax_per + "',");
                sb.Append("'" + pt.Tax_Amt + "',");
                sb.Append("'" + pt.Round_Off + "',");
                sb.Append("'" + pt.Insurance_Policy + "',");
                sb.Append("'" + pt.POScheduleTYpe + "',");
                sb.Append("'" + pt.IsSubContractor + "',");
                sb.Append("'" + pt.LCCode + "',");
                sb.Append("'" + pt.LCAmount + "',");
                sb.Append("'" + pt.LCBalanceAmount + "',");
                sb.Append("'" + pt.TotCharges + "',");
                sb.Append("'" + pt.IsInternal + "',");
                sb.Append("'" + pt.ResourceType + "',");
                sb.Append("'" + pt.PreparedBy + "',");
                sb.Append("'" + pt.PrepareDate + "',");
                sb.Append("'" + pt.RevisionNo + "',");
                sb.Append("'" + pt.Scope + "',");
                sb.Append("'" + pt.ContractType + "',");
                sb.Append("'" + pt.RetentionPer + "',");
                sb.Append("'" + pt.IsNotLastPCRetention + "',");
                sb.Append("'" + pt.ContractValue + "',");
                sb.Append("'" + pt.SecurityDepositPer + "',");
                sb.Append("'" + pt.AdvancePer + "',");
                sb.Append("'" + pt.LCurCode + "',");
                sb.Append("'" + pt.LGAmount + "',");
                sb.Append("'" + pt.LNetAmount + "',");
                sb.Append("'" + pt.DisAmount + "',");
                sb.Append("'" + pt.DiscountType + "',");
                sb.Append("'" + pt.SupplierContactPerson + "',");
                sb.Append("'" + pt.OnOrderDisc + "',");
                sb.Append("'" + pt.InterNetValue + "',");
                sb.Append("'" + pt.WONO + "',");
                sb.Append("'" + pt.POPriority + "',");
                sb.Append("'" + pt.ValidityDate + "',");
                sb.Append("'" + pt.ReqtBy + "',");
                sb.Append("'" + pt.ProjectLocation + "')");

                _EzBusinessHelper.ExecuteNonQuery("insert into PoHeader" + sb + "");

               
                //_EzBusinessHelper.ExecuteNonQuery("insert into MReqHeader(MRCode,CmpyCode,ResourceType,Dates,Description,EmpCode,LocCode,ProjectCode,ApprovalYN,MRFrom,Status,DontShowJobInList,GenerateInquiry,IsPopUpCheckedByUser,JobNo,PreparedBy,Priority,RType,WONo) values('" + pt.MRCode + "','" + pt.CmpyCode + "','" + pt.ResourceType + "','" + pt.Dates + "','" + pt.Description + "','" + pt.EmpCode + "','" + pt.LocCode + "','" + pt.ProjectCode + "','" + pt.ApprovalYN + "','" + pt.MRFrom + "','" + pt.Status + "','" + pt.DontShowJobInList + "','" + pt.GenerateInquiry + "','" + pt.IsPopUpCheckedByUser + "','" + pt.JobNo + "','" + pt.PreparedBy + "','" + pt.Priority + "','" + pt.RType + "','" + pt.WONo + "')");
                n = ObjList.Count;

                while (n > 0)
                {
                    sb.Clear();

                    sb.Append("(CmpyCode,");
                    sb.Append("PoNumber,");
                    sb.Append("LocCode,");
                    sb.Append("Sno,");
                    sb.Append("ItemCode,");
                    sb.Append("Description,");
                    sb.Append("Packing,");
                    sb.Append("BaseUnitQty,");
                    sb.Append("Unit,");
                    sb.Append("QtyOrdered,");
                    sb.Append("UnitPrice,");
                    sb.Append("ItemTotal,");
                    sb.Append("DiscountP,");
                    sb.Append("Discount,");
                    sb.Append("IncludingVAT,");
                    sb.Append("VATPerc,");
                    sb.Append("VATAmount,");
                    sb.Append("NetAmount,");
                    sb.Append("QtyReceived,");
                    sb.Append("NetPurchase,");
                    sb.Append("QtyShip,");
                    sb.Append("PoQtyShort,");
                    sb.Append("QtyDamage,");
                    sb.Append("InqNumber,");
                    sb.Append("PerformaInvNo,");
                    sb.Append("Notes,");
                    sb.Append("PoQtyAdd,");
                    sb.Append("BoxOrdered,");
                    sb.Append("BaseOrder,");
                    sb.Append("BaseReceived,");
                    sb.Append("BaseDamage,");
                    sb.Append("ProjectCode,");
                    sb.Append("AnalysisCode,");
                    sb.Append("TaxAmount,");
                    sb.Append("NetAmountWithTax,");
                    sb.Append("ItemActualCost,");
                    sb.Append("Cust_Item_Code,");
                    sb.Append("Cust_Item_Name,");
                    sb.Append("Other_Amt,");
                    sb.Append("Other_Per,");
                    sb.Append("Asses_Amt,");
                    sb.Append("Ex_Duty_Per,");
                    sb.Append("Ex_Duty_Amt,");
                    sb.Append("Ex_Ed_Cess_Per,");
                    sb.Append("Ex_Ed_Cess_Amt,");
                    sb.Append("Ex_H_Ed_Cess_Per,");
                    sb.Append("Ex_H_Ed_Cess_Amt,");
                    sb.Append("Ser_Duty_Per,");
                    sb.Append("Ser_Duty_Amt,");
                    sb.Append("Ser_Ed_Cess_Per,");
                    sb.Append("Ser_Ed_Cess_Amt,");
                    sb.Append("Ser_H_Ed_Cess_Per,");
                    sb.Append("Ser_H_Ed_Cess_Amt,");
                    sb.Append("Taxable_Amt,");
                    sb.Append("Tax_per,");
                    sb.Append("Tax_Amt,");
                    sb.Append("GrnInQty,");
                    sb.Append("ItemSno,");
                    sb.Append("ProcessCode,");
                    sb.Append("ProcessName,");
                    sb.Append("InvItemSno,");
                    sb.Append("ReOpenQty,");
                    sb.Append("ReOpenReason,");
                    sb.Append("Specification,");
                    sb.Append("BOQSno,");
                    sb.Append("PackageSno,");
                    sb.Append("CostCode,");
                    sb.Append("OverBudget,");
                    sb.Append("RevisionNo,");
                    sb.Append("OnOrderDiscPerc,");
                    sb.Append("OnOrderDiscAmt,");
                    sb.Append("LNetAmount,");
                    sb.Append("AvgCost,");
                    sb.Append("Product_Img,");
                    sb.Append("Select_Img,");
                    sb.Append("FileType,");
                    sb.Append("WoNumber)");

                    sb.Append(" values(");

                    sb.Append("'" + ObjList[n - 1].CmpyCode.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].PoNumber.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].LocCode.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Sno.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].ItemCode.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Description.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Packing.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].BaseUnitQty.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Unit.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].QtyOrdered.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].UnitPrice.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].ItemTotal.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].DiscountP.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Discount.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].IncludingVAT.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].VATPerc.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].VATAmount.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].NetAmount.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].QtyReceived.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].NetPurchase.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].QtyShip.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].PoQtyShort.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].QtyDamage.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].InqNumber.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].PerformaInvNo.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Notes.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].PoQtyAdd.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].BoxOrdered.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].BaseOrder.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].BaseReceived.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].BaseDamage.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].ProjectCode.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].AnalysisCode.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].TaxAmount.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].NetAmountWithTax.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].ItemActualCost.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Cust_Item_Code.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Cust_Item_Name.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Other_Amt.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Other_Per.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Asses_Amt.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Ex_Duty_Per.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Ex_Duty_Amt.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Ex_Ed_Cess_Per.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Ex_Ed_Cess_Amt.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Ex_H_Ed_Cess_Per.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Ex_H_Ed_Cess_Amt.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Ser_Duty_Per.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Ser_Duty_Amt.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Ser_Ed_Cess_Per.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Ser_Ed_Cess_Amt.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Ser_H_Ed_Cess_Per.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Ser_H_Ed_Cess_Amt.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Taxable_Amt.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Tax_per.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Tax_Amt.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].GrnInQty.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].ItemSno.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].ProcessCode.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].ProcessName.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].InvItemSno.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].ReOpenQty.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].ReOpenReason.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Specification.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].BOQSno.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].PackageSno.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].CostCode.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].OverBudget.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].RevisionNo.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].OnOrderDiscPerc.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].OnOrderDiscAmt.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].LNetAmount.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].AvgCost.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Product_Img.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].Select_Img.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].FileType.ToString() + "' ,");
                    sb.Append("'" + ObjList[n - 1].WoNumber.ToString() + "')");

                    _EzBusinessHelper.ExecuteNonQuery("insert into PODetail" + sb + " ");
                    n = n - 1;
                }

                _EzBusinessHelper.ExecuteNonQuery(" UPDATE PARTTBL001 SET Nos = " + (pno+1) +" where CmpyCode='" + po.CmpyCode + "' and Code='" + PurchaseMgmtConstants.POHeader + "'");


                // _materialMgmtContext.SaveChanges();
                counter = 1;
                po.ErrorMessage = string.Empty;
                po.IsSavedFlag = true;
            }
            else
            {
                //var mr = _materialMgmtContext.MReqHeaders.FirstOrDefault(m => m.MRCode.Equals(po.MRCode) && m.CmpyCode.Equals(po.CmpyCode));
                ds = _EzBusinessHelper.ExecuteDataSet("Select * from PoHeader where CmpyCode='" + po.CmpyCode + "' and PONumber='" + po.PONumber + "' ");

                POHeader pt = new POHeader();
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {

                    //if (mr != null)
                    //{
                    // pt.Dates = po.Dates;

                    DateTime dt1 = Convert.ToDateTime(po.Dates.ToString());

                    dtstr = dt1.ToString("yyyy-MM-dd hh:mm:ss tt");

                    DateTime dt2 = Convert.ToDateTime(po.Dates.ToString());

                    dtstr1 = dt2.ToString("yyyy-MM-dd hh:mm:ss tt");

                    pt.CmpyCode = po.CmpyCode;
                    pt.POPriority = "M";
                    pt.ReqtBy = po.ReqtBy;
                    pt.LocCode = po.LocCode;
                    pt.ResourceType = po.ResourceType;
                    pt.ProjectCode = po.ProjectCode;

                    pt.SupplierCode = po.SupplierCode;
                    pt.CurCode = po.CurCode;
                    pt.Status = po.Status;
                   // pt.ExpectedDeliveryDate = po.ExpectedDeliveryDate;
                    pt.DivisionCode = po.DivisionCode;
                    pt.POFrom = po.POFrom;


                    pt.NetAmount = po.NetAmount;
                    pt.LAmount = po.LAmount;


                    _EzBusinessHelper.ExecuteNonQuery("Delete from PODetail where PONumber= '" + po.PONumber + "' and CmpyCode='" + po.CmpyCode + "' ");

                    _EzBusinessHelper.ExecuteNonQuery("Delete from poheader where PONumber= '" + po.PONumber + "' and CmpyCode='" + po.CmpyCode + "' ");
                    List<PODetail> ObjList = new List<PODetail>();
                   // decimal d1 = null;
                    ObjList.AddRange(po.PurchaseOrderDetailsnew.Select(m => new PODetail
                    {

                        CmpyCode = po.CmpyCode,
                        PoNumber = po.PONumber,
                        Description = m.Description,
                        BaseUnitQty = 1,
                        BOQSno = 1,
                        Specification = m.Specification ?? string.Empty,
                        Sno = counter++,
                        ItemCode = m.ItemCode,
                        Unit = m.Unit,
                        LocCode = pt.LocCode,
                        AnalysisCode = string.Empty,
                        Asses_Amt = 0,
                        AvgCost = 0,
                        BaseDamage = 0,
                        BaseOrder = 0,
                        BaseReceived = 0,
                        BoxOrdered = 0,
                        CostCode = string.Empty,
                        Cust_Item_Code = string.Empty,
                        Cust_Item_Name = string.Empty,
                        Discount = m.DiscAmt.Value,
                     
                        DiscountP = m.Discper.Value,
                        Ex_Duty_Amt = 0,
                        Ex_Duty_Per = 0,
                        Ex_Ed_Cess_Amt = 0,
                        Ex_Ed_Cess_Per = 0,
                        Ex_H_Ed_Cess_Amt = 0,
                        Ex_H_Ed_Cess_Per = 0,
                        FileType = string.Empty,
                        GrnInQty = 0,
                        IncludingVAT = 0,
                        InqNumber = string.Empty,
                        InvItemSno = counter++,
                        ItemActualCost = m.ItemPriceTotal.Value,
                        ItemSno = counter++,
                        ItemTotal = m.ItemPriceTotal.Value,
                        LNetAmount = m.NetAmt.Value,
                        NetAmount = m.NetAmt.Value,
                        NetAmountWithTax = 0,
                        NetPurchase = m.NetAmt.Value,
                        Notes = string.Empty,
                        OnOrderDiscAmt = 0,
                        OnOrderDiscPerc = 0,
                        Other_Amt = 0,
                        Other_Per = 0,
                        OverBudget = 0,
                        PackageSno = 0,
                        Packing = string.Empty,
                        PerformaInvNo = string.Empty,
                        PoQtyAdd = 0,
                        PoQtyShort = 0,
                        ProcessCode = string.Empty,
                        ProcessName = string.Empty,
                        Product_Img = new byte[1],
                        ProjectCode = pt.ProjectCode,
                        QtyDamage = 0,
                        QtyOrdered = m.Quantity.Value,
                        QtyReceived = 0,
                        QtyShip = 0,
                        ReOpenQty = 0,
                        ReOpenReason = string.Empty,
                        RevisionNo = 0,
                        Select_Img = string.Empty,
                        Ser_Duty_Amt = 0,
                        Ser_Duty_Per = 0,
                        Ser_Ed_Cess_Amt = 0,
                        Ser_Ed_Cess_Per = 0,
                        Ser_H_Ed_Cess_Amt = 0,
                        Ser_H_Ed_Cess_Per = 0,
                        Tax_Amt = 0,
                        Tax_per = 0,
                        Taxable_Amt = 0,
                        TaxAmount = 0,
                        UnitPrice = m.ItemPrice.Value,
                        VATAmount = 0,
                        VATPerc = 0,
                        WoNumber = string.Empty

                    }).ToList());


                    StringBuilder sb =new  StringBuilder();
                    sb.Append("(CmpyCode,");
                    sb.Append("PONumber,");
                    sb.Append("LocCode,");
                    sb.Append("Dates,");
                    sb.Append("SupplierCode,");
                    sb.Append("Status,");
                    sb.Append("GrnStat,");
                    sb.Append("CurCode,");
                    sb.Append("CurRate,");
                    sb.Append("YourRef,");
                    sb.Append("GAmount,");
                    sb.Append("DiscountP,");
                    sb.Append("Discount,");
                    sb.Append("NetAmount,");
                    sb.Append("LAmount,");
                    sb.Append("Remarks,");
                    sb.Append("Att,");
                    sb.Append("ProjectCode,");
                    sb.Append("DivisionCode,");
                    sb.Append("PerformaInvYN,");
                    sb.Append("ShipDate,");
                    sb.Append("SoNumber,");
                    sb.Append("SalesManCode,");
                    sb.Append("ProformaDates,");
                    sb.Append("PaymentCode,");
                    sb.Append("ModeOfPay,");
                    sb.Append("DiscPerc,");
                    sb.Append("PerformaInvNo,");
                    sb.Append("ConsultCode,");
                    sb.Append("ContractCode,");
                    sb.Append("CC,");
                    sb.Append("InquiryNo,");
                    sb.Append("FullClear,");
                    sb.Append("PoConfirm,");
                    sb.Append("ReadyToShip,");
                    sb.Append("Weight,");
                    sb.Append("FollowUpStatus,");
                    sb.Append("PoSchedule,");
                    sb.Append("PoType,");
                    sb.Append("POCloseManual,");
                    sb.Append("AdditionalTerms,");
                    sb.Append("InvStatus,");
                    sb.Append("OnOrderTax,");
                    sb.Append("POFrom,");
                    sb.Append("QuotCode,");
                    sb.Append("ApprovalYN,");
                    sb.Append("ExpectedDeliveryDate,");
                    sb.Append("TaxCalculationCode,");
                    sb.Append("Asses_Amt,");
                    sb.Append("Ex_Duty_Per,");
                    sb.Append("Ex_Duty_Amt,");
                    sb.Append("Ex_Ed_Cess_Per,");
                    sb.Append("Ex_Ed_Cess_Amt,");
                    sb.Append("Ex_H_Ed_Cess_Per,");
                    sb.Append("Ex_H_Ed_Cess_Amt,");
                    sb.Append("Ser_Duty_Per,");
                    sb.Append("Ser_Duty_Amt,");
                    sb.Append("Ser_Ed_Cess_Per,");
                    sb.Append("Ser_Ed_Cess_Amt,");
                    sb.Append("Ser_H_Ed_Cess_Per,");
                    sb.Append("Ser_H_Ed_Cess_Amt,");
                    sb.Append("Taxable_Amt,");
                    sb.Append("Tax_per,");
                    sb.Append("Tax_Amt,");
                    sb.Append("Round_Off,");
                    sb.Append("Insurance_Policy,");
                    sb.Append("POScheduleTYpe,");
                    sb.Append("IsSubContractor,");
                    sb.Append("LCCode,");
                    sb.Append("LCAmount,");
                    sb.Append("LCBalanceAmount,");
                    sb.Append("TotCharges,");
                    sb.Append("IsInternal,");
                    sb.Append("ResourceType,");
                    sb.Append("PreparedBy,");
                    sb.Append("PrepareDate,");
                    sb.Append("RevisionNo,");
                    sb.Append("Scope,");
                    sb.Append("ContractType,");
                    sb.Append("RetentionPer,");
                    sb.Append("IsNotLastPCRetention,");
                    sb.Append("ContractValue,");
                    sb.Append("SecurityDepositPer,");
                    sb.Append("AdvancePer,");
                    sb.Append("LCurCode,");
                    sb.Append("LGAmount,");
                    sb.Append("LNetAmount,");
                    sb.Append("DisAmount,");
                    sb.Append("DiscountType,");
                    sb.Append("SupplierContactPerson,");
                    sb.Append("OnOrderDisc,");
                    sb.Append("InterNetValue,");
                    sb.Append("WONO,");
                    sb.Append("POPriority,");
                    sb.Append("ValidityDate,");
                    sb.Append("ReqtBy,");
                    sb.Append("ProjectLocation)");
                    sb.Append(" values(");

                    //'---
                    sb.Append("'" + po.CmpyCode + "',");
                    sb.Append("'" + po.PONumber + "',");
                    sb.Append("'" + pt.LocCode + "',");
                    sb.Append("'" + dtstr + "',");
                    sb.Append("'" + pt.SupplierCode + "',");
                    sb.Append("'" + pt.Status + "',");
                    sb.Append("'" + pt.GrnStat + "',");
                    sb.Append("'" + pt.CurCode + "',");
                    sb.Append("'" + pt.CurRate + "',");
                    sb.Append("'" + pt.YourRef + "',");
                    sb.Append("'" + pt.GAmount + "',");
                    sb.Append("'" + pt.DiscountP + "',");
                    sb.Append("'" + pt.Discount + "',");
                    sb.Append("'" + pt.NetAmount + "',");
                    sb.Append("'" + pt.LAmount + "',");
                    sb.Append("'" + pt.Remarks + "',");
                    sb.Append("'" + pt.Att + "',");
                    sb.Append("'" + pt.ProjectCode + "',");
                    sb.Append("'" + pt.DivisionCode + "',");
                    sb.Append("'" + pt.PerformaInvYN + "',");
                    sb.Append("'" + pt.ShipDate + "',");
                    sb.Append("'" + pt.SoNumber + "',");
                    sb.Append("'" + pt.SalesManCode + "',");
                    sb.Append("'" + pt.ProformaDates + "',");
                    sb.Append("'" + pt.PaymentCode + "',");
                    sb.Append("'" + pt.ModeOfPay + "',");
                    sb.Append("'" + pt.DiscPerc + "',");
                    sb.Append("'" + pt.PerformaInvNo + "',");
                    sb.Append("'" + pt.ConsultCode + "',");
                    sb.Append("'" + pt.ContractCode + "',");
                    sb.Append("'" + pt.CC + "',");
                    sb.Append("'" + pt.InquiryNo + "',");
                    sb.Append("'" + pt.FullClear + "',");
                    sb.Append("'" + pt.PoConfirm + "',");
                    sb.Append("'" + pt.ReadyToShip + "',");
                    sb.Append("'" + pt.Weight + "',");
                    sb.Append("'" + pt.FollowUpStatus + "',");
                    sb.Append("'" + pt.PoSchedule + "',");
                    sb.Append("'" + pt.PoType + "',");
                    sb.Append("'" + pt.POCloseManual + "',");
                    sb.Append("'" + pt.AdditionalTerms + "',");
                    sb.Append("'" + pt.InvStatus + "',");
                    sb.Append("'" + pt.OnOrderTax + "',");
                    sb.Append("'" + pt.POFrom + "',");
                    sb.Append("'" + pt.QuotCode + "',");
                    sb.Append("'" + pt.ApprovalYN + "',");
                    sb.Append("'" + dtstr1 + "',");
                    sb.Append("'" + pt.TaxCalculationCode + "',");
                    sb.Append("'" + pt.Asses_Amt + "',");
                    sb.Append("'" + pt.Ex_Duty_Per + "',");
                    sb.Append("'" + pt.Ex_Duty_Amt + "',");
                    sb.Append("'" + pt.Ex_Ed_Cess_Per + "',");
                    sb.Append("'" + pt.Ex_Ed_Cess_Amt + "',");
                    sb.Append("'" + pt.Ex_H_Ed_Cess_Per + "',");
                    sb.Append("'" + pt.Ex_H_Ed_Cess_Amt + "',");
                    sb.Append("'" + pt.Ser_Duty_Per + "',");
                    sb.Append("'" + pt.Ser_Duty_Amt + "',");
                    sb.Append("'" + pt.Ser_Ed_Cess_Per + "',");
                    sb.Append("'" + pt.Ser_Ed_Cess_Amt + "',");
                    sb.Append("'" + pt.Ser_H_Ed_Cess_Per + "',");
                    sb.Append("'" + pt.Ser_H_Ed_Cess_Amt + "',");
                    sb.Append("'" + pt.Taxable_Amt + "',");
                    sb.Append("'" + pt.Tax_per + "',");
                    sb.Append("'" + pt.Tax_Amt + "',");
                    sb.Append("'" + pt.Round_Off + "',");
                    sb.Append("'" + pt.Insurance_Policy + "',");
                    sb.Append("'" + pt.POScheduleTYpe + "',");
                    sb.Append("'" + pt.IsSubContractor + "',");
                    sb.Append("'" + pt.LCCode + "',");
                    sb.Append("'" + pt.LCAmount + "',");
                    sb.Append("'" + pt.LCBalanceAmount + "',");
                    sb.Append("'" + pt.TotCharges + "',");
                    sb.Append("'" + pt.IsInternal + "',");
                    sb.Append("'" + pt.ResourceType + "',");
                    sb.Append("'" + pt.PreparedBy + "',");
                    sb.Append("'" + pt.PrepareDate + "',");
                    sb.Append("'" + pt.RevisionNo + "',");
                    sb.Append("'" + pt.Scope + "',");
                    sb.Append("'" + pt.ContractType + "',");
                    sb.Append("'" + pt.RetentionPer + "',");
                    sb.Append("'" + pt.IsNotLastPCRetention + "',");
                    sb.Append("'" + pt.ContractValue + "',");
                    sb.Append("'" + pt.SecurityDepositPer + "',");
                    sb.Append("'" + pt.AdvancePer + "',");
                    sb.Append("'" + pt.LCurCode + "',");
                    sb.Append("'" + pt.LGAmount + "',");
                    sb.Append("'" + pt.LNetAmount + "',");
                    sb.Append("'" + pt.DisAmount + "',");
                    sb.Append("'" + pt.DiscountType + "',");
                    sb.Append("'" + pt.SupplierContactPerson + "',");
                    sb.Append("'" + pt.OnOrderDisc + "',");
                    sb.Append("'" + pt.InterNetValue + "',");
                    sb.Append("'" + pt.WONO + "',");
                    sb.Append("'" + pt.POPriority + "',");
                    sb.Append("'" + pt.ValidityDate + "',");
                    sb.Append("'" + pt.ReqtBy + "',");
                    sb.Append("'" + pt.ProjectLocation + "')");

                    _EzBusinessHelper.ExecuteNonQuery("insert into PoHeader"+ sb +"");

                    n = ObjList.Count;

                  

                    while (n > 0)
                    {

                        sb.Clear();

                        sb.Append("(CmpyCode,");
                        sb.Append("PoNumber,");
                        sb.Append("LocCode,");
                        sb.Append("Sno,");
                        sb.Append("ItemCode,");
                        sb.Append("Description,");
                        sb.Append("Packing,");
                        sb.Append("BaseUnitQty,");
                        sb.Append("Unit,");
                        sb.Append("QtyOrdered,");
                        sb.Append("UnitPrice,");
                        sb.Append("ItemTotal,");
                        sb.Append("DiscountP,");
                        sb.Append("Discount,");
                        sb.Append("IncludingVAT,");
                        sb.Append("VATPerc,");
                        sb.Append("VATAmount,");
                        sb.Append("NetAmount,");
                        sb.Append("QtyReceived,");
                        sb.Append("NetPurchase,");
                        sb.Append("QtyShip,");
                        sb.Append("PoQtyShort,");
                        sb.Append("QtyDamage,");
                        sb.Append("InqNumber,");
                        sb.Append("PerformaInvNo,");
                        sb.Append("Notes,");
                        sb.Append("PoQtyAdd,");
                        sb.Append("BoxOrdered,");
                        sb.Append("BaseOrder,");
                        sb.Append("BaseReceived,");
                        sb.Append("BaseDamage,");
                        sb.Append("ProjectCode,");
                        sb.Append("AnalysisCode,");
                        sb.Append("TaxAmount,");
                        sb.Append("NetAmountWithTax,");
                        sb.Append("ItemActualCost,");
                        sb.Append("Cust_Item_Code,");
                        sb.Append("Cust_Item_Name,");
                        sb.Append("Other_Amt,");
                        sb.Append("Other_Per,");
                        sb.Append("Asses_Amt,");
                        sb.Append("Ex_Duty_Per,");
                        sb.Append("Ex_Duty_Amt,");
                        sb.Append("Ex_Ed_Cess_Per,");
                        sb.Append("Ex_Ed_Cess_Amt,");
                        sb.Append("Ex_H_Ed_Cess_Per,");
                        sb.Append("Ex_H_Ed_Cess_Amt,");
                        sb.Append("Ser_Duty_Per,");
                        sb.Append("Ser_Duty_Amt,");
                        sb.Append("Ser_Ed_Cess_Per,");
                        sb.Append("Ser_Ed_Cess_Amt,");
                        sb.Append("Ser_H_Ed_Cess_Per,");
                        sb.Append("Ser_H_Ed_Cess_Amt,");
                        sb.Append("Taxable_Amt,");
                        sb.Append("Tax_per,");
                        sb.Append("Tax_Amt,");
                        sb.Append("GrnInQty,");
                        sb.Append("ItemSno,");
                        sb.Append("ProcessCode,");
                        sb.Append("ProcessName,");
                        sb.Append("InvItemSno,");
                        sb.Append("ReOpenQty,");
                        sb.Append("ReOpenReason,");
                        sb.Append("Specification,");
                        sb.Append("BOQSno,");
                        sb.Append("PackageSno,");
                        sb.Append("CostCode,");
                        sb.Append("OverBudget,");
                        sb.Append("RevisionNo,");
                        sb.Append("OnOrderDiscPerc,");
                        sb.Append("OnOrderDiscAmt,");
                        sb.Append("LNetAmount,");
                        sb.Append("AvgCost,");
                        sb.Append("Product_Img,");
                        sb.Append("Select_Img,");
                        sb.Append("FileType,");
                        sb.Append("WoNumber)");

                        sb.Append(" values(");

                        sb.Append("'" + ObjList[n - 1].CmpyCode.ToString() +"' ,");
                        sb.Append("'" + ObjList[n - 1].PoNumber.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].LocCode.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Sno.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].ItemCode.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Description.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Packing.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].BaseUnitQty.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Unit.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].QtyOrdered.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].UnitPrice.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].ItemTotal.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].DiscountP.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Discount.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].IncludingVAT.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].VATPerc.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].VATAmount.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].NetAmount.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].QtyReceived.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].NetPurchase.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].QtyShip.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].PoQtyShort.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].QtyDamage.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].InqNumber.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].PerformaInvNo.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Notes.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].PoQtyAdd.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].BoxOrdered.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].BaseOrder.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].BaseReceived.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].BaseDamage.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].ProjectCode.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].AnalysisCode.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].TaxAmount.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].NetAmountWithTax.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].ItemActualCost.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Cust_Item_Code.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Cust_Item_Name.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Other_Amt.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Other_Per.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Asses_Amt.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Ex_Duty_Per.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Ex_Duty_Amt.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Ex_Ed_Cess_Per.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Ex_Ed_Cess_Amt.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Ex_H_Ed_Cess_Per.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Ex_H_Ed_Cess_Amt.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Ser_Duty_Per.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Ser_Duty_Amt.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Ser_Ed_Cess_Per.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Ser_Ed_Cess_Amt.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Ser_H_Ed_Cess_Per.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Ser_H_Ed_Cess_Amt.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Taxable_Amt.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Tax_per.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Tax_Amt.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].GrnInQty.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].ItemSno.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].ProcessCode.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].ProcessName.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].InvItemSno.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].ReOpenQty.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].ReOpenReason.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Specification.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].BOQSno.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].PackageSno.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].CostCode.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].OverBudget.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].RevisionNo.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].OnOrderDiscPerc.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].OnOrderDiscAmt.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].LNetAmount.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].AvgCost.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Product_Img.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].Select_Img.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].FileType.ToString() + "' ,");
                        sb.Append("'" + ObjList[n - 1].WoNumber.ToString()+"')");


                        _EzBusinessHelper.ExecuteNonQuery("insert into PODetail" + sb + " ");
                        n = n - 1;
                    }
                }


                // _materialMgmtContext.SaveChanges();

                po.ErrorMessage = string.Empty;
                po.IsSavedFlag = true;
                //}
                //else
                //{
                //    po.ErrorMessage = "Purchase Order Header not available";
                //    po.IsSavedFlag = false;
                //}
            }

            return po;
        }
    }
}
