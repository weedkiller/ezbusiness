var monthadddect = {

    initialize: function () {
        // var jq = $.noConflict(true);
        $('input[Type="date"]').val(new Date().getToday());
        $.fn.dataTable.ext.errorMode = 'none';
        monthadddect.Attachevent();

    },
    Attachevent: function () {
       
        $("#mnthbtnSearchData").click(function () {
            // alert("");
            //
            monthadddect.MonthlyAddDeductReportDetails();
        })
          $("#btncancel").click(function () {
          //$("#fdatetxt").val("");
          //$("#tdatetxt").val("");
           EzdtePk('#fdatetxt,#tdatetxt');
           $("#empcodetxt").val("");
           $("#empnametxt").val("");
        })
    },
   
    MonthlyAddDeductReportDetails: function () {
        
        $("#displaymonthlyadddeduct").show();
        var Mesg="";
        var fdate = Ezsetdtpkdate($("#fnlfdatetxt").val());
        var Tdate = Ezsetdtpkdate($("#fnltdatetxt").val());
        var empname = $("#empnametxt").val();
        var empCode = $("#empcodetxt").val();
        var newrow = {
            Fdate: fdate,
            Tdate: Tdate,
            EmpName: empname,
            EmpCode: empCode
        }
        Mesg = monthadddect.ValidateReports(newrow);
        if (Mesg == "") {
            var fnldt = $('#monthlyadddeductreport').DataTable({

                "ColumnDefs": [{ "Width": "5%", "targets": 0, "searchable": false, "orderable": false }],
                "order": [[0, 'asc']],
               // "scrollX": true,
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
                    "url": '/GetMonthlyAddDeductDetails',
                    "dataType": 'json',
                    "data": newrow,
                    //"contentType": "application/json; charset=utf-8",                     
                },
                "destroy": true,
                "sorting": true,
                "columns": [
                     {
                         "data": "srno",

                     },
                   { "data": "EmpCode" },
                   { "data": "EmpName" },
                   { "data": "PRADN001_CODE" },
                   { "data": "ADN_Amount" },
                   { "data": "ADNActcode" },
                   { "data": "T_type" },
                   { "data": "Remarks" },
                   {
                       "data": "EntryDate",
                       "render": function (data) {
                           return (EzdatefrmtRes1(data));
                       }
                   }
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
                    var tabledata = $('#monthlyadddeductreport').dataTable();
                    //Get the total rows
                    k = tabledata.fnSettings().fnRecordsTotal();
                    $(this).val(k);
                }
            });
        }
        else
        {
            EzAlerterrtxt(Mesg);
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
        if (newrow.Fdate > newrow.Tdate) {
            msg = msg + ',' + " " + "Todate should be greater than Fromdate";
        }
        return msg;
    }
}

