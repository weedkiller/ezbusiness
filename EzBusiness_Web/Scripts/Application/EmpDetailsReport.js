//var k=-1;
//var ln= "[[10, 25, 50, 100], [10, 25, 50, 100, 200]] "  ;
var Empreport = {
 
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
                              
          $('select').val('10');
           Empreport.EmpReportDetails();
          
          
          
       })
        $("#fnlbtnSearchData").click(function () {
          // alert("");
         //
           Empreport.FinalReportDetails();
        })
        $("#btncancel").click(function () {
          //$("#fdatetxt").val("");
          //$("#tdatetxt").val("");
            Ezdteformtcur('#fdatetxt,#tdatetxt', 'DD/MM/YYYY');
        })
        $("#fnlbtncancel").click(function () {
            //$("#fnlfdatetxt").val("");
            //$("#fnltdatetxt").val("");
            Ezdteformtcur('#fnltdatetxt,#fnltdatetxt','DD/MM/YYYY');
           $("#empcodetxt").val("");
           $("#empnametxt").val("");
        });
   },
   EmpReportDetails: function ()
   {
       //
       debugger;
       var msg = "";
       $("#displayemp").show();
       var fdate =Ezsetdtpkdate($("#fdatetxt").val());
       var Tdate =Ezsetdtpkdate($("#tdatetxt").val());
       var empCode = $("#empcodetxt").val();
       var empname = $("#empnametxt").val();
       var i = 0;
       var newrow = {
           Fdate: fdate,
           Tdate: Tdate,
           EmpName: empname,
           EmpCode: empCode
       }
       msg = Empreport.ValidateReports(newrow)
       if (msg=="") {
           var empdt = $('#Employeereport').DataTable({
               "ColumnDefs": [{ "Width": "5%", "targets": 0, "searchable": false, "orderable": false }],
               "order": [[0, 'asc']],
               "scrollX": true,
               "language":
               {
                   "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
               },
               "dom": 'Blfrtip',

               "buttons": [
                         'excel',
                            {
                                extend: 'pdfHtml5',
                                orientation: 'landscape',
                                pageSize: 'LEGAL'

                            }
               ],
               //"fnRowCallback": function (nRow, aData, iDisplayIndex) {
               //    var oSettings = this.fnSettings();
               //    $("td:first", nRow).html(oSettings._iDisplayStart + iDisplayIndex + 1);
               //    return nRow;
               //},
               "processing": true,
               "serverSide": true,
               //"stateSave": true,
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
               "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
               "columns": [
                    {
                        "data": "SrNo",

                    },
                  { "data": "EmpCode" },
                  { "data": "Empname" },
                  { "data": "EmpType" },
                  { "data": "EMail" },
                  {
                      "data": "JoiningDate",
                      "render": function (data) {
                          return (EzdatefrmtRes1(data));
                      }

                  },
                  { "data": "ContactNo" },
                  { "data": "Nationality" },
                  {
                      "data": "DOB",
                      "render": function (data) {
                          return (EzdatefrmtRes1(data));
                      }
                  },
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

           $("select option").filter(function () {

               //may want to use $.trim in here
               //return $(this).text() == text1;
               if ($(this).text() == "All") {
                   var tabledata = $('#Employeereport').dataTable();
                   //Get the total rows
                   k = tabledata.fnSettings().fnRecordsTotal();
                   $(this).val(k);
               }
           });

       }
       else
       {
           EzAlerterrtxt(msg)
       }
   },
   FinalReportDetails: function ()
   {
       
       
       $("#displayfinalsettlment").show();
       var msg="";
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
       msg = Empreport.ValidateReports(newrow)
       if (msg == "") {
           var fnldt = $('#finalsettlmentreport').DataTable({

               "ColumnDefs": [{ "Width": "5%", "targets": 0, "searchable": false, "orderable": false }],
               "order": [[0, 'asc']],
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
                   { "data": "SrNo" },
                  { "data": "EmpCode" },
                  { "data": "EmpName" },
                  { "data": "PRFSET001_code" },
                  { "data": "Reason" },
                  {
                      "data": "JoiningDate",
                      "render": function (data) {
                          return (EzdatefrmtRes1(data));
                      }
                  },
                  {
                      "data": "Dates",
                      "render": function (data) {
                          return (EzdatefrmtRes1(data));
                      }
                  },
                  {
                      "data": "SettledDate",
                      "render": function (data) {
                          return (EzdatefrmtRes1(data));
                      }
                  },
                  {
                      "data": "DateofRelease",
                      "render": function (data) {
                          return (EzdatefrmtRes1(data));
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
           //fnldt.on('order.dt search.dt', function () {
           //    fnldt.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
           //        cell.innerHTML = i + 1;
           //        fnldt.cell(cell).invalidate('dom');
           //    });
           //}).draw();
           $("select option").filter(function () {

               //may want to use $.trim in here
               //return $(this).text() == text1;
               if ($(this).text() == "All") {
                   var tabledata = $('#finalsettlmentreport').dataTable();
                   //Get the total rows
                   k = tabledata.fnSettings().fnRecordsTotal();
                   $(this).val(k);
               }
           });

       }
       else
       {
           EzAlerterrtxt(msg);
       }
    },

   ValidateReports: function (newrow)
    {
       var msg = "";
       if (newrow .Fdate== "")
       {
           msg = "FromDate should not be empty";
       }
       if (newrow.Tdate == "") {
           msg =msg+','+" "+"ToDate should not be empty";
       }
       if (newrow.Fdate > newrow.Tdate)
       {
          msg = msg + ',' + " " + "Todate should be greater than Fromdate";
       }
       return msg;
   }
}

