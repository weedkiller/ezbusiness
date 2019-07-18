using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using System.Data;
using System.Data.SqlClient;

using System.Configuration;
using System.Globalization;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_EF_Entity.FreightManagementEF.SEA_Export;

namespace EzBusiness_DL_Repository
{
    public class DropListFillFun
    {
        DataSet ds = null;
        DataTable dt = null;
        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        //public List<Discipline> GetDisciplineList(string CmpyCode)
        //{
        //    ds = _EzBusinessHelper.ExecuteDataSet("Select Code,Name from MDISC010 where CmpyCode='" + CmpyCode + "' ");
        //    List<Discipline> ObjList = null;
        //    if (ds.Tables.Count > 0)
        //    {
        //        dt = ds.Tables[0];
        //        DataRowCollection drc = dt.Rows;
        //        ObjList = new List<Discipline>();
        //        foreach (DataRow dr in drc)
        //        {
        //            ObjList.Add(new Discipline()
        //            {
        //                Code = dr["Code"].ToString(),
        //                Name = dr["Name"].ToString(),
        //            });

        //        }
        //    }
        //    return ObjList;
        //}
        public List<Division> GetDivCode(string cmpcode)
        {
            //MDIV011
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from MDIV011 where CmpyCode='" + cmpcode + "' and Flag=0");
            List<Division> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                 ObjList = new List<Division>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new Division()
                    {
                        CmpyCode = dr["CmpyCode"].ToString(),
                        DivisionCode = dr["DivisionCode"].ToString(),
                        DivisionName = dr["DivisionName"].ToString(),

                    });

                }
            }
            return ObjList;
          
        }
        //public List<Accounts_Tbl> GetAccList(string CmpyCode, string Typeofacc)
        //{
        //    ds = _EzBusinessHelper.ExecuteDataSet("Select AccNo,Description from ACC_TBL083 where CmpyCode='" + CmpyCode + "' and Typeofacc='" + Typeofacc + "' And GenDet='D' Order By AccNo ");
        //    List<Accounts_Tbl> ObjList = null;
        //    if (ds.Tables.Count > 0)
        //    {
        //        dt = ds.Tables[0];
        //        DataRowCollection drc = dt.Rows;
        //         ObjList = new List<Accounts_Tbl>();
        //        foreach (DataRow dr in drc)
        //        {
        //            ObjList.Add(new Accounts_Tbl()
        //            {
        //                AccNo = dr["AccNo"].ToString(),
        //                Description = dr["Description"].ToString(),
        //            });

        //        }
        //    }
        //    return ObjList;
        //}
        public List<BankBranchTbl> GetBankBranchList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select PRBM002_code,Bank_branch_name from PRBM002 where CmpyCode='" + CmpyCode + "' and Flag=0");
            List<BankBranchTbl> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
               ObjList = new List<BankBranchTbl>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new BankBranchTbl()
                    {
                        PRBM002_code = dr["PRBM002_code"].ToString(),
                        Bank_branch_name = dr["Bank_branch_name"].ToString(),
                    });
                }
            }
            return ObjList;
        }
        public List<BankMaster> GetBankList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select PRBM001_code,Bank_name from PRBM001 where CmpyCode='" + CmpyCode + "' and Flag=0");
            List<BankMaster> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                ObjList = new List<BankMaster>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new BankMaster()
                    {
                        PRBM001_code = dr["PRBM001_code"].ToString(),
                        Bank_name = dr["Bank_name"].ToString(),
                    });

                }
            }
            return ObjList;
        }
        public List<CommonTable> GetCommList(string Type)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select Code,Name from CMTBL003 where Type='" + Type + "' ");
            List<CommonTable> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                ObjList = new List<CommonTable>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new CommonTable()
                    {
                        Code = dr["Code"].ToString(),
                        Name = dr["Name"].ToString(),
                    });

                }
            }
            return ObjList;
        }
        public List<Department> GetDepartmentList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select DepartmentCode,DepartmentName from MDEP009 where CmpyCode='" + CmpyCode + "' and Flag=0");
            List<Department> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                 ObjList = new List<Department>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new Department()
                    {
                        DepartmentCode = dr["DepartmentCode"].ToString(),
                        DepartmentName = dr["DepartmentName"].ToString(),
                    });

                }
            }
            return ObjList;
        }
        public List<Department> GetDepCode(string CmpyCode, string DivCode, string BranchCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from MDEP009 where CmpyCode='" + CmpyCode + "'and BranchCode='" + BranchCode + "' and DivisionCode='" + DivCode + "' and Flag=0");
            List<Department> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                 ObjList = new List<Department>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new Department()
                    {
                        Cmpycode = dr["CmpyCode"].ToString(),
                        DepartmentCode = dr["DepartmentCode"].ToString(),
                        DepartmentName = dr["DepartmentName"].ToString(),
                        //  UniCodeName = dr["UniCodeName"].ToString(),
                    });

                }
            }
            return ObjList;

        }
        public List<Company> GetCompCode()
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from CMP001");
            List<Company> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                ObjList = new List<Company>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new Company()
                    {

                        CmpyCode = dr["CmpyCode"].ToString(),
                        Name = dr["Name"].ToString(),

                    });

                }
            }
            return ObjList;

        }
        public List<BranchTbl> GetBranchCode1(string CmpyCode, string DivCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from MBR005 where CmpyCode='" + CmpyCode + "' and DivCode='" + DivCode + "' and Flag=0 "); //
            List<BranchTbl> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
               ObjList = new List<BranchTbl>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new BranchTbl()
                    {

                        Code = dr["Code"].ToString(),
                        Name = dr["Name"].ToString(),
                    });
                }
            }
            return ObjList;

        }
        public List<BankBranchTbl> GetBranchCode(string CmpyCode, string BankCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRBM002 where CmpyCode='" + CmpyCode + "' and PRBM001_code='" + BankCode + "'and Flag=0"); //
            List<BankBranchTbl> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                 ObjList = new List<BankBranchTbl>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new BankBranchTbl()
                    {
                        PRBM002_code = dr["PRBM002_code"].ToString(),
                        Bank_branch_name = dr["Bank_branch_name"].ToString(),
                    });
                }
            }
            return ObjList;
        }
        public List<Employee> GetEmpCodes(string CmpyCode,string typ)
        {
            string qur="";
            if (typ=="L"){
                qur = "SELECT EmpCode, EmpName,JoiningDate FROM MEM001 WHERE CmpyCode = '" + CmpyCode + "'  And WorkingStatus = 'Y' and LeaveStatus='N' and Flag=0 Order By EmpCode";
            }
            else if(typ=="F")
            {
                qur = "SELECT EmpCode, EmpName,JoiningDate FROM MEM001 WHERE CmpyCode = '" + CmpyCode + "'  And WorkingStatus in('T','R') and Flag=0  Order By EmpCode";
            }
            else if(typ=="A")
            {
                qur = "SELECT EmpCode, EmpName,JoiningDate FROM MEM001 WHERE CmpyCode = '" + CmpyCode + "' and Flag=0  Order By EmpCode";
            }
            else if (typ == "UR")
            {
                qur = "SELECT EmpCode, EmpName,JoiningDate FROM MEM001 WHERE CmpyCode ='" + CmpyCode + "' and Flag=0 and EmpCode not in (Select EmpCode from Users where Cmpycode=MEM001.Cmpycode)";
            }
            else if (typ == "T")
            {
                qur = "SELECT  Empcode, EmpName,JoiningDate FROM Vw_GetReportIngEmployee WHERE CmpyCode = '" + CmpyCode + "' and Flag=0 And WorkingStatus = 'Y'  Order By ReportingEmp";
            }
            else if (typ == "SM")
            {
                qur = "SELECT EmpCode, EmpName,JoiningDate FROM MEM001 WHERE CmpyCode = '" + CmpyCode + "' and Flag=0 And WorkingStatus = 'Y'  Order By EmpCode";
            }
            else if (typ == "B")
            {
                qur = "SELECT EmpCode, EmpName,JoiningDate FROM MEM001 WHERE CmpyCode ='" + CmpyCode + "' and Flag=0 and EmpCode not in (Select EmpCode from PRBM003 where Cmpycode=MEM001.Cmpycode)";
            }
            else
            {
                qur = "SELECT EmpCode, EmpName,JoiningDate FROM MEM001 WHERE CmpyCode = '" + CmpyCode + "'  And WorkingStatus = 'Y' and Flag=0  Order By EmpCode";
            }
            ds = _EzBusinessHelper.ExecuteDataSet(qur);
            List<Employee> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                ObjList = new List<Employee>();
                foreach (DataRow dr in drc)
                {
                    //DateTime dte;
                    //string dtstr4;
                    //dte = Convert.ToDateTime(dr["JoiningDate"].ToString());
                    //dtstr4 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
                    ObjList.Add(new Employee()
                    {
                        EmpCode = dr["EmpCode"].ToString(),
                        Empname = dr["EmpName"].ToString(),
                        //JoiningDate= dtstr4.ToString(),
                    });
                }
            }
            return ObjList;
        }
        public List<Employee> GetEmpList1(string CmpyCode, string empcode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("SELECT '01' AS EmpCode, 'SELF' AS EmpName UNION ALL SELECT EmpCode,EmpName FROM MEM001 WHERE CmpyCode = N'" + CmpyCode + "' AND EmpCode <>'" + empcode + "'  and Flag=0 ORDER BY EmpCode");
            List<Employee> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                ObjList = new List<Employee>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new Employee()
                    {
                        EmpCode = dr["EmpCode"].ToString(),
                        Empname = dr["EmpName"].ToString(),
                    });
                }
            }
            return ObjList;
        }
        public List<EducationLevel> GetDegreeList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select Code,Name from MEDUL013 where CmpyCode='" + CmpyCode + "'  ");
            List<EducationLevel> ObjList = null;
            if (ds.Tables.Count > 0)
            { 
                dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            ObjList = new List<EducationLevel>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new EducationLevel()
                {
                    Code = dr["Code"].ToString(),
                    Name = dr["Name"].ToString(),

                });

            }
            }
            return ObjList;
        }
        public List<ProjectMaster> GetProjects(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select Name,Code from CCH004 where CmpyCode='" + CmpyCode + "' and Flag=0");
            List<ProjectMaster> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                 ObjList = new List<ProjectMaster>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new ProjectMaster()
                    {
                        Name = dr["Name"].ToString(),
                        Code = dr["Code"].ToString(),
                    });

                }
            }
            return ObjList;
        }
        public List<TDSTypes> GetTDSTypesList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select Code,Name from MTTYP026 where CmpyCode='" + CmpyCode + "'  ");
            List<TDSTypes> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                ObjList = new List<TDSTypes>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new TDSTypes()
                    {
                        Code = dr["Code"].ToString(),
                        Name = dr["Name"].ToString(),
                    });

                }
            }
            return ObjList;
        }
        public List<PaymentNature> GetPaymentNatureList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select Code,Name from MPAYNAT020 where CmpyCode='" + CmpyCode + "'  ");
            List<PaymentNature> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                ObjList = new List<PaymentNature>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new PaymentNature()
                    {
                        Code = dr["Code"].ToString(),
                        Name = dr["Name"].ToString(),
                    });

                }
            }
            return ObjList;
        }
        public List<Profession> GetProfList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select ProfCode,ProfName from MPROF021 where CmpyCode='" + CmpyCode + "' and Flag=0");
            List<Profession> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                 ObjList = new List<Profession>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new Profession()
                    {
                        ProfCode = dr["ProfCode"].ToString(),
                        ProfName = dr["ProfName"].ToString(),
                    });

                }
            }
            return ObjList;
        }
        public List<Grade> GetSalution()
        {
            ds = _EzBusinessHelper.ExecuteDataSet(" SELECT 'Mr' AS Code,'Mr' AS Name UNION SELECT 'Ms' AS Code,'Ms' AS Name UNION SELECT 'Mrs' AS Code,'Mrs' AS Name Order By Code  ");
            List<Grade> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                ObjList = new List<Grade>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new Grade()
                    {
                        Code = dr["Code"].ToString(),
                        Name = dr["Name"].ToString(),
                    });

                }
            }
            return ObjList;
        }
        public List<ShiftMaster> GetShiftMasterList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select PRSFT001_code,ShiftName from PRSFT001 where CmpyCode='" + CmpyCode + "' and Flag=0");
            List<ShiftMaster> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                 ObjList = new List<ShiftMaster>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new ShiftMaster()
                    {
                        PRSFT001_code = dr["PRSFT001_code"].ToString(),
                        ShiftName = dr["ShiftName"].ToString(),
                    });

                }
            }
            return ObjList;
        }
        public List<StatusMaster> GetStatusMasterList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select Code,Name from MSTS023 where CmpyCode='" + CmpyCode + "' and Flag=0");
            List<StatusMaster> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                 ObjList = new List<StatusMaster>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new StatusMaster()
                    {
                        Code = dr["Code"].ToString(),
                        Name = dr["Name"].ToString(),
                    });
                }
            }
            return ObjList;
        }
        public List<SubTrademaster> GetSubTrademaster(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select Code,Name from MSUBTRD024 where CmpyCode='" + CmpyCode + "'  ");
            List<SubTrademaster> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                ObjList = new List<SubTrademaster>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new SubTrademaster()
                    {
                        Code = dr["Code"].ToString(),
                        Name = dr["Name"].ToString(),
                    });

                }
            }
            return ObjList;
        }
        public List<TDSSection> GetTDSSection(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select Code,Name from MTDSSEC025 where CmpyCode='" + CmpyCode + "'  ");
            List<TDSSection> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                 ObjList = new List<TDSSection>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new TDSSection()
                    {
                        Code = dr["Code"].ToString(),
                        Name = dr["Name"].ToString(),
                    });

                }
            }
            return ObjList;
        }
        public List<VisaLocation> GetVisaLocationList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select Code,Name from VLOC001 where CmpyCode='" + CmpyCode + "' and Flag=0");
            
            List<VisaLocation> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                ObjList = new List<VisaLocation>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new VisaLocation()
                    {
                        Code = dr["Code"].ToString(),
                        Name = dr["Name"].ToString(),

                    });

                }
            }
            return ObjList;
        }
        public List<Weekdays> GetWeekdaysList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select DayCode,DayName,SNo from WKDS001 order by sno");
           
            List<Weekdays> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                ObjList = new List<Weekdays>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new Weekdays()
                    {
                        DayCode = dr["DayCode"].ToString(),
                        DayName = dr["DayName"].ToString(),
                        SNo = dr["SNo"].ToString(),

                    });

                }
            }
            return ObjList;
        }
        public List<Documents> GetDocList(string CmpyCode)
        {
            //ds = _EzBusinessHelper.ExecuteDataSet("Select DocCode,DocName from MDOC012 where CmpyCode='" + CmpyCode + "' and Flag=0");
            ds = _EzBusinessHelper.ExecuteDataSet("Select HRDOCM001_CODE,Name from HRDOCM001 where CmpyCode='" + CmpyCode + "' ");

            List<Documents> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                 ObjList = new List<Documents>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new Documents()
                    {
                        DocCode = dr["HRDOCM001_CODE"].ToString(),
                        DocName = dr["Name"].ToString(),
                    });
                }
            }
            return ObjList;
        }
        //public List<EmployeeTypeMaster> GetEmployeeTypeMasterList(string CmpyCode)
        //{
        //    ds = _EzBusinessHelper.ExecuteDataSet("Select Code,Name from MEMTYP014 where CmpyCode='" + CmpyCode + "'  ");
          
        //    List<EmployeeTypeMaster> ObjList = null;
        //    if (ds.Tables.Count > 0)
        //    {
        //        dt = ds.Tables[0];
        //        DataRowCollection drc = dt.Rows;
        //        ObjList = new List<EmployeeTypeMaster>();
        //        foreach (DataRow dr in drc)
        //        {
        //            ObjList.Add(new EmployeeTypeMaster()
        //            {
        //                Code = dr["Code"].ToString(),
        //                Name = dr["Name"].ToString(),
        //            });

        //        }
        //    }
        //    return ObjList;
        //}
        public List<Location> GetLocationList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select LocCode,LocName from MLOC018 where CmpyCode='" + CmpyCode + "'  ");
           
            List<Location> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                 ObjList = new List<Location>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new Location()
                    {
                        LocCode = dr["LocCode"].ToString(),
                        LocName = dr["LocName"].ToString(),
                    });

                }
            }
            return ObjList;
        }
        public List<Nation> GetNationList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select Code,Name from MNAT019 where CmpyCode='" + CmpyCode + "' ");
            List<Nation> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                ObjList = new List<Nation>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new Nation()
                    {
                        Code = dr["Code"].ToString(),
                        Name = dr["Name"].ToString(),
                    });
                }
            }
            return ObjList;
        }
        public List<FNM_CURRENCY> GetCurrencyList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select currency_code,currency_name from fnm_currency  ");
            List<FNM_CURRENCY> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                ObjList = new List<FNM_CURRENCY>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new FNM_CURRENCY()
                    {
                        CURRENCY_CODE = dr["currency_code"].ToString(),
                        CURRENCY_NAME = dr["currency_name"].ToString(),
                    });
                }
            }
            return ObjList;
        }
        public List<Attendence> GetAtens(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select Code,LeaveName from MLH033 where CmpyCode='" + CmpyCode + "' and Flag=0");           
            List<Attendence> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                ObjList = new List<Attendence>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new Attendence()
                    {
                        Code = dr["Code"].ToString(),
                        LeaveName = dr["LeaveName"].ToString(),
                    });
                }
            }
            return ObjList;
        }

        public List<ExchangeRates> GetCurrencyExchangeList(string CompyCode)
        {
            List<ExchangeRates> ObjList = null;
            ds = _EzBusinessHelper.ExecuteDataSet("SELECT CurCode, CurName,CurRate FROM PMEXCHNGRT001 WHERE Cmpycode ='" + CompyCode + "' Order By Curcode ");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                ObjList = new List<ExchangeRates>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new ExchangeRates()
                    {
                        CurCode = dr["CurCode"].ToString(),
                        CurName = dr["CurName"].ToString(),
                        CurRate = Convert.ToDecimal(dr["CurRate"]),
                    });

                }
            }
            return ObjList;
        }

        public List<Supplier> GetSupplierList(string Cmpycode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select Name,Suppliercode from PMSUPH001 where CmpyCode='" + Cmpycode + "'  AND SupplierType='S' ");
           
            List<Supplier> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                 ObjList = new List<Supplier>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new Supplier()
                    {
                        Name = dr["Name"].ToString(),
                        Suppliercode = dr["Suppliercode"].ToString(),
                    });

                }
            }
            return ObjList;
        }
        //public List<dateYm> GetMonth()
        //{
        //    List<dateYm> ObjList = new List<dateYm>();          
        //    for (int i = 0; i < 12; i++)
        //    {                
        //        ObjList.Add(new dateYm()
        //        {
        //            Code = i,
        //            Month1 = CultureInfo.CurrentUICulture.DateTimeFormat.MonthNames[i]
        //        });
        //    }                     
        //    return ObjList;
        //}

        public List<Department> GetDepCodebyDivision(string CmpyCode, string DivCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from MDEP009 where CmpyCode='" + CmpyCode + "'and DivisionCode='" + DivCode + "' and Flag=0");
            List<Department> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                ObjList = new List<Department>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new Department()
                    {
                        Cmpycode = dr["CmpyCode"].ToString(),
                        DepartmentCode = dr["DepartmentCode"].ToString(),
                        DepartmentName = dr["DepartmentName"].ToString(),
                        //  UniCodeName = dr["UniCodeName"].ToString(),
                    });

                }
            }
            return ObjList;

        }
        public List<FFM_VESSEL> GetVessalCode(string cmpcode)
        {
            //MDIV011
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FFM_VESSEL where CmpyCode='" + cmpcode + "' and Flag1=0");
            List<FFM_VESSEL> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                ObjList = new List<FFM_VESSEL>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new FFM_VESSEL()
                    {
                        FFM_VESSEL_CODE = dr["FFM_VESSEL_CODE"].ToString(),
                        NAME = dr["NAME"].ToString(),
                     //   DivisionName = dr["DivisionName"].ToString(),

                    });

                }
            }
            return ObjList;

        }
        public List<FFM_PORT> GetPortList(string cmpcode)
        {
            //MDIV011
            ds = _EzBusinessHelper.ExecuteDataSet("select FFM_PORT_CODE,NAME from FFM_PORT where cmpycode='" + cmpcode + "' and flag=0");
            List<FFM_PORT> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                ObjList = new List<FFM_PORT>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new FFM_PORT()
                    {
                        FFM_PORT_CODE = dr["FFM_PORT_CODE"].ToString(),
                        NAME = dr["NAME"].ToString(),
                        //   DivisionName = dr["DivisionName"].ToString(),

                    });

                }
            }
            return ObjList;

        }

        public List<ComDropTbl> GetCommonDrop(string colname, string tblname, string condition)
        {
            ds = _EzBusinessHelper.ExecuteDataSet1("Select " + colname + " from " + tblname + " where " + condition + "");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<ComDropTbl> ObjList = new List<ComDropTbl>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new ComDropTbl()
                {
                    Code = dr["Code"].ToString(),
                    CodeName = dr["CodeName"].ToString(),

                });
            }
            return ObjList;
        }

        public List<ComDropTbl> GetCommonDrop2(string query)
        {
            ds = _EzBusinessHelper.ExecuteDataSet1(query);// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<ComDropTbl> ObjList = new List<ComDropTbl>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new ComDropTbl()
                {
                    Code = dr["Code"].ToString(),
                    CodeName = dr["CodeName"].ToString(),

                });
            }
            return ObjList;
        }

        public List<ComDropTbl1> GetCommonDrop1(string colname, string tblname, string condition)
        {
            ds = _EzBusinessHelper.ExecuteDataSet1("Select " + colname + " from " + tblname + " where " + condition + "");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<ComDropTbl1> ObjList = new List<ComDropTbl1>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new ComDropTbl1()
                {
                    CUSTOMER_CODE = dr["CUSTOMER_CODE"].ToString(),
                    CUSTOMER_NAME = dr["CUSTOMER_NAME"].ToString(),
                    CONTROL_ACT=dr["CONTROL_ACT"].ToString()

                });
            }
            return ObjList;
        }
    }
}
