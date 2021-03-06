﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EzBusiness_DL_Interface;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using EzBusiness_ViewModels;
using System.Data;
using System.Transactions;

namespace EzBusiness_DL_Repository
{
    public class EmployeeMgmtRepository : IEmployeeMgmtRepository
    {
        DataSet ds = null;
        DataTable dt = null;
        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();
        public bool DeleteEmployee(string CmpyCode, string EmpCode, string username)
        {
            int unit = _EzBusinessHelper.ExecuteScalar("Select count(*) from MEM001 where CmpyCode='" + CmpyCode + "' and EmpCode='" + EmpCode + "'");
            int k = _EzBusinessHelper.ExecuteScalar("select count(*) from PRDTD002 where EmpCode='" + EmpCode + "' and Cmpycode='" + CmpyCode + "'");

            if (unit != 0 && k==0)
            {
                _EzBusinessHelper.ExecuteNonQuery("update MEM001 set Flag=1 where CmpyCode='" + CmpyCode + "' and EmpCode='" + EmpCode + "'");
                _EzBusinessHelper.ExecuteNonQuery("update EMNM005 set Flag=1 where CmpyCode='" + CmpyCode + "' and EmpCode='" + EmpCode + "'");
                _EzBusinessHelper.ExecuteNonQuery("update EMPDET001 set Flag=1 where CmpyCode='" + CmpyCode + "' and Code='" + EmpCode + "'");
                _EzBusinessHelper.ExecuteNonQuery("DELETE from HRDOCE001  where CmpyCode='" + CmpyCode + "' and EmpCode='" + EmpCode + "'");
                // _EzBusinessHelper.ExecuteNonQuery("update SA001 set Flag=1 where CmpyCode='" + CmpyCode + "' and Salesmancode='" + EmpCode + "'");
                _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Emp  Master", EmpCode, Environment.MachineName);
                return true;
            }
            return false;
        }
        #region DropDownFill
        //public List<EmployeeTypeMaster> GetEmployeeTypeMasterList(string CmpyCode)
        //{
        //    return drop.GetEmployeeTypeMasterList(CmpyCode);
        //}
        //public List<Accounts_Tbl> GetAccList(string CmpyCode, string Typeofacc)
        //{
        //    return drop.GetAccList(CmpyCode, Typeofacc);
        //}
        public List<ComDropTbl> GetBankBranchList(string CmpyCode, string BranchCode, string Prefix)
        {
            //return drop.GetBranchCode(CmpyCode, BranchCode);
            return drop.GetCommonDrop("PRBM002_code as [Code],Bank_branch_name as [CodeName]", "PRBM002", " CmpyCode='" + CmpyCode + "' and PRBM001_code='" + BranchCode + "' and Flag=0 and  (PRBM002_code like '" + Prefix + "%' or Bank_branch_name like '" + Prefix + "%')");
        }
        public List<ComDropTbl> GetBankList(string CmpyCode, string Prefix)
        {
            //return drop.GetBankList(CmpyCode);
            return drop.GetCommonDrop("PRBM001_code as [Code],Bank_name as [CodeName]", "PRBM001", "CmpyCode='" + CmpyCode + "' and Flag=0 and  (PRBM001_code like '" + Prefix + "%' or Bank_name like '" + Prefix + "%')");
        }
        public List<ComDropTbl> GetCommList(string Type, string Prefix)
        {
            //return drop.GetCommList(Type);
            return drop.GetCommonDrop("Code as [Code],Name as [CodeName]", "CMTBL003", "Type='" + Type + "' and  (Code like '" + Prefix + "%' or Name like '" + Prefix + "%')");
        }
        public List<ComDropTbl> GetDepartmentList(string CmpyCode, string divcode, string Brancode, string Prefix)
        {
            // return drop.GetDepCode(CmpyCode, divcode, Brancode);
            return drop.GetCommonDrop("DepartmentCode as [Code],DepartmentName as [CodeName]", "MDEP009", "CmpyCode='" + CmpyCode + "'and BranchCode='" + Brancode + "' and DivisionCode='" + divcode + "' and Flag=0 and  (DepartmentCode like '" + Prefix + "%' or DepartmentName like '" + Prefix + "%')");
        }
        //public List<Discipline> GetDisciplineList(string CmpyCode)
        //{
        //    return drop.GetDisciplineList(CmpyCode);
        //}
        public List<ComDropTbl> GetDivisionList(string CmpyCode, string Prefix)
        {
            // return drop.GetDivCode(CmpyCode);
            return drop.GetCommonDrop("DivisionCode as [Code],DivisionName as [CodeName]", "MDIV011", "CmpyCode='" + CmpyCode + "' and  (DivisionCode like '" + Prefix + "%' or DivisionName like '" + Prefix + "%')");
            //ds = _EzBusinessHelper.ExecuteDataSet("Select DivisionCode,DivisionName from Mdiv08 where CmpyCode='" + CmpyCode + "' ");
            //dt = ds.Tables[0];
            //DataRowCollection drc = dt.Rows;
            //List<Division> ObjList = new List<Division>();
            //foreach (DataRow dr in drc)
            //{
            //    ObjList.Add(new Division()
            //    {
            //        DivisionCode = dr["DivisionCode"].ToString(),
            //        DivisionName = dr["DivisionName"].ToString(),
            //    });

            //}
            //return ObjList;
        }
        public List<ComDropTbl> GetDocList(string CmpyCode, string Prefix)
        {
            //return drop.GetDocList(CmpyCode);
            return drop.GetCommonDrop("HRDOCM001_CODE as [Code],Name as [CodeName]", "HRDOCM001", "CmpyCode='" + CmpyCode + "' and  (HRDOCM001_CODE like '" + Prefix + "%' or Name like '" + Prefix + "%')");
        }

        public List<ComDropTbl> GetLocationList(string CmpyCode, string Prefix)
        {
            //return drop.GetLocationList(CmpyCode);
            return drop.GetCommonDrop("LocCode as [Code],LocName as [CodeName]", "MLOC018", "CmpyCode='" + CmpyCode + "' and  (LocCode like '" + Prefix + "%' or LocName like '" + Prefix + "%')");
        }
        public List<ComDropTbl> GetNationList(string CmpyCode, string Prefix)
        {
            //return drop.GetNationList(CmpyCode);
            return drop.GetCommonDrop("Code as [Code],Name as [CodeName]", "MNAT019", "CmpyCode='" + CmpyCode + "' and  (Code like '" + Prefix + "%' or Name like '" + Prefix + "%')");
        }
        public List<ComDropTbl> GetPaymentNatureList(string CmpyCode, string Prefix)
        {
            //return drop.GetPaymentNatureList(CmpyCode);
            return drop.GetCommonDrop("Code as [Code],Name as [CodeName]", "MPAYNAT020", "CmpyCode='" + CmpyCode + "' and  (Code like '" + Prefix + "%' or Name like '" + Prefix + "%')");
        }
        public List<ComDropTbl> GetProfList(string CmpyCode, string Prefix)
        {
            //return drop.GetProfList(CmpyCode);
            return drop.GetCommonDrop("ProfCode as [Code],ProfName as [CodeName]", "MPROF021", "CmpyCode='" + CmpyCode + "' and Flag=0 and (ProfCode like '" + Prefix + "%' or ProfName like '" + Prefix + "%')");
        }
        public List<ComDropTbl> GetSalution(string Prefix)
        {
            //return drop.GetSalution();
            return drop.GetCommonDrop2("SELECT 'Mr' AS Code,'Mr' AS CodeName UNION SELECT 'Ms' AS Code,'Ms' AS CodeName UNION SELECT 'Mrs' AS Code,'Mrs' AS CodeName Order By Code");

        }
        public List<ComDropTbl> GetShiftMasterList(string CmpyCode, string Prefix)
        {
            // return drop.GetShiftMasterList(CmpyCode);
            return drop.GetCommonDrop("PRSFT001_code as [Code],ShiftName as [CodeName]", "PRSFT001", "CmpyCode='" + CmpyCode + "' and Flag=0 and (PRSFT001_code like '" + Prefix + "%' or ShiftName like '" + Prefix + "%')");
        }
        public List<ComDropTbl> GetStatusMasterList(string CmpyCode, string Prefix)
        {
            //return drop.GetStatusMasterList(CmpyCode);
            return drop.GetCommonDrop("Code as [Code],Name as [CodeName]", "MSTS023", "CmpyCode='" + CmpyCode + "' and Flag=0 and (Code like '" + Prefix + "%' or Name like '" + Prefix + "%')");
        }
        public List<ComDropTbl> GetSubTrademaster(string CmpyCode, string Prefix)
        {
            // return drop.GetSubTrademaster(CmpyCode);
            return drop.GetCommonDrop("Code as [Code],Name as [CodeName]", "MSUBTRD024", "CmpyCode='" + CmpyCode + "' and (Code like '" + Prefix + "%' or Name like '" + Prefix + "%')");
        }
        public List<ComDropTbl> GetTDSSection(string CmpyCode, string Prefix)
        {
            // return drop.GetTDSSection(CmpyCode);
            return drop.GetCommonDrop("Code as [Code],Name as [CodeName]", "MTDSSEC025", "CmpyCode='" + CmpyCode + "' and (Code like '" + Prefix + "%' or Name like '" + Prefix + "%')");
        }
        public List<ComDropTbl> GetTDSTypesList(string CmpyCode, string Prefix)
        {
            //return drop.GetTDSTypesList(CmpyCode);
            return drop.GetCommonDrop("Code as [Code],Name as [CodeName]", "MTTYP026", "CmpyCode='" + CmpyCode + "' and (Code like '" + Prefix + "%' or Name like '" + Prefix + "%')");
        }
        public List<ComDropTbl> GetVisaLocationList(string CmpyCode, string Prefix)
        {
            // return drop.GetVisaLocationList(CmpyCode);
            return drop.GetCommonDrop("Code as [Code],Name as [CodeName]", "VLOC001", "CmpyCode='" + CmpyCode + "' and Flag=0 and (Code like '" + Prefix + "%' or Name like '" + Prefix + "%')");
        }
        public List<ComDropTbl> GetWeekdaysList(string CmpyCode, string Prefix)
        {
            //return drop.GetWeekdaysList(CmpyCode);
            return drop.GetCommonDrop("DayCode as [Code],DayName as [CodeName]", "WKDS001", "DayCode like '" + Prefix + "%' or DayName like '" + Prefix + "%' order by sno");
        }
        public List<ComDropTbl> GetDegreeList(string CmpyCode, string Prefix)
        {
            //return drop.GetDegreeList(CmpyCode);
            return drop.GetCommonDrop("Code as [Code],NAME as [CodeName]", "MEDUL013", "CmpyCode='" + CmpyCode + "'  and (Code like '" + Prefix + "%' or Name like '" + Prefix + "%')");
        }
        public List<ComDropTbl> GetEmpList1(string CmpyCode, string empcode, string Prefix)
        {
            // return drop.GetEmpList1(CmpyCode, empcode);

            return drop.GetCommonDrop("'01'  as [Code], 'SELF'  as [CodeName] UNION ALL SELECT EmpCode as [Code],EmpName as [CodeName]", "MEM001", "CmpyCode='" + CmpyCode + "' and Flag=0 and (EmpCode like '" + Prefix + "%' or EmpName like '" + Prefix + "%')");

        }
        public List<ComDropTbl> GetProjects(string CmpyCode, string Prefix)
        {
            // return drop.GetProjects(CmpyCode);           
            return drop.GetCommonDrop("Code as [Code],NAME as [CodeName]", "MBR005", "CmpyCode='" + CmpyCode + "' and Flag=0 and (Code like '" + Prefix + "%' or Name like '" + Prefix + "%')");
        }
        #endregion

        public List<EducationDetail> GetEducationDetailList(string CmpyCode, string EmpCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from EMPDET001 where CmpyCode='" + CmpyCode + "' and Code='" + EmpCode + "' and Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<EducationDetail> ObjList = new List<EducationDetail>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new EducationDetail()
                {
                    Degree = dr["Degree"].ToString(),
                    DegreeName = dr["DegreeName"].ToString(),
                    Institution = dr["Institution"].ToString(),
                    Location = dr["Location"].ToString(),
                    ObtainedYear = Convert.ToDecimal(dr["ObtainedYear"].ToString()),
                    Specification = dr["Specification"].ToString(),
                    SNo = Convert.ToInt32(dr["SNo"].ToString()),

                });

            }
            return ObjList;
        }
        public List<EmployeeDetail> GetEmployeeDetailList(string CmpyCode, string EmpCode,string DivCode)
        {
            DateTime dte;
            string dtstr4, dtstr9;
            ds = _EzBusinessHelper.ExecuteDataSet("Select doc.DIVISION,div.NAME,doc.CMPYCODE,EXPIRED_DATE,ENTRY_DATE,ALERT_BEFORE,REMARKS,doc.HRDOCM001_CODE from HRDOCE001 doc inner join HRDOCM001 div on doc.HRDOCM001_CODE=div.HRDOCM001_CODE where doc.CMPYCODE='" + CmpyCode + "' and doc.EMPCODE='" + EmpCode + "'and doc.DIVISION='" + DivCode + "'");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<EmployeeDetail> ObjList = new List<EmployeeDetail>();
            foreach (DataRow dr in drc)
            {
                dte = Convert.ToDateTime(dr["EXPIRED_DATE"].ToString());
                dtstr4 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
                dte = Convert.ToDateTime(dr["ENTRY_DATE"].ToString());
                dtstr9 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");


                ObjList.Add(new EmployeeDetail()
                {


                    Description = dr["REMARKS"].ToString(),
                    //Doc = dr["Doc"].ToString(),
                   DivisionCode = dr["DIVISION"].ToString(),
                    DocName = dr["NAME"].ToString(),
                    //  DocNo = dr["DocNo"].ToString(),
                    HRDOCM001_CODE = dr["HRDOCM001_CODE"].ToString(),
                    //  DocStatus = dr["DocStatus"].ToString(),
                    AlertBefore =Convert.ToInt32(dr["ALERT_BEFORE"].ToString()),
                    EndDate = dtstr4,
                   // EndDate =dr["EXPIRED_DATE"].ToString(),
                    // DocumentPath = dr["DocumentPath"].ToString(),
                    //FormType=dr["FormType"].ToString(),
                    //  IssuePlace = dr["IssuePlace"].ToString(),
                    //IssueState=Convert.ToInt16(dr["IssueState"].ToString()),
                    //Preview = dr["Preview"].ToString(),
                    // Sno = Convert.ToInt16(dr["Sno"].ToString()),
                    StartDate = dtstr9,
                });

            }
            return ObjList;
        }
        public List<EmployeeExp> GetEmployeeExpList(string CmpyCode, string EmpCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from EMEXP003 where CmpyCode='" + CmpyCode + "' and EmpCode='" + EmpCode + "'");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<EmployeeExp> ObjList = new List<EmployeeExp>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new EmployeeExp()
                {
                    CAddress = dr["CAddress"].ToString(),
                    CName = dr["CName"].ToString(),
                    CTC = Convert.ToDecimal(dr["CTC"].ToString()),
                    Designation = dr["Designation"].ToString(),
                    FromDate = Convert.ToDateTime(dr["FromDate"].ToString()),
                    ReasonForLeaving = dr["ReasonForLeaving"].ToString(),
                    SNo = Convert.ToInt32(dr["SNo"].ToString()),
                    ToDate = Convert.ToDateTime(dr["ToDate"].ToString()),
                    Years = Convert.ToDecimal(dr["Years"].ToString()),

                });

            }
            return ObjList;
        }
        public List<Employee> GetEmployeeList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select b.Empname as ReportingEmp,a.* ,c.Name as [VisaLocationName], d.LocName  as [Locname]  from MEM001 a inner join  MEM001 b on a.Cmpycode=b.Cmpycode and a.ReportingEmp = b.EmpCode inner join VLOC001 c on a.Cmpycode=c.CmpyCode and a.Flag=0 and a.VisaLocation=c.Code inner join MLOC018 d on a.Cmpycode=d.Cmpycode and  a.LocCode=d.LocCode where a.CmpyCode='"+CmpyCode +"' and a.Flag=0  ");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Employee> ObjList = new List<Employee>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new Employee()
                {
                    DepartmentCode = dr["DepartmentCode"].ToString(),
                    EmpCode = dr["EmpCode"].ToString(),
                    Empname = dr["Empname"].ToString(),
                    EmpType = dr["EmpType"].ToString(),
                    DOB =Convert.ToDateTime(dr["DOB"].ToString()),
                    LocCode = dr["Locname"].ToString(),
                    VisaLocation = dr["VisaLocationName"].ToString(),
                    ContactNo = dr["ContactNo"].ToString(),
                    EMail = dr["EMail"].ToString(),
                    Nationality = dr["Nationality"].ToString(),
                    DivisionCode = dr["DivisionCode"].ToString(),
                    ReportingEmp = dr["ReportingEmp"].ToString()
                });

            }
            return ObjList;
        }
        public Employee_VM GetEmployeeMasterDetailsEdit(string CmpyCode, string EmpCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from MEM001 where CmpyCode='" + CmpyCode + "' and EmpCode='" + EmpCode + "' and Flag=0");

            dt = ds.Tables[0];
            Employee_VM EmpMs = new Employee_VM();


            foreach (DataRow dr in dt.Rows)
            {
                EmpMs.Cmpycode = dr["Cmpycode"].ToString();
                EmpMs.EmpCode = dr["EmpCode"].ToString();
                EmpMs.Empname = dr["Empname"].ToString();
                EmpMs.EmpType = dr["EmpType"].ToString();
                EmpMs.DivisionCode = dr["DivisionCode"].ToString();
                EmpMs.ProfCode = dr["ProfCode"].ToString();
                EmpMs.JoiningDate = Convert.ToDateTime(dr["JoiningDate"].ToString());
                EmpMs.Sex = dr["Sex"].ToString();
                //  EmpMs.SalType = dr["SalType"].ToString();
                EmpMs.Address = dr["Address"].ToString();
                EmpMs.FirstSetDate = Convert.ToDateTime(dr["FirstSetDate"].ToString());
                EmpMs.LeaveStatus = dr["LeaveStatus"].ToString();
                EmpMs.PhysicallyDisabledYN = dr["PhysicallyDisabledYN"].ToString();
                EmpMs.AbscondingYN = dr["AbscondingYN"].ToString();
                EmpMs.SupervisorYN = dr["SupervisorYN"].ToString();


                //if (dr["LeaveStatus"].ToString() == "Y")
                //{
                //    EmpMs.LeaveStatus = "true";
                //}
                //else{
                //    EmpMs.LeaveStatus = "false";
                //}


                EmpMs.WorkingStatus = dr["WorkingStatus"].ToString();
                //EmpMs.LastRetDate = Convert.ToDateTime(dr["LastRetDate"].ToString());

                EmpMs.VisaLocation = dr["VisaLocation"].ToString();
                EmpMs.Nationality = dr["Nationality"].ToString();

                EmpMs.DOB = Convert.ToDateTime(dr["DOB"].ToString());

                EmpMs.VisaStatus = dr["VisaStatus"].ToString();
                EmpMs.WorkLocation = dr["WorkLocation"].ToString();
                EmpMs.AddressLocal = dr["AddressLocal"].ToString();

                EmpMs.DepartmentCode = dr["DepartmentCode"].ToString();
                EmpMs.ProjectCode = dr["ProjectCode"].ToString();
                EmpMs.BankCode = dr["BankCode"].ToString();
                EmpMs.BankAccNo = dr["BankAccNo"].ToString();
                EmpMs.AccNo = dr["AccNo"].ToString();


                if (dr["ReportingEmp"].ToString() == dr["EmpCode"].ToString())
                {
                    EmpMs.ReportingEmp = "01";
                }
                else {
                    EmpMs.ReportingEmp = dr["ReportingEmp"].ToString();
                }
                


                EmpMs.MaritalStatus = dr["MaritalStatus"].ToString();
                EmpMs.BloodGroup = dr["BloodGroup"].ToString();
                //if (dr["PhysicallyDisabledYN"].ToString() == "Y")
                //{
                //    EmpMs.PhysicallyDisabledYN = "true";
                //}
                //else
                //{
                //    EmpMs.PhysicallyDisabledYN = "false";
                //}

                EmpMs.PhysicallyDisabled = dr["PhysicallyDisabled"].ToString();

                EmpMs.Salutaion = dr["Salutaion"].ToString();

                EmpMs.ContactNo = dr["ContactNo"].ToString();
                EmpMs.EMail = dr["EMail"].ToString();
                //  EmpMs.BranchCode = dr["BranchCode"].ToString();

                EmpMs.wagesby = dr["wagesby"].ToString();

                EmpMs.Week_off1 = dr["Week_off1"].ToString();
                EmpMs.Week_off2 = dr["Week_off2"].ToString();


                if (String.IsNullOrEmpty(dr["ContactDate"].ToString()))
                {
                    EmpMs.ContactDate = System.DateTime.Today;
                }
                else
                {
                    EmpMs.ContactDate = Convert.ToDateTime(dr["ContactDate"].ToString());
                }
                //EmpMs.AbscondingYN = dr["AbscondingYN"].ToString();

                //if (dr["AbscondingYN"].ToString() == "Y")
                //{
                //    EmpMs.AbscondingYN = "true";
                //}
                //else
                //{
                //    EmpMs.AbscondingYN = "false";
                //}

                if (String.IsNullOrEmpty(dr["AbscondingDate"].ToString()))
                {
                    EmpMs.AbscondingDate = System.DateTime.Today;
                }
                else
                {
                    EmpMs.AbscondingDate = Convert.ToDateTime(dr["AbscondingDate"].ToString());
                }

                EmpMs.TicketType = dr["TicketType"].ToString();
                EmpMs.TicketNo = dr["TicketNo"].ToString();
                EmpMs.Contract = dr["Contract"].ToString();
                // EmpMs.SupervisorYN = dr["SupervisorYN"].ToString();

                //if (dr["SupervisorYN"].ToString() == "Y")
                //{
                //    EmpMs.SupervisorYN = "true";
                //}
                //else
                //{
                //    EmpMs.SupervisorYN = "false";
                //}

                EmpMs.LanguageKnown = dr["LanguageKnown"].ToString();
                if (String.IsNullOrEmpty(dr["LeaveSettlementDate"].ToString()))
                {
                    EmpMs.LeaveSettlementDate = System.DateTime.Today;
                }
                else
                {
                    EmpMs.LeaveSettlementDate = Convert.ToDateTime(dr["LeaveSettlementDate"].ToString());
                }



                //EmpMs.PANNumber = dr["PANNumber"].ToString();



                EmpMs.GroupCode = dr["GroupCode"].ToString();
                EmpMs.BankBranchCode = dr["BankBranchCode"].ToString();
                EmpMs.LocCode = dr["LocCode"].ToString();
                EmpMs.DepartmentCode = dr["DepartmentCode"].ToString();
                EmpMs.BranchCode = dr["BranchCode"].ToString();
                EmpMs.photpath = dr["photpath"].ToString();
                EmpMs.Country = dr["country"].ToString();

            }
            return EmpMs;
        }
        public List<EmployeeNominee> GetEmployeeNomineeList(string CmpyCode, string EmpCode)
        {
            DateTime dte;
            string dtstr4;
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from EMNM005 where CmpyCode='" + CmpyCode + "' and EmpCode='" + EmpCode + "' and Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<EmployeeNominee> ObjList = new List<EmployeeNominee>();
            foreach (DataRow dr in drc)
            {
                dte = Convert.ToDateTime(dr["NomineeDOB"].ToString());
                dtstr4 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");

                ObjList.Add(new EmployeeNominee()
                {
                    NomineeAddress = dr["NomineeAddress"].ToString(),
                    NomineeDOB = dtstr4,
                    NomineeName = dr["NomineeName"].ToString(),
                    NomineeRelation = dr["NomineeRelation"].ToString(),
                    SNo = Convert.ToInt32(dr["SNo"].ToString()),
                });

            }
            return ObjList;
        }

        public Employee_VM SavePurchaseOrder(Employee_VM EmpMs)
        {
            int n;
            string dtstr1, dtstr2, dtstr3, dtstr4, dtstr5, dtstr6, dtstr7, dtstr8, dtstr9, dtstr10, dtstr11, dtstr12, dtstr13, dtstr14 = null;
            DateTime dte;
            //try
            //{
            var counter = 1;
            if (!EmpMs.IsEditMode)
            {

                try
                {


                    Employee Emp = new Employee();
                    int pno = _EzBusinessHelper.ExecuteScalar("Select Nos from PARTTBL001 where CmpyCode='" + EmpMs.Cmpycode + "' and Code='" + PurchaseMgmtConstants.EmpHeader + "' ");
                    #region Employee_VM1
                   
                    dte = Convert.ToDateTime(EmpMs.JoiningDate.ToString());
                    dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");                   
                    //dte = Convert.ToDateTime(EmpMs.LastRetDate.ToString());
                    //dtstr3 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
                    dte = Convert.ToDateTime(EmpMs.DOB.ToString());
                    dtstr5 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
                    dte = Convert.ToDateTime(EmpMs.ContactDate.ToString());
                    dtstr6 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
                    dte = Convert.ToDateTime(EmpMs.AbscondingDate.ToString());
                    dtstr7 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
                  
                    Emp.EmpCode = EmpMs.EmpCode;
                    Emp.Cmpycode = EmpMs.Cmpycode;
                    Emp.Empname = EmpMs.Empname;
                    Emp.EmpType = EmpMs.EmpType;
                    Emp.DivisionCode = EmpMs.DivisionCode;
                    Emp.ProfCode = EmpMs.ProfCode;                   
                    Emp.Sex = EmpMs.Sex;
                    Emp.Address = EmpMs.Address;                                 
                    Emp.LeaveStatus = EmpMs.LeaveStatus;
                    Emp.WorkingStatus = EmpMs.WorkingStatus;                              
                    Emp.VisaLocation = EmpMs.VisaLocation;
                    Emp.Nationality = EmpMs.Nationality;
                    Emp.VisaStatus = EmpMs.VisaStatus;
                    Emp.WorkLocation = EmpMs.WorkLocation;
                    Emp.AddressLocal = EmpMs.AddressLocal;
                    Emp.DepartmentCode = EmpMs.DepartmentCode;
                    Emp.ProjectCode = EmpMs.ProjectCode;
                    Emp.BankCode = EmpMs.BankCode;
                    Emp.BankAccNo = EmpMs.BankAccNo;
                    Emp.AccNo = EmpMs.AccNo;   
                    if(EmpMs.ReportingEmp != "01")
                    {
                        Emp.ReportingEmp = EmpMs.ReportingEmp;
                    }
                    else
                    {
                        Emp.ReportingEmp = EmpMs.EmpCode;
                    }                          
                    
                    Emp.MaritalStatus = EmpMs.MaritalStatus;
                    Emp.BloodGroup = EmpMs.BloodGroup;
                    Emp.PhysicallyDisabledYN = EmpMs.PhysicallyDisabledYN;
                    Emp.PhysicallyDisabled = EmpMs.PhysicallyDisabled;
                    Emp.Salutaion = EmpMs.Salutaion;
                    Emp.ContactNo = EmpMs.ContactNo;
                    Emp.EMail = EmpMs.EMail;
                    Emp.BranchCode = EmpMs.BranchCode;                   
                    Emp.AbscondingYN = EmpMs.AbscondingYN;                            
                    Emp.TicketType = EmpMs.TicketType;
                    Emp.TicketNo = EmpMs.TicketNo;
                    Emp.Contract = EmpMs.Contract;
                    Emp.SupervisorYN = EmpMs.SupervisorYN;
                    Emp.LanguageKnown = EmpMs.LanguageKnown;                                                                                                           
                    Emp.GroupCode = EmpMs.GroupCode;                   
                    Emp.LocCode = EmpMs.LocCode;
                    Emp.photpath = EmpMs.photpath;
                    Emp.Week_off1 = EmpMs.Week_off1;
                    Emp.Week_off2 = EmpMs.Week_off2;
                    Emp.wagesby = EmpMs.wagesby;
                    Emp.BankBranchCode = EmpMs.BankBranchCode;
                    #endregion                   
                    #region ObjectList
                    List<EmployeeDetail> ObjList = new List<EmployeeDetail>();
                    if (EmpMs.EmployeeDetailnews != null)
                    {
                        ObjList.AddRange(EmpMs.EmployeeDetailnews.Select(m => new EmployeeDetail
                        {
                            Cmpycode = EmpMs.Cmpycode,
                            EmpCode = Emp.EmpCode,
                            DivisionCode = Emp.DivisionCode,
                            HRDOCM001_CODE = m.DocCode,
                            DocName = m.DocName,
                            DocNo = m.DocNo,
                            StartDate = m.StartDate.ToString(),
                            EndDate = m.EndDate.ToString(),
                            Description = m.Description,
                            Preview = m.Preview,                           
                            Sno = counter++,
                            IssuePlace = m.IssuePlace,
                            DocStatus = m.DocStatus,
                            DocumentPath = m.DocumentPath,
                            AlertBefore=m.AlertBefore
                        }).ToList());
                    }
                    #endregion

                    #region ObjectList1

                    List<EducationDetail> ObjList1 = new List<EducationDetail>();
                    if (EmpMs.EducationDetailnews != null)
                    {
                        ObjList1.AddRange(EmpMs.EducationDetailnews.Select(m => new EducationDetail
                        {
                            Cmpycode = EmpMs.Cmpycode,
                            code = Emp.EmpCode,
                            SNo = counter++,
                            Institution = m.Institution,
                            Location = m.Location,
                            Degree = m.Degree,
                            ObtainedYear = m.ObtainedYear,
                            Specification = m.Specification,
                            DegreeName = m.DegreeName,

                        }).ToList());
                    }
                    #endregion

                    #region OjectList2

                    #endregion

                    #region ObjectList3
                    List<EmployeeNominee> ObjList3 = new List<EmployeeNominee>();
                    if (EmpMs.EmployeeNomineenews != null)
                    {
                        ObjList3.AddRange(EmpMs.EmployeeNomineenews.Select(m => new EmployeeNominee
                        {
                            CmpyCode = EmpMs.Cmpycode,
                            EmpCode = Emp.EmpCode,
                            SNo = counter++,
                            NomineeName = m.NomineeName,
                            NomineeAddress = m.NomineeAddress,
                            NomineeRelation = m.NomineeRelation,
                            NomineeDOB = m.NomineeDOB,


                        }).ToList());
                    }
                    #endregion

                    #region ObecjtList4

                    #endregion
                    using (TransactionScope scope = new TransactionScope())
                    {
                        StringBuilder sb = new StringBuilder();

                        #region Employee
                        sb.Append("(Cmpycode,");
                        sb.Append("EmpCode,");
                        sb.Append("Empname,");
                        sb.Append("EmpType,");
                        sb.Append("DivisionCode,");
                        sb.Append("ProfCode,");
                        sb.Append("JoiningDate,");
                        sb.Append("Sex,");
                        sb.Append("Address,");                       
                        sb.Append("LeaveStatus,");
                        sb.Append("WorkingStatus,");
                        //sb.Append("LastRetDate,");
                        sb.Append("VisaLocation,");
                        sb.Append("Nationality,");
                        sb.Append("DOB,");
                        sb.Append("VisaStatus,");
                        sb.Append("WorkLocation,");
                        sb.Append("AddressLocal,");
                        sb.Append("DepartmentCode,");
                        sb.Append("ProjectCode,");
                        sb.Append("BankCode,");
                        sb.Append("BankAccNo,");
                        sb.Append("AccNo,");
                        sb.Append("ReportingEmp,");
                        sb.Append("MaritalStatus,");
                        sb.Append("BloodGroup,");
                        sb.Append("PhysicallyDisabledYN,");
                        sb.Append("PhysicallyDisabled,");
                        sb.Append("Salutaion,");
                        sb.Append("ContactNo,");
                        sb.Append("EMail,");
                        sb.Append("BankBranchCode,");
                        sb.Append("ContactDate,");
                        sb.Append("AbscondingYN,");
                        sb.Append("AbscondingDate,");
                        sb.Append("TicketType,");
                        sb.Append("TicketNo,");
                        sb.Append("Contract,");
                        sb.Append("SupervisorYN,");
                        sb.Append("LanguageKnown,");                     
                        sb.Append("GroupCode,");
                        sb.Append("LocCode,");
                        sb.Append("photpath,");
                        sb.Append("Week_off1,");
                        sb.Append("Week_off2,");
                        sb.Append("wagesby,");
                        sb.Append("country,");
                        sb.Append("BranchCode)");

                        sb.Append(" values(");
                        //'---
                        sb.Append("'" + Emp.Cmpycode + "',");
                        sb.Append("'" + Emp.EmpCode + "',");
                        sb.Append("'" + Emp.Empname + "',");
                        sb.Append("'" + Emp.EmpType + "',");
                        sb.Append("'" + Emp.DivisionCode + "',");
                        sb.Append("'" + Emp.ProfCode + "',");
                        sb.Append("'" + dtstr1 + "',");
                        sb.Append("'" + Emp.Sex + "',");
                        sb.Append("'" + Emp.Address + "',");                      
                        sb.Append("'" + Emp.LeaveStatus + "',");
                        sb.Append("'" + Emp.WorkingStatus + "',");
                        //sb.Append("'" + dtstr3 + "',");
                        sb.Append("'" + Emp.VisaLocation + "',");
                        sb.Append("'" + Emp.Nationality + "',");
                        sb.Append("'" + dtstr5 + "',");
                        sb.Append("'" + Emp.VisaStatus + "',");
                        sb.Append("'" + Emp.WorkLocation + "',");
                        sb.Append("'" + Emp.AddressLocal + "',");
                        sb.Append("'" + Emp.DepartmentCode + "',");
                        sb.Append("'" + Emp.ProjectCode + "',");
                        sb.Append("'" + Emp.BankCode + "',");
                        sb.Append("'" + Emp.BankAccNo + "',");
                        sb.Append("'" + Emp.AccNo + "',");
                        sb.Append("'" + Emp.ReportingEmp + "',");
                        sb.Append("'" + Emp.MaritalStatus + "',");
                        sb.Append("'" + Emp.BloodGroup + "',");
                        sb.Append("'" + Emp.PhysicallyDisabledYN + "',");
                        sb.Append("'" + Emp.PhysicallyDisabled + "',");
                        sb.Append("'" + Emp.Salutaion + "',");
                        sb.Append("'" + Emp.ContactNo + "',");
                        sb.Append("'" + Emp.EMail + "',");
                        sb.Append("'" + Emp.BankBranchCode + "',");
                        sb.Append("'" + dtstr6 + "',");
                        sb.Append("'" + Emp.AbscondingYN + "',");
                        sb.Append("'" + dtstr7 + "',");
                        sb.Append("'" + Emp.TicketType + "',");
                        sb.Append("'" + Emp.TicketNo + "',");
                        sb.Append("'" + Emp.Contract + "',");
                        sb.Append("'" + Emp.SupervisorYN + "',");
                        sb.Append("'" + Emp.LanguageKnown + "',");                       
                        sb.Append("'" + Emp.GroupCode + "',");
                        sb.Append("'" + Emp.LocCode + "',");
                        sb.Append("'" + Emp.photpath + "',");

                        sb.Append("'" + Emp.Week_off1 + "',");
                        sb.Append("'" + Emp.Week_off2 + "',");
                        sb.Append("'" + Emp.wagesby + "',");
                        sb.Append("'" + Emp.Country + "',");

                        sb.Append("'" + Emp.BranchCode + "')");


                        bool resul = _EzBusinessHelper.ExecuteNonQuery1("insert into MEM001" + sb + "");

                        #endregion
                        if (resul == true)
                        {
                            _EzBusinessHelper.ExecuteNonQuery(" UPDATE PARTTBL001 SET Nos = " + (pno + 1) + " where CmpyCode='" + EmpMs.Cmpycode + "' and Code='" + PurchaseMgmtConstants.EmpHeader + "'");

                            #region EmployeeDetail
                            n = ObjList.Count;

                            while (n > 0)
                            {

                                dte = Convert.ToDateTime(ObjList[n - 1].StartDate.ToString());
                                dtstr4 = dte.ToString("yyyy-MM-dd hh:mm:ss");
                                dte = Convert.ToDateTime(ObjList[n - 1].EndDate.ToString());
                                dtstr9 = dte.ToString("yyyy-MM-dd hh:mm:ss");

                                sb.Clear();

                                sb.Append("(Cmpycode,");
                                sb.Append("EmpCode,");
                                sb.Append("DIVISION,");
                                sb.Append("HRDOCM001_CODE,");
                                //sb.Append("DocName,");
                                //sb.Append("DocNo,");
                                sb.Append("ENTRY_DATE,");
                                sb.Append("EXPIRED_DATE,");
                                sb.Append("ALERT_BEFORE,");
                                sb.Append("REMARKS)");
                                //sb.Append("Sno,");
                                //sb.Append("IssuePlace,");
                                //sb.Append("DocStatus,");
                                //sb.Append("DocumentPath)");

                                sb.Append(" values(");

                                sb.Append("'" + ObjList[n - 1].Cmpycode + "',");
                                sb.Append("'" + ObjList[n - 1].EmpCode + "',");
                                sb.Append("'" + ObjList[n - 1].DivisionCode + "',");
                                sb.Append("'" + ObjList[n - 1].HRDOCM001_CODE + "',");
                                //sb.Append("'" + ObjList[n - 1].DocName + "',");
                                //sb.Append("'" + ObjList[n - 1].DocNo + "',");
                                sb.Append("'" + dtstr4 + "',");
                                sb.Append("'" + dtstr9 + "',");
                                sb.Append("'" + ObjList[n - 1].AlertBefore + "',");
                                sb.Append("'" + ObjList[n - 1].Description + "')");
                                //sb.Append("'" + ObjList[n - 1].Sno + "',");
                                //sb.Append("'" + ObjList[n - 1].IssuePlace + "',");
                                //sb.Append("'" + ObjList[n - 1].DocStatus + "',");
                                //sb.Append("'" + ObjList[n - 1].DocumentPath + "')");


                                _EzBusinessHelper.ExecuteNonQuery("insert into HRDOCE001" + sb + " ");
                                n = n - 1;
                            }

                            #endregion

                            #region EmployeeEducation
                            n = ObjList1.Count;

                            while (n > 0)
                            {

                                dte = Convert.ToDateTime(ObjList3[n - 1].NomineeDOB.ToString());
                                dtstr10 = dte.ToString("yyyy-MM-dd hh:mm:ss");
                                sb.Clear();

                                sb.Append("(Cmpycode, ");
                                sb.Append("code,");
                                sb.Append("SNo,");
                                sb.Append("Degree,");
                                sb.Append("DegreeName,");
                                sb.Append("Institution,");
                                sb.Append("ObtainedYear,");
                                sb.Append("Specification,");
                                sb.Append("Location)");
                                sb.Append(" values(");
                                sb.Append("'" + ObjList1[n - 1].Cmpycode + "' ,");
                                sb.Append("'" + ObjList1[n - 1].code + "' ,");
                                sb.Append("'" + ObjList1[n - 1].SNo + "' ,");
                                sb.Append("'" + ObjList1[n - 1].Degree + "' ,");
                                sb.Append("'" + ObjList1[n - 1].DegreeName + "' ,");
                                sb.Append("'" + ObjList1[n - 1].Institution + "' ,");
                                sb.Append("'" + ObjList1[n - 1].ObtainedYear + "' ,");
                                sb.Append("'" + ObjList1[n - 1].Specification + "' ,");
                                sb.Append("'" + ObjList1[n - 1].Location + "' )");
                                _EzBusinessHelper.ExecuteNonQuery("insert into EMPDET001" + sb + " ");
                                n = n - 1;
                            }
                            #endregion`

                          

                            #region EmployeeNominee
                            n = ObjList3.Count;

                            while (n > 0)
                            {
                                dte = Convert.ToDateTime(ObjList3[n - 1].NomineeDOB.ToString());
                                dtstr10 = dte.ToString("yyyy-MM-dd hh:mm:ss");
                                sb.Clear();

                                sb.Append("(CmpyCode,");
                                sb.Append("EmpCode,");
                                sb.Append("SNo,");
                                sb.Append("NomineeName,");
                                sb.Append("NomineeAddress,");
                                sb.Append("NomineeRelation,");
                                sb.Append("NomineeDOB)");


                                sb.Append(" values(");

                                sb.Append("'" + ObjList3[n - 1].CmpyCode + "' ,");
                                sb.Append("'" + ObjList3[n - 1].EmpCode + "' ,");
                                sb.Append("'" + ObjList3[n - 1].SNo + "' ,");
                                sb.Append("'" + ObjList3[n - 1].NomineeName + "' ,");
                                sb.Append("'" + ObjList3[n - 1].NomineeAddress + "' ,");
                                sb.Append("'" + ObjList3[n - 1].NomineeRelation + "' ,");
                                sb.Append("'" + dtstr10 + "' )");


                                _EzBusinessHelper.ExecuteNonQuery("insert into EMNM005" + sb + " ");

                                n = n - 1;
                            }

                            #endregion
                           // _materialMgmtContext.SaveChanges();
                            counter = 1;
                            EmpMs.ErrorMessage = string.Empty;
                            EmpMs.IsSavedFlag = true;
                        }
                        scope.Complete();
                    }
                }
                catch (Exception)
                {
                    EmpMs.ErrorMessage = "Error occur";
                    EmpMs.IsSavedFlag = false;
                }
            }
            else
            {
                //var mr = _materialMgmtContext.MReqHeaders.FirstOrDefault(m => m.MRCode.Equals(po.MRCode) && m.CmpyCode.Equals(po.CmpyCode));
                try
                {
                    ds = _EzBusinessHelper.ExecuteDataSet("Select * from MEM001 where CmpyCode='" + EmpMs.Cmpycode + "' and EmpCode='" + EmpMs.EmpCode + "'");
                    using (TransactionScope scope1 = new TransactionScope())
                    {
                        Employee Emp = new Employee();
                        dt = ds.Tables[0];
                        foreach (DataRow dr in dt.Rows)
                        {

                            #region Employee_VM

                            dte = EmpMs.JoiningDate.Value;
                            dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
                           
                            //dte = EmpMs.LastRetDate.Value;
                            //dtstr3 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");

                            dte = EmpMs.DOB.Value;
                            dtstr5 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
                            dte = EmpMs.ContactDate.Value;
                            dtstr6 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
                            dte = EmpMs.AbscondingDate.Value;
                            dtstr7 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
                           


                            Emp.EmpCode = EmpMs.EmpCode;
                            Emp.Cmpycode = EmpMs.Cmpycode;
                            Emp.Empname = EmpMs.Empname;
                            Emp.EmpType = EmpMs.EmpType;
                            Emp.DivisionCode = EmpMs.DivisionCode;
                            Emp.ProfCode = EmpMs.ProfCode;                         
                            Emp.Sex = EmpMs.Sex;
                            Emp.Address = EmpMs.Address;                         
                            Emp.LeaveStatus = EmpMs.LeaveStatus;
                            Emp.WorkingStatus = EmpMs.WorkingStatus;                         
                            Emp.VisaLocation = EmpMs.VisaLocation;
                            Emp.Nationality = EmpMs.Nationality;
                            Emp.VisaStatus = EmpMs.VisaStatus;
                            Emp.WorkLocation = EmpMs.WorkLocation;
                            Emp.AddressLocal = EmpMs.AddressLocal;
                            Emp.DepartmentCode = EmpMs.DepartmentCode;
                            Emp.ProjectCode = EmpMs.ProjectCode;
                            Emp.BankCode = EmpMs.BankCode;
                            Emp.BankAccNo = EmpMs.BankAccNo;
                            Emp.AccNo = EmpMs.AccNo;
                            //  Emp.ReportingEmp = EmpMs.ReportingEmp;
                            if (EmpMs.ReportingEmp != "01")
                            {
                                Emp.ReportingEmp = EmpMs.ReportingEmp;
                            }
                            else
                            {
                                Emp.ReportingEmp = EmpMs.EmpCode;
                            }
                            Emp.MaritalStatus = EmpMs.MaritalStatus;
                            Emp.BloodGroup = EmpMs.BloodGroup;
                            Emp.PhysicallyDisabledYN = EmpMs.PhysicallyDisabledYN;
                            Emp.PhysicallyDisabled = EmpMs.PhysicallyDisabled;
                            Emp.Salutaion = EmpMs.Salutaion;
                            Emp.ContactNo = EmpMs.ContactNo;
                            Emp.EMail = EmpMs.EMail;
                            Emp.BranchCode = EmpMs.BranchCode;
                            Emp.AbscondingYN = EmpMs.AbscondingYN;
                            Emp.TicketType = EmpMs.TicketType;
                            Emp.TicketNo = EmpMs.TicketNo;
                            Emp.Contract = EmpMs.Contract;
                            Emp.SupervisorYN = EmpMs.SupervisorYN;
                            Emp.LanguageKnown = EmpMs.LanguageKnown;
                            Emp.BankBranchCode = EmpMs.BankBranchCode;

                            Emp.GroupCode = EmpMs.GroupCode;

                            Emp.LocCode = EmpMs.LocCode;
                            Emp.photpath = EmpMs.photpath;
                            Emp.wagesby = EmpMs.wagesby;

                            Emp.Week_off1 = EmpMs.Week_off1;
                            Emp.Week_off2 = EmpMs.Week_off2;

                            Emp.Country = EmpMs.Country;
                            #endregion

                            _EzBusinessHelper.ExecuteNonQuery("delete from EMNM005 where CmpyCode='" + EmpMs.Cmpycode + "' and EmpCode='" + EmpMs.EmpCode + "'");
                            _EzBusinessHelper.ExecuteNonQuery("delete from EMPDET001 where CmpyCode='" + EmpMs.Cmpycode + "' and Code='" + EmpMs.EmpCode + "'");
                            _EzBusinessHelper.ExecuteNonQuery("delete from HRDOCE001 where CmpyCode='" + EmpMs.Cmpycode + "' and EmpCode='" + EmpMs.EmpCode + "' and DIVISION='" + EmpMs.DivisionCode + "'");
                          
                            #region ObjectList
                            List<EmployeeDetail> ObjList = new List<EmployeeDetail>();
                            if (EmpMs.EmployeeDetailnews != null)
                            {

                                ObjList.AddRange(EmpMs.EmployeeDetailnews.Select(m => new EmployeeDetail
                                {
                                    Cmpycode = EmpMs.Cmpycode,
                                    EmpCode = Emp.EmpCode,
                                    DivisionCode = Emp.DivisionCode,
                                    HRDOCM001_CODE = m.DocCode,
                                    DocName = m.DocName,
                                    //DocNo = m.DocNo,
                                    StartDate = m.StartDate.ToString(),
                                    EndDate = m.EndDate.ToString(),
                                    Description = m.Description,
                                    Preview = m.Preview,                                   
                                    Sno = counter++,
                                    //IssuePlace = m.IssuePlace,
                                    //DocStatus = m.DocStatus,
                                    AlertBefore=m.AlertBefore,
                                    //DocumentPath = m.DocumentPath
                                   

                                }).ToList());
                            }



                            #endregion

                            #region ObjectList1
                            List<EducationDetail> ObjList1 = new List<EducationDetail>();
                            if (EmpMs.EducationDetailnews != null)
                            {

                                ObjList1.AddRange(EmpMs.EducationDetailnews.Select(m => new EducationDetail
                                {
                                    Cmpycode = EmpMs.Cmpycode,
                                    code = Emp.EmpCode,
                                    SNo = counter++,
                                    Institution = m.Institution,
                                    Location = m.Location,
                                    Degree = m.Degree,
                                    ObtainedYear = m.ObtainedYear,
                                    Specification = m.Specification,
                                    DegreeName = m.DegreeName,

                                }).ToList());
                            }
                            #endregion

                            #region OjectList2
                            
                            #endregion

                            #region ObjectList3
                            List<EmployeeNominee> ObjList3 = new List<EmployeeNominee>();
                            if (EmpMs.EmployeeNomineenews != null)
                            {

                                ObjList3.AddRange(EmpMs.EmployeeNomineenews.Select(m => new EmployeeNominee
                                {
                                    CmpyCode = EmpMs.Cmpycode,
                                    EmpCode = Emp.EmpCode,
                                    SNo = counter++,
                                    NomineeName = m.NomineeName,
                                    NomineeAddress = m.NomineeAddress,
                                    NomineeRelation = m.NomineeRelation,
                                    NomineeDOB = m.NomineeDOB,


                                }).ToList());
                            }
                            #endregion

                            #region ObecjtList4
                            //List<EmployeeExp> ObjList4 = new List<EmployeeExp>();
                            //if (EmpMs.EmployeeExpnew != null)
                            //{

                            //    ObjList4.AddRange(EmpMs.EmployeeExpnew.Select(m => new EmployeeExp
                            //    {
                            //        CAddress = m.CAddress,
                            //        CmpyCode = EmpMs.Cmpycode,
                            //        CName = m.CName,
                            //        CTC = m.CTC,
                            //        Designation = m.Designation,
                            //        EmpCode = Emp.EmpCode,
                            //        FromDate = m.FromDate,
                            //        SNo = counter++,
                            //        ReasonForLeaving = m.ReasonForLeaving,
                            //        ToDate = m.ToDate,
                            //        Years = m.Years,
                            //    }).ToList());
                            //}
                            #endregion

                            StringBuilder sb = new StringBuilder();

                            #region Employee
                            
                            sb.Append("Empname='" + Emp.Empname + "',");
                            sb.Append("EmpType='" + Emp.EmpType + "',");
                            sb.Append("DivisionCode='" + Emp.DivisionCode + "',");
                            sb.Append("ProfCode='" + Emp.ProfCode + "',");
                            sb.Append("JoiningDate='" + dtstr1 + "',");
                            sb.Append("Sex='" + Emp.Sex + "',");
                            sb.Append("Address='" + Emp.Address + "',");
                            // sb.Append("'" + dtstr2 + "',");
                            sb.Append("LeaveStatus='" + Emp.LeaveStatus + "',");
                            sb.Append("WorkingStatus='" + Emp.WorkingStatus + "',");
                            //sb.Append("LastRetDate='" + dtstr3 + "',");
                            sb.Append("VisaLocation='" + Emp.VisaLocation + "',");
                            sb.Append("Nationality='" + Emp.Nationality + "',");
                            sb.Append("DOB='" + dtstr5 + "',");
                            sb.Append("VisaStatus='" + Emp.VisaStatus + "',");
                            sb.Append("WorkLocation='" + Emp.WorkLocation + "',");
                            sb.Append("AddressLocal='" + Emp.AddressLocal + "',");
                            sb.Append("DepartmentCode='" + Emp.DepartmentCode + "',");
                            sb.Append("ProjectCode='" + Emp.ProjectCode + "',");
                            sb.Append("BankCode='" + Emp.BankCode + "',");
                            sb.Append("BankAccNo='" + Emp.BankAccNo + "',");
                            sb.Append("AccNo='" + Emp.AccNo + "',");
                            sb.Append("ReportingEmp='" + Emp.ReportingEmp + "',");
                            sb.Append("MaritalStatus='" + Emp.MaritalStatus + "',");
                            sb.Append("BloodGroup='" + Emp.BloodGroup + "',");
                            sb.Append("PhysicallyDisabledYN='" + Emp.PhysicallyDisabledYN + "',");
                            sb.Append("PhysicallyDisabled='" + Emp.PhysicallyDisabled + "',");
                            sb.Append("Salutaion='" + Emp.Salutaion + "',");
                            sb.Append("ContactNo='" + Emp.ContactNo + "',");
                            sb.Append("EMail='" + Emp.EMail + "',");
                            sb.Append("BankBranchCode='" + Emp.BankBranchCode + "',");
                            sb.Append("ContactDate='" + dtstr6 + "',");
                            sb.Append("AbscondingYN='" + Emp.AbscondingYN + "',");
                            sb.Append("AbscondingDate='" + dtstr7 + "',");
                            sb.Append("TicketType='" + Emp.TicketType + "',");
                            sb.Append("TicketNo='" + Emp.TicketNo + "',");
                            sb.Append("Contract='" + Emp.Contract + "',");
                            sb.Append("SupervisorYN='" + Emp.SupervisorYN + "',");
                            sb.Append("LanguageKnown='" + Emp.LanguageKnown + "',");
                            //  sb.Append("'" + dtstr8 + "',");
                            sb.Append("GroupCode='" + Emp.GroupCode + "',");
                            sb.Append("LocCode='" + Emp.LocCode + "',");
                            sb.Append("photpath='" + Emp.photpath + "',");
                            sb.Append("Week_off1='" + Emp.Week_off1 + "',");
                            sb.Append("Week_off2='" + Emp.Week_off2 + "',");
                            sb.Append("wagesby='" + Emp.wagesby + "',");
                            sb.Append("country='" + Emp.Country + "',");
                            sb.Append("BranchCode='" + Emp.BranchCode + "'");

                            _EzBusinessHelper.ExecuteNonQuery("update MEM001 set " + sb + " where Cmpycode='" + Emp.Cmpycode + "' and EmpCode='" + Emp.EmpCode + "'");

                            #endregion



                            #region EmployeeDetail
                            n = ObjList.Count;

                            while (n > 0)
                            {
                              //DateTime dtedata = Convert.ToDateTime(ObjList[n - 1].StartDate.ToString());
                              // string dtstr4data = dtedata.ToString("yyyy-MM-dd");
                              // DateTime dtedata2 = Convert.ToDateTime(ObjList[n - 1].EndDate.ToString());
                              // string dtstr9data = dtedata2.ToString("yyyy-MM-dd hh:mm:ss");

                                sb.Clear();

                                sb.Append("(Cmpycode,");
                                sb.Append("EmpCode,");
                                sb.Append("DIVISION,");
                                sb.Append("HRDOCM001_CODE,");
                                //sb.Append("DocName,");
                                //sb.Append("DocNo,");
                                //sb.Append("StartDate,");
                                //sb.Append("EndDate,");
                                sb.Append("ENTRY_DATE,");
                                sb.Append("EXPIRED_DATE,");
                                sb.Append("ALERT_BEFORE,");
                                sb.Append("REMARKS)");
                                //sb.Append("Description,");
                                //sb.Append("DocumentPath,");

                                //sb.Append("Sno,");
                                //sb.Append("IssuePlace,");
                                //sb.Append("DocStatus)");


                                sb.Append(" values(");

                                sb.Append("'" + ObjList[n - 1].Cmpycode + "',");
                                sb.Append("'" + ObjList[n - 1].EmpCode + "',");
                                sb.Append("'" + ObjList[n - 1].DivisionCode + "',");
                                sb.Append("'" + ObjList[n - 1].HRDOCM001_CODE + "',");
                                //sb.Append("'" + ObjList[n - 1].DocName + "',");
                                //sb.Append("'" + ObjList[n - 1].DocNo + "',");
                                sb.Append("'" + ObjList[n - 1].StartDate + "',");
                                sb.Append("'" + ObjList[n - 1].EndDate + "',");
                                sb.Append("'" + ObjList[n - 1].AlertBefore + "',");

                                sb.Append("'" + ObjList[n - 1].Description + "')");
                                //sb.Append("'" + ObjList[n - 1].Description + "',");

                                //sb.Append("'" + ObjList[n - 1].DocumentPath + "',");
                                //sb.Append("'" + ObjList[n - 1].Sno + "',");
                                //sb.Append("'" + ObjList[n - 1].IssuePlace + "',");
                                //sb.Append("'" + ObjList[n - 1].DocStatus + "')");


                                _EzBusinessHelper.ExecuteNonQuery("insert into HRDOCE001" + sb + " ");
                                n = n - 1;
                            }

                            #endregion

                            #region EmployeeEducation
                            n = ObjList1.Count;

                            while (n > 0)
                            {

                                dte = Convert.ToDateTime(ObjList3[n - 1].NomineeDOB.ToString());
                                dtstr10 = dte.ToString("yyyy-MM-dd hh:mm:ss");
                                sb.Clear();

                                sb.Append("(Cmpycode, ");
                                sb.Append("code,");
                                sb.Append("SNo,");
                                sb.Append("Degree,");
                                sb.Append("DegreeName,");
                                sb.Append("Institution,");
                                sb.Append("ObtainedYear,");
                                sb.Append("Specification,");
                                sb.Append("Location)");
                                sb.Append(" values(");
                                sb.Append("'" + ObjList1[n - 1].Cmpycode + "' ,");
                                sb.Append("'" + ObjList1[n - 1].code + "' ,");
                                sb.Append("'" + ObjList1[n - 1].SNo + "' ,");
                                sb.Append("'" + ObjList1[n - 1].Degree + "' ,");
                                sb.Append("'" + ObjList1[n - 1].DegreeName + "' ,");
                                sb.Append("'" + ObjList1[n - 1].Institution + "' ,");
                                sb.Append("'" + ObjList1[n - 1].ObtainedYear + "' ,");
                                sb.Append("'" + ObjList1[n - 1].Specification + "' ,");
                                sb.Append("'" + ObjList1[n - 1].Location + "' )");
                                _EzBusinessHelper.ExecuteNonQuery("insert into EMPDET001" + sb + " ");
                                n = n - 1;
                            }
                            #endregion`
                           

                            #region EmployeeNominee
                            n = ObjList3.Count;

                            while (n > 0)
                            {

                                dte = Convert.ToDateTime(ObjList3[n - 1].NomineeDOB.ToString());
                                dtstr10 = dte.ToString("yyyy-MM-dd hh:mm:ss");
                                sb.Clear();

                                sb.Append("(CmpyCode,");
                                sb.Append("EmpCode,");
                                sb.Append("SNo,");
                                sb.Append("NomineeName,");
                                sb.Append("NomineeAddress,");
                                sb.Append("NomineeRelation,");
                                sb.Append("NomineeDOB)");


                                sb.Append(" values(");

                                sb.Append("'" + ObjList3[n - 1].CmpyCode + "' ,");
                                sb.Append("'" + ObjList3[n - 1].EmpCode + "' ,");
                                sb.Append("'" + ObjList3[n - 1].SNo + "' ,");
                                sb.Append("'" + ObjList3[n - 1].NomineeName + "' ,");
                                sb.Append("'" + ObjList3[n - 1].NomineeAddress + "' ,");
                                sb.Append("'" + ObjList3[n - 1].NomineeRelation + "' ,");
                                sb.Append("'" + dtstr10 + "' )");


                                _EzBusinessHelper.ExecuteNonQuery("insert into EMNM005" + sb + " ");

                                n = n - 1;
                            }

                            #endregion

                            #region EmployeeExp

                            #endregion
                        }


                        // _materialMgmtContext.SaveChanges();

                        EmpMs.ErrorMessage = string.Empty;
                        EmpMs.IsSavedFlag = true;
                        //}
                        //else
                        //{
                        //    po.ErrorMessage = "Purchase Order Header not available";
                        //    po.IsSavedFlag = false;
                        //}
                        scope1.Complete();
                    }
                }
                catch (Exception ex)
                {
                    EmpMs.ErrorMessage = "Error occur";
                    EmpMs.IsSavedFlag = false;
                }
            }

            return EmpMs;
        }

        public List<ComDropTbl> GetBranchCodeList(string CmpyCode, string divcode, string Prefix)
        {
            //return drop.GetBranchCode1(CmpyCode, divcode);

            return drop.GetCommonDrop("Code as [Code],NAME as [CodeName]", "MBR005", "DivCode='"+ divcode +"' and CmpyCode='" + CmpyCode + "' and Flag=0 and (Code like '" + Prefix + "%' or Name like '" + Prefix + "%')");

        }

    }
}
