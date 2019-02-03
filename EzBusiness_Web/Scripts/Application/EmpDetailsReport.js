var Empreport={
 
   initialize: function()
   {

       $('input[Type="date"]').val(new Date().getToday());
      // var jq = $.noConflict(true);
    $.fn.dataTable.ext.errorMode = 'none';
       Empreport.Attachevent();
       
   },
   Attachevent:function()
   {
       $("#btnSearchData").click(function () {
          // alert("");
      
           Empreport.EmpReportDetails();
       })
        $("#fnlbtnSearchData").click(function () {
          // alert("");
         // debugger;
           Empreport.FinalReportDetails();
        })
        $("#btncancel").click(function () {
          //$("#fdatetxt").val("");
          //$("#tdatetxt").val("");
            EzdtePk('#fdatetxt,#tdatetxt');
        })
        $("#fnlbtncancel").click(function () {
            //$("#fnlfdatetxt").val("");
            //$("#fnltdatetxt").val("");
            EzdtePk('#fnltdatetxt,#fnltdatetxt');
           $("#empcodetxt").val("");
           $("#empnametxt").val("");
        });
   },
   EmpReportDetails: function ()
   {
      // debugger;
       $("#displayemp").show();
       var fdate = $("#fdatetxt").val();
       var Tdate = $("#tdatetxt").val();
       var empCode = $("#empcodetxt").val();
       var empname = $("#empnametxt").val();
       var newrow = {
           Fdate: fdate,
           Tdate: Tdate,
           EmpName: empname,
           EmpCode: empCode
       }
        debugger;      
           var empdt = $('#Employeereport').DataTable({
               "ColumnDefs": [{ "Width": "5%", "targets": 0, "searchable": false, "orderable": false }],
               "order": [[1, 'asc']],
               "scrollX": true,
               "language":
               {
                   "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
               },
               "dom": 'lBfrtip',
               "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
               "buttons": [
                         'excel',
                         {
                             extend:'pdfHtml5',
                             orientation:'landscape',
                             pageSize: 'LEGAL'

                         }
               ],
               "fnRowCallback": function (nRow, aData, iDisplayIndex) {
                   var oSettings = this.fnSettings();
                   $("td:first", nRow).html(oSettings._iDisplayStart + iDisplayIndex + 1);
                   return nRow;
               },
               "processing": true,
               "serverSide": true,
               "ajax":
               {
                   "async": false,
                   "cache": false,
                   "type": "POST",
                   "url": '/GetEmpReportDetails',
                   "dataType": 'json',
                   "data": newrow,
                   //"contentType": "application/json; charset=utf-8",                     
               },
               "destroy": true,
               "sorting": true,
               "columns": [
                    {



                        "data": "srno",
                        "defaultContent":"" // WHICH IS CHANGED TO SR NO 
                    },
                  { "data": "EmpCode" },
                  { "data": "Empname" },
                  { "data": "EmpType" },
                 
                  { "data": "EMail" },
                   {
                       "data": "JoiningDate",
                       "render": function (data) {
                           return (Ezdatefrmt1(data));
                       }
                   },
                  { "data": "ContactNo" },
                  { "data": "Nationality" },
                  { "data": "DOB",
                   "render": function (data) {
                          return (Ezdatefrmt1(data));
                      }},
                  { "data": "ReportingEmp" },
                  { "data": "BloodGroup" },
                  { "data": "LanguageKnown" },

               ]
           });
           empdt.on('order.dt search.dt', function () {
               empdt.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
                   cell.innerHTML = i + 1;
                   empdt.cell(cell).invalidate('dom');
               });
           }).draw();
    },
   FinalReportDetails: function ()
   {
       
       debugger;
       $("#displayfinalsettlment").show();
       var fdate = Ezsetdtpkdate($("#fnlfdatetxt").val());
       var Tdate = Ezsetdtpkdate($("#fnltdatetxt").val());
       var empCode = $("#empcodetxt").val();
       var empname = $("#empnametxt").val();
       var newrow = {
           Fdate: fdate,
           Tdate: Tdate,
           EmpName: empname,
           EmpCode: empCode
       }
      // debugger;
     
           var fnldt = $('#finalsettlmentreport').DataTable({

               "ColumnDefs": [{ "Width": "5%", "targets": 0, "searchable": false, "orderable": false }],
               "order": [[1, 'asc']],
               "scrollX": true,
               "language":
               {
                   "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
               },
               "dom": 'lBfrtip',
               "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
               "buttons": [
                         'excel',
                           {
                               extend: 'pdfHtml5',
                               orientation: 'landscape',
                               pageSize: 'LEGAL'

                           }
               ],
               "fnRowCallback": function (nRow, aData, iDisplayIndex) {
                   var oSettings = this.fnSettings();
                   $("td:first", nRow).html(oSettings._iDisplayStart + iDisplayIndex + 1);
                   return nRow;
               },
               "processing": true,
               "serverSide": true,
               "ajax":
               {
                   "async": false,
                   "cache": false,
                   "type": "POST",
                   "url": '/GetFinalSettlementDetails',
                   "dataType": 'json',
                   "data": newrow,
                   //"contentType": "application/json; charset=utf-8",                     
               },
               "destroy": true,
               "sorting": true,
               "columns": [
                   { "data": null },
                  { "data": "EmpCode" },
                  { "data": "EmpName" },
                  { "data": "PRFSET001_code" },
                  { "data": "Reason" },
                  {
                      "data": "JoiningDate",
                      "render": function (data) {
                          return (Ezdatefrmt1(data));
                      }
                  },
                  {
                      "data": "Dates",
                      "render": function (data) {
                          return (Ezdatefrmt1(data));
                      }
                  },
                  {
                      "data": "SettledDate",
                      "render": function (data) {
                          return (Ezdatefrmt1(data));
                      }
                  },
                  {
                      "data": "DateofRelease",
                      "render": function (data) {
                          return (Ezdatefrmt1(data));
                      }
                  },
                  { "data": "NoOfDaysSuspended" },
                  { "data": "TotalNoOfDays" },
                  { "data": "Gratuity" },
                  { "data": "Addition" },
                  { "data": "Deduction" },
                  { "data": "NetAmount" },
                  { "data": "Basic" },
                  { "data": "SalType" },
                  { "data": "Absent" },
                  { "data": "DeductionDays" },
                  { "data": "Housing" },
                  { "data": "Tele_Allow" },
                  { "data": "Other_Allow" },
                  { "data": "Food" },
                  { "data": "Conveyance" },
                  { "data": "NoOfDays" },
                  { "data": "LNoOfDaysWkd" },
                  { "data": "LeaveCF" },
                  { "data": "LeaveBF" },
               ]
           });
           fnldt.on('order.dt search.dt', function () {
               fnldt.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
                   cell.innerHTML = i + 1;
                   fnldt.cell(cell).invalidate('dom');
               });
           }).draw();
     
    },

   ValidateReports:function(fdate,Tdate)
    {
       var msg = "";
       if(fdate=="")
       {
           msg = "FromDate should not be empty";
       }
       if (Tdate == "") {
           msg =msg+','+" "+"ToDate should not be empty";
       }
       if(fdate>=Tdate)
       {
          msg = msg + ',' + " " + "Fromdate should be greater than Todate";
       }
       return msg;
   }
}

