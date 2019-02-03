var ShiftMaster = {

    initialize: function () {
        // var jq = $.noConflict(true);
        $('input[Type="date"]').val(new Date().getToday());
        $.fn.dataTable.ext.errorMode = 'none';
        ShiftMaster.Attachevent();

    },
    Attachevent: function () {
        $("#btnSearchData").click(function () {
            // alert("");

            ShiftMaster.ShiftMasterDetails();
        })
    },
    ShiftMasterDetails: function () {
        debugger;
        $("#displayShiftMaster").show();
        var fdate = Ezsetdtpkdate($("#fdatetxt").val());
        var Tdate = Ezsetdtpkdate($("#tdatetxt").val());
        var newrow = {
            Fdate: fdate,
            Tdate: Tdate
        }
        debugger;
        var empdt = $('#ShiftMasterreport').DataTable({

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
                "url": '/GetEmpShiftMasterDetails',
                "dataType": 'json',
                "data": newrow,
                //"contentType": "application/json; charset=utf-8",                     
            },
            "destroy": true,
            "sorting": true,
            "columns": [
                { "data": null },
               { "data": "ShiftName" },
               { "data": "country" },
               { "data": "division" },
               { "data": "StTime" },
               { "data": "EdTime" },
             
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