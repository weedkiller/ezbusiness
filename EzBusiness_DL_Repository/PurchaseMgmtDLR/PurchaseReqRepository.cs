using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.PurchaseMgmt;
using EzBusiness_ViewModels;

using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace EzBusiness_DL_Repository
{
    public class PurchaseReqRepository : IPurchaseReqRepository
    {

        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        public bool DeletePurchaseOrder(string CmpyCode, string MRCode)
        {
            int unit = _EzBusinessHelper.ExecuteScalar("Select count(*) from PMMRH001 where CmpyCode='" + CmpyCode + "' and MRCode='" + MRCode + "'");
            if (unit != 0)
            {
                _EzBusinessHelper.ExecuteNonQuery("delete from PMMRD002 where CmpyCode='" + CmpyCode + "' and MRCode='" + MRCode + "'");
                _EzBusinessHelper.ExecuteNonQuery("delete from PMMRH001 where CmpyCode='" + CmpyCode + "' and MRCode='" + MRCode + "'");
                return true;
            }
            return false;
        }

        public PurchaseOrderDetail GetItemCodeDescription(string CmpyCode, string itemCode, string restyp)
        {
            if (restyp=="A")
            {
                ds = _EzBusinessHelper.ExecuteDataSet("Select SelfGenCode as [ItemCode],Code as [Description],'NOS' as [Unit] from MMAT001 where Cmpycode='" + CmpyCode + "' and SelfGenCode='" + itemCode + "' ");
            }
            else
            {
                ds = _EzBusinessHelper.ExecuteDataSet("Select ItemCode,Description,Unit from MMP001 where Cmpycode='" + CmpyCode + "' and ItemCode='" + itemCode + "' and ShowInPurchase != 0 and PrdType='" + PurchaseMgmtConstants.PrdType + "'");
            }
            dt = ds.Tables[0];                    
            PurchaseOrderDetail po=new PurchaseOrderDetail();
            foreach (DataRow dr in dt.Rows)
            {               
                po.ItemCode = dr["ItemCode"].ToString();
                po.Description = dr["Description"].ToString();
                po.Unit = dr["Unit"].ToString();                
            }
            return  po;           
        }

        public List<Product> GetItemCodeList(string CmpyCode, string restyp)
        {
            //ds = _EzBusinessHelper.ExecuteDataSet("Select ItemCode from Products where CmpyCode='" + CmpyCode + "'  AND PrdType='"+ PurchaseMgmtConstants.PrdType +"' ");
          
            SqlParameter[] param = {new SqlParameter("@Cmpycode1", CmpyCode),
                        new SqlParameter("@xResourceType", restyp)};

            ds = _EzBusinessHelper.ExecuteDataSet("GF_Show_Item_Drop_Down",CommandType.StoredProcedure,param);
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
            ds = _EzBusinessHelper.ExecuteDataSet("Select LocCode,LocName from MLOC018 where CmpyCode='" + CmpyCode + "' ");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Location> ObjList = new List<Location>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new Location()
                {
                    LocCode = dr["LocCode"].ToString(),
                    LocName=dr["LocName"].ToString(),
                });

            }
            return ObjList;
        }

        public List<MReqDetail> GetPODetailsList(string CmpyCode, string MRCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PMMRD002 where CmpyCode='" + CmpyCode + "' and MRCode='" + MRCode + "' ");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<MReqDetail> ObjList = new List<MReqDetail>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new MReqDetail()
                {

                    ItemCode=dr["ItemCode"].ToString(),
                    Description = dr["Description"].ToString(),
                    Qty =Convert.ToDecimal(dr["Qty"].ToString()),
                    Specification = dr["Specification"].ToString(),
                    Unit = dr["Unit"].ToString(),

                }
                    
                    );

                
            }
            return ObjList;
        }

        public PurchaseReqVM GetPOMasterDetailsEdit(string CmpyCode, string MRCode)
        {
          
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PMMRH001 where CmpyCode='" + CmpyCode + "' and MRCode='" + MRCode + "' ");
           
            dt = ds.Tables[0];
            PurchaseReqVM pr = new PurchaseReqVM();
            foreach (DataRow dr in dt.Rows)
            {
                pr.CmpyCode = dr["CmpyCode"].ToString();
                pr.MRCode = dr["MRCode"].ToString();
                pr.Description = dr["Description"].ToString();
                pr.LocationCode = dr["LocCode"].ToString();
                pr.PODate = Convert.ToDateTime(dr["Dates"].ToString());
                //pr.PODate = Convert.ToDateTime(DateTime.ParseExact(dr["Dates"].ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture));
                pr.PreparedBy = dr["PreparedBy"].ToString();
                pr.ProjectCode = dr["ProjectCode"].ToString();
                pr.RequesterCode = dr["EmpCode"].ToString();
                pr.ResourceType = dr["ResourceType"].ToString();
                
            }
            return pr;
         
        }

        public List<CostCenterHeader> GetProjects(string CmpyCode)
        {
            
            ds = _EzBusinessHelper.ExecuteDataSet("Select Name,Code from CCH004 where CmpyCode='" + CmpyCode + "' ");
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

        public List<MReqHeader> GetPurchaseOrderList(string CmpyCode)
        {            
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PMMRH001 where CmpyCode='" + CmpyCode + "' ");



            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<MReqHeader> ObjList = new List<MReqHeader>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new MReqHeader()
                {

                    CmpyCode=dr["CmpyCode"].ToString(),
                    ApprovalYN=dr["ApprovalYN"].ToString(),
                    Dates = Convert.ToDateTime(dr["Dates"].ToString()),                
                    //Dates = Convert.ToDateTime(DateTime.ParseExact(dr["Dates"].ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture)),
                Description = dr["Description"].ToString(),
                    DontShowJobInList = Convert.ToInt16(dr["DontShowJobInList"].ToString()),
                    EmpCode = dr["EmpCode"].ToString(),
                    GenerateInquiry = dr["GenerateInquiry"].ToString(),
                    IsPopUpCheckedByUser =Convert.ToInt16(dr["IsPopUpCheckedByUser"].ToString()),
                    JobNo = dr["JobNo"].ToString(), 
                    LocCode = dr["LocCode"].ToString(),
                    MRCode = dr["MRCode"].ToString(),
                    MRFrom = dr["MRFrom"].ToString(),
                    PreparedBy = dr["PreparedBy"].ToString(),
                    Priority = dr["Priority"].ToString(),
                    ProjectCode = dr["ProjectCode"].ToString(),
                    ResourceType     = dr["ResourceType"].ToString(),
                    RType = dr["RType"].ToString(),
                    Status = dr["Status"].ToString(),
                    WONo = dr["WONo"].ToString(),

                }
              );
            }
            return ObjList;
        }

        public List<Employee> GetRequesterList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select empName,empcode from MEM001 where CmpyCode='" + CmpyCode + "' and WorkingStatus = '"+ PurchaseMgmtConstants.WorkingStatus +"' ");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Employee> ObjList = new List<Employee>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new Employee()
                {
                    Empname = dr["Empname"].ToString(),
                    EmpCode=dr["EmpCode"].ToString(),
                });

            }
            return ObjList;
        }

        private String FormatDate(String _Date)
        {
            DateTime Dt = DateTime.Now;
            IFormatProvider mFomatter = new System.Globalization.CultureInfo("en-US");
            Dt = DateTime.Parse(_Date, mFomatter);
            return Dt.ToString("yyyy-MM-dd");
        }

        public PurchaseReqVM SavePurchaseOrder(PurchaseReqVM po)
        {
            // throw new NotImplementedException();
            int n;
            string dtstr =null ;
            //try
            //{
                var counter = 1;
                if (!po.IsEditMode)
                {
                // var pt = _materialMgmtContext.ParamTables.FirstOrDefault(m => m.Cmpycode == po.CmpyCode && m.Code.Equals(PurchaseMgmtConstants.MRHeader));

                ds = _EzBusinessHelper.ExecuteDataSet("Select * from PARTTBL001 where CmpyCode='" + po.CmpyCode + "' and Code='" + PurchaseMgmtConstants.MRHeader + "' ");
                MReqHeader pt = new MReqHeader();
                dt = ds.Tables[0];
                int pno = 0;
                foreach (DataRow dr in dt.Rows)
                {

                    pno = Convert.ToInt16(dr["Nos"]) + 1;
                }
                pt.MRCode = string.Concat(PurchaseMgmtConstants.MRHeader, "-", (Convert.ToInt16(pno)).ToString().PadLeft(4, '0')).ToString();
                    pt.CmpyCode = po.CmpyCode;
                    pt.ResourceType = po.ResourceType;
                                        
                    DateTime dt1 = Convert.ToDateTime(po.PODate.ToString());

                    dtstr = dt1.ToString("yyyy-MM-dd hh:mm:ss tt");
                   // pt.Dates = po.PODate;
                    pt.Description = po.Description;
                    pt.EmpCode = po.RequesterCode;
                    pt.LocCode = po.LocationCode;
                    pt.ProjectCode = po.ProjectCode;
                    pt.ApprovalYN = PurchaseMgmtConstants.ApprovalYN;
                    pt.MRFrom = PurchaseMgmtConstants.MRFrom;
                    pt.Status = PurchaseMgmtConstants.Status;
                    pt.DontShowJobInList = 0;
                    pt.GenerateInquiry = string.Empty;
                    pt.IsPopUpCheckedByUser = 0;
                    pt.JobNo = string.Empty;
                    pt.PreparedBy = "EASY";
                    pt.Priority = "N";
                    pt.RType = string.Empty;
                    pt.WONo = string.Empty;

               

               


                List<MReqDetail> ObjList = new List<MReqDetail>();

                ObjList.AddRange(po.PurchaseOrderDetails.Select(m => new MReqDetail
                {

                    CmpyCode = po.CmpyCode,
                    MRCode = pt.MRCode, //response.MRCode,
                    Description = m.Description,
                    BaseQtyReq = 1,
                    BaseUnitQty = m.Quantity,
                    BOQSno = 1,
                    Specification =m.Specification ?? string.Empty,
                    SNo = counter++,
                    ItemCode = m.ItemCode,
                    Unit = m.Unit,
                    Qty = m.Quantity,
                    CostCode = string.Empty,
                    FileType = string.Empty,
                    ImgDesc = string.Empty,
                    OverBudget = 0,
                    PackageSno = 0,
                    PartNumber = string.Empty,
                    Product_Img = new byte[1],
                    QtyReceived = 0,
                    Select_Img = string.Empty
                }).ToList());

                _EzBusinessHelper.ExecuteNonQuery("insert into PMMRH001(MRCode,CmpyCode,ResourceType,Dates,Description,EmpCode,LocCode,ProjectCode,ApprovalYN,MRFrom,Status,DontShowJobInList,GenerateInquiry,IsPopUpCheckedByUser,JobNo,PreparedBy,Priority,RType,WONo) values('" + pt.MRCode + "','" + pt.CmpyCode + "','" + pt.ResourceType + "','" + dtstr + "','" + pt.Description + "','" + pt.EmpCode + "','" + pt.LocCode + "','" + pt.ProjectCode + "','" + pt.ApprovalYN + "','" + pt.MRFrom + "','" + pt.Status + "','" + pt.DontShowJobInList + "','" + pt.GenerateInquiry + "','" + pt.IsPopUpCheckedByUser + "','" + pt.JobNo + "','" + pt.PreparedBy + "','" + pt.Priority + "','" + pt.RType + "','" + pt.WONo + "')");
                n = ObjList.Count;
               
               while(n>0)
                {                     
                _EzBusinessHelper.ExecuteNonQuery("insert into PMMRD002(CmpyCode,MRCode,Description,BaseQtyReq,BaseUnitQty,BOQSno,Specification,SNo,ItemCode,Unit,Qty,CostCode,FileType,ImgDesc,OverBudget,PackageSno,PartNumber,Product_Img,QtyReceived,Select_Img) values('"+ ObjList[n-1].CmpyCode.ToString()  + "','" + ObjList[n - 1].MRCode.ToString()+ "','" + ObjList[n - 1].Description.ToString() + "','" + ObjList[n - 1].BaseQtyReq.ToString()+ "','" + ObjList[n - 1].BaseUnitQty.ToString() + "','"+ ObjList[n - 1].BOQSno.ToString()+"', '"+ ObjList[n - 1].Specification.ToString()+ "','" + ObjList[n - 1].SNo.ToString()+ "','" + ObjList[n - 1].ItemCode.ToString() + "','" + ObjList[n - 1].Unit.ToString() + "','" + ObjList[n - 1].Qty.ToString() + "','" + ObjList[n - 1].CostCode.ToString() + "','" + ObjList[n - 1].FileType.ToString() + "','" + ObjList[n - 1].ImgDesc.ToString() + "','" + ObjList[n - 1].OverBudget.ToString() + "','" + ObjList[n - 1].PackageSno.ToString() + "','" + ObjList[n - 1].PartNumber.ToString() + "','" + ObjList[n - 1].Product_Img.ToString() + "','" + ObjList[n - 1].QtyReceived.ToString() + "','" + ObjList[n - 1].Select_Img.ToString() +"')");
                    n = n - 1;
                }


                _EzBusinessHelper.ExecuteNonQuery(" UPDATE PARTTBL001 SET Nos = " + (pno + 1) + " where CmpyCode='" + po.CmpyCode + "' and Code='" + PurchaseMgmtConstants.MRHeader + "'");


                // _materialMgmtContext.SaveChanges();
                counter = 1;
                    po.ErrorMessage = string.Empty;
                    po.IsSavedFlag = true;
                }
                else
                {
                //var mr = _materialMgmtContext.PMMRH001s.FirstOrDefault(m => m.MRCode.Equals(po.MRCode) && m.CmpyCode.Equals(po.CmpyCode));
                ds = _EzBusinessHelper.ExecuteDataSet("Select * from PMMRH001 where CmpyCode='" + po.CmpyCode + "' and MRCode='" + po.MRCode + "' ");

                MReqHeader pt = new MReqHeader();
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {

                    //if (mr != null)
                    //{
                    // pt.Dates = po.PODate;

                    DateTime dt = Convert.ToDateTime(po.PODate.ToString());

                    dtstr = dt.ToString("yyyy-MM-dd hh:mm:ss tt");

                    pt.Description = po.Description;
                    pt.EmpCode = po.RequesterCode;
                    pt.LocCode = po.LocationCode;
                    pt.ResourceType = po.ResourceType;
                    pt.MRCode = dr["MRCode"].ToString();
                    pt.CmpyCode = dr["CmpyCode"].ToString();
                    _EzBusinessHelper.ExecuteNonQuery("Delete from PMMRD002 where MRCode= '" + pt.MRCode + "' and CmpyCode='" + pt.CmpyCode + "' ");

                    _EzBusinessHelper.ExecuteNonQuery("Delete from PMMRH001 where MRCode= '" + pt.MRCode + "' and CmpyCode='" + pt.CmpyCode + "' ");

                    List<MReqDetail> ObjList = new List<MReqDetail>();

                        ObjList.AddRange(po.PurchaseOrderDetails.Select(m => new MReqDetail
                        {

                            CmpyCode = po.CmpyCode,
                            MRCode = po.MRCode,
                            Description = m.Description,
                            BaseQtyReq = 1,
                            BaseUnitQty = m.Quantity,
                            BOQSno = 1,
                            Specification = m.Specification ?? string.Empty,
                            SNo = counter++,
                            ItemCode = m.ItemCode,
                            Unit = m.Unit,
                            Qty = m.Quantity,
                            CostCode = string.Empty,
                            FileType = string.Empty,
                            ImgDesc = string.Empty,
                            OverBudget = 0,
                            PackageSno = 0,
                            PartNumber = string.Empty,
                            Product_Img = new byte[1],
                            QtyReceived = 0,
                            Select_Img = string.Empty
                        }).ToList());

                    _EzBusinessHelper.ExecuteNonQuery("insert into PMMRH001(MRCode,CmpyCode,ResourceType,Dates,Description,EmpCode,LocCode,ProjectCode,ApprovalYN,MRFrom,Status,DontShowJobInList,GenerateInquiry,IsPopUpCheckedByUser,JobNo,PreparedBy,Priority,RType,WONo) values('" + pt.MRCode + "','" + pt.CmpyCode + "','" + pt.ResourceType + "','" + dtstr + "','" + pt.Description + "','" + pt.EmpCode + "','" + pt.LocCode + "','" + pt.ProjectCode + "','" + pt.ApprovalYN + "','" + pt.MRFrom + "','" + pt.Status + "','" + pt.DontShowJobInList + "','" + pt.GenerateInquiry + "','" + pt.IsPopUpCheckedByUser + "','" + pt.JobNo + "','" + pt.PreparedBy + "','" + pt.Priority + "','" + pt.RType + "','" + pt.WONo + "')");

                     n = ObjList.Count;

                    while (n > 0)
                    {
                        string str = ObjList[n - 1].CmpyCode.ToString();
                        _EzBusinessHelper.ExecuteNonQuery("insert into PMMRD002(CmpyCode,MRCode,Description,BaseQtyReq,BaseUnitQty,BOQSno,Specification,SNo,ItemCode,Unit,Qty,CostCode,FileType,ImgDesc,OverBudget,PackageSno,PartNumber,Product_Img,QtyReceived,Select_Img) values('" + ObjList[n - 1].CmpyCode.ToString() + "','" + ObjList[n - 1].MRCode.ToString() + "','" + ObjList[n - 1].Description.ToString() + "','" + ObjList[n - 1].BaseQtyReq.ToString() + "','" + ObjList[n - 1].BaseUnitQty.ToString() + "','" + ObjList[n - 1].BOQSno.ToString() + "', '" + ObjList[n - 1].Specification.ToString() + "','" + ObjList[n - 1].SNo.ToString() + "','" + ObjList[n - 1].ItemCode.ToString() + "','" + ObjList[n - 1].Unit.ToString() + "','" + ObjList[n - 1].Qty.ToString() + "','" + ObjList[n - 1].CostCode.ToString() + "','" + ObjList[n - 1].FileType.ToString() + "','" + ObjList[n - 1].ImgDesc.ToString() + "','" + ObjList[n - 1].OverBudget.ToString() + "','" + ObjList[n - 1].PackageSno.ToString() + "','" + ObjList[n - 1].PartNumber.ToString() + "','" + ObjList[n - 1].Product_Img.ToString() + "','" + ObjList[n - 1].QtyReceived.ToString() + "','" + ObjList[n - 1].Select_Img.ToString() + "')");
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
