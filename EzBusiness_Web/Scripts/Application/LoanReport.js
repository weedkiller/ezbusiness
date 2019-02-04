var loanmastr = {

    initialize: function () {
        // var jq = $.noConflict(true);
   $('input[Type="date"]').val(new Date().getToday());
        $.fn.dataTable.ext.errorMode = 'none';
        loanmastr.Attachevent();

    },
    Attachevent: function () {

        $("#lanbtnSearchData").click(function () {
            // alert("");
            // debugger;
            loanmastr.LoanReportDetails();
        })
        $("#btncancel").click(function () {
            //$("#fdatetxt").val("");
            //$("#tdatetxt").val("");
             EzdtePk('#fdatetxt,#tdatetxt');
            $("#empcodetxt").val("");
            $("#empnametxt").val("");
        })
    },

    LoanReportDetails: function () {
        debugger;
        $("#displayloandetails").show();
        var LoanCode = $("#empcodetxt").val();
        var name = $("#nametxt").val();
        var newrow ={
            PRLM001_CODE:LoanCode,
            Name:name
        }
        // debugger;

        var fnldt = $('#loanreport').DataTable({

            "ColumnDefs": [{ "Width": "5%", "targets": 0, "searchable": false, "orderable": false }],
            "order": [[1, 'asc']],
            //"scrollX": true,
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
                "url": '/LoanReportDet',// GetLoanDetails
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
               { "data": "PRLM001_CODE" },
               { "data": "COUNTRY" },
               { "data": "Name" },
               { "data": "Act_code" }
            ]
        });
        fnldt.on('order.dt search.dt', function () {
            fnldt.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
                cell.innerHTML = i + 1;
                fnldt.cell(cell).invalidate('dom');
            });
        }).draw();
          $("select option").filter(function () {
            debugger;
            //may want to use $.trim in here
            //return $(this).text() == text1;
            if ($(this).text() == "All") {
                var tabledata = $('#loanreport').dataTable();
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

