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
            // debugger;
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
        debugger;
        $("#displaymonthlyadddeduct").show();
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
        // debugger;

        var fnldt = $('#monthlyadddeductreport').DataTable({

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
                "url": '/GetMonthlyAddDeductDetails',
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
               { "data": "PRADN001_CODE" },
               { "data": "ADN_Amount" },
               { "data": "ADNActcode" },
               { "data": "T_type" },
               { "data": "Remarks" },
               {
                   "data": "EntryDate",
                   "render": function (data) {
                       return (Ezdatefrmt1(data));
                   }
               }
            ]
        });
        fnldt.on('order.dt search.dt', function () {
            fnldt.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
                cell.innerHTML = i + 1;
                fnldt.cell(cell).invalidate('dom');
            });
        }).draw();

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

