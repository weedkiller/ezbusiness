﻿var DutyResume = {

    initialize: function () {
        // var jq = $.noConflict(true);
        $('input[Type="date"]').val(new Date().getToday());
        $.fn.dataTable.ext.errorMode = 'none';
        DutyResume.Attachevent();

    },
    Attachevent: function () {
        $("#btnSearchData").click(function () {
            // alert("");
            DutyResume.DutyResumeDetails();
        })
    },
    DutyResumeDetails: function () {
        debugger;
        $("#displayDutyResume").show();
        var fdate = Ezsetdtpkdate($("#fdatetxt").val());
        var Tdate = Ezsetdtpkdate($("#tdatetxt").val());
        var newrow = {
            Fdate: fdate,
            Tdate: Tdate
        }
        debugger;
        var empdt = $('#DutyResumereport').DataTable({

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
                "url": '/GetEmpDutyResumeDetails',
                "dataType": 'json',
                "data": newrow,
                //"contentType": "application/json; charset=utf-8",                     
            },
            "destroy": true,
            "sorting": true,
            "columns": [
                { "data": null },
               {
                   "data": "EmpCode"
               },
               {
                   "data": "ResumeDate",
                   "render":function(data){
                       return (Ezdatefrmt1(data));
                   }
               },
               { "data": "Actual_Leave_Type" },
               { "data": "Duty_Rm_type" },
               { "data": "Approve_Days" },
               { "data": "Excess_Days_plus_minus" },
               { "data": "Approve_Days_in_full" },
               { "data": "Approve_Days_in_Half" },
            ]
        });
        empdt.on('order.dt search.dt', function () {
            empdt.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
                cell.innerHTML = i + 1;
                empdt.cell(cell).invalidate('dom');
            });
        }).draw();
    }
}