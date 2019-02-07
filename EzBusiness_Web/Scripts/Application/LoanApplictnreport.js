﻿var loandata = {

    initialize: function () {
        // var jq = $.noConflict(true);
           $('input[Type="date"]').val(new Date().getToday());
        $.fn.dataTable.ext.errorMode = 'none';
        loandata.Attachevent();

    },
    Attachevent: function () {

        $("#lanbtnSearchData").click(function () {
            // alert("");
            // debugger;
            loandata.LoanApplicationReportDetails();
        })
          $("#btncancel").click(function () {
              EzdtePk('#fdatetxt,#tdatetxt');
          //$("#fdatetxt").val("");
          //$("#tdatetxt").val("");
          $("#empcodetxt").val("");
          $("#empnametxt").val("");
        })
    },

    LoanApplicationReportDetails: function () {
        debugger;
        $("#displayloandetails").show();
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

        var fnldt = $('#LoanApplicationreport').DataTable({

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
            //"fnRowCallback": function (nRow, aData, iDisplayIndex) {
            //    var oSettings = this.fnSettings();
            //    $("td:first", nRow).html(oSettings._iDisplayStart + iDisplayIndex + 1);
            //    return nRow;
            //},
            "processing": true,
            "serverSide": true,
            "ajax":
            {
                "async": false,
                "cache": false,
                "type": "POST",
                "url": '/GetLoanApplicatnRDetails',
                "dataType": 'json',
                "data": newrow,
                //"contentType": "application/json; charset=utf-8",                     
            },
            "destroy": true,
            "sorting": true,
            "columns": [
               {
                   "data": "SrNo",
                 
               },
               { "data": "EmpCode" },
               { "data": "EmpName" },
               { "data": "PRLA001_CODE" },
               { "data": "LoanAmount" },
               { "data": "NoOfInstalments" },
               { "data": "Instalment" },
               { "data": "Deduction" },
               {
                   "data": "Entry_Date",
                   "render": function (data) {
                       return (EzdatefrmtRes1(data));
                   }
               },
               { "data": "Balance" },
               { "data": "Remarks" },
               { "data": "Status" },
               { "data": "AutoDeductionYN" },
               {
                   "data": "DeductionStartDate",
                   "render": function (data) {
                       return (EzdatefrmtRes1(data));
                   }
               },
                { "data": "Act_code" },
                { "data": "LoanType" },
                { "data": "ApprovalYN" },
                { "data": "AppliedAmt" }
            ]
        });
        //fnldt.on('order.dt search.dt', function () {
        //    fnldt.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
        //        cell.innerHTML = i + 1;
        //        fnldt.cell(cell).invalidate('dom');
        //    });
        //}).draw();
        $("select option").filter(function () {
            debugger;
            //may want to use $.trim in here
            //return $(this).text() == text1;
            if ($(this).text() == "All") {
                var tabledata = $('#LoanApplicationreport').dataTable();
                //Get the total rows
                k = tabledata.fnSettings().fnRecordsTotal();
                $(this).val(k);
            }
        });
    },

    ValidateReports: function (fdate, Tdate) {
        var msg = "";
        if (fdate == "") {
            msg = "FromDate should not be empty";
        }
        if (Tdate == "") {
            msg = msg + ',' + " " + "ToDate should not be empty";
        }
        if (fdate >= Tdate) {
            msg = msg + ',' + " " + "Fromdate should be greater than Todate";
        }
        return msg;
    }
}

