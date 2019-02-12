
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
      // debugger;
       $("#displayemp").show();
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
                   "url": '/GetProjectDetailsEmployeeWise',
                   "dataType": 'json',
                   "data": newrow,
                   //"contentType": "application/json; charset=utf-8",                     
               },             
               "destroy": true,
               "sorting": true,
               "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
               "columns": [
                  {"data": "Srno"},
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
           debugger;
           //may want to use $.trim in here
           //return $(this).text() == text1;
           if ($(this).text() == "All") {
               var tabledata = $('#Projectreport').dataTable();
               //Get the total rows
               k = tabledata.fnSettings().fnRecordsTotal();
               $(this).val(k);
           }         
       });
     
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

