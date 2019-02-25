﻿
var prjreport = {
 
   initialize: function()
   {
       
       $('input[Type="date"]').val(new Date().getToday());
      // var jq = $.noConflict(true);
    $.fn.dataTable.ext.errorMode = 'none';
    prjreport.Attachevent();
       
   },
   Attachevent:function()
   {
       $("#btnSearchData").click(function () {
                              
          $('select').val('10');
           prjreport.ProjectReportDetails();
       })
       
        $("#btncancel").click(function () {
          //$("#fdatetxt").val("");
          //$("#tdatetxt").val("");
           Ezdteformtcur('#fdatetxt,#tdatetxt', 'DD/MM/YYYY');
       })    
   },
   ProjectReportDetails: function ()
   {
      //
       $("#displayemp").show();
       var Msg="";
       var fdate = $("#fdatetxt").val();
       var Tdate = $("#tdatetxt").val();
       var empCode = $("#empcodetxt").val();
       var empname = $("#empnametxt").val();
       var i = 0;
       var newrow = {
           CurrentDate: fdate,
           //Tdate: Tdate,
           EmpName: empname,
           EmpCode: empCode
       }
       Msg = prjreport.ValidateReports(newrow)
       if (Msg == "") {
           var empdt = $('#Projectreport').DataTable({
               "ColumnDefs": [{ "Width": "5%", "targets": 0, "searchable": false, "orderable": false }],
               "order": [[0, 'asc']],
               //"scrollX": true,
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
               "processing": true,
               "serverSide": true,
               //"stateSave": true,
               "ajax":
               {
                   "async": false,
                   "cache": false,
                   "type": "POST",
                   "url": '/GetProjectDetailsEmployeeWise',
                   "dataType": 'json',
                   "data": newrow,
                   //"contentType": "application/json; charset=utf-8",                     
               },
               "destroy": true,
               "sorting": true,
               "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
               "columns": [
                  { "data": "Srno" },
                  { "data": "EmpCode" },
                  { "data": "EmpName" },
                  { "data": "ProjectCode" },
                  { "data": "ProjectName" },
                  { "data": "ProjectDuration" },
                  //{ "data": "Tmonth" },
                  //{ "data": "Tyear" },
                  //{ "data": "LanguageKnown" },

               ]
           });

           $("select option").filter(function () {

               //may want to use $.trim in here
               //return $(this).text() == text1;
               if ($(this).text() == "All") {
                   var tabledata = $('#Projectreport').dataTable();
                   //Get the total rows
                   k = tabledata.fnSettings().fnRecordsTotal();
                   $(this).val(k);
               }
           });
       }
       else
       {
           EzAlerterrtxt(Msg);
       }
    },
 
   ValidateReports: function (newrow) {
       var msg = "";
       if (newrow.Fdate == "") {
           msg = "FromDate should not be empty";
       }
       if (newrow.Tdate == "") {
           msg = msg + ',' + " " + "ToDate should not be empty";
       }
       if (newrow.Fdate >= newrow.Tdate) {
           msg = msg + ',' + " " + "Fromdate should be greater than Todate";
       }
       return msg;
   }

}

