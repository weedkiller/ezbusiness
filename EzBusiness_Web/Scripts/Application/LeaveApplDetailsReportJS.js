var LeaveApp = {

    initialize: function () {
        // var jq = $.noConflict(true);
           $('input[Type="date"]').val(new Date().getToday());
        $.fn.dataTable.ext.errorMode = 'none';
        LeaveApp.Attachevent();

    },
    Attachevent: function () {
        $("#btnSearchData").click(function () {
            // alert("");

            LeaveApp.LeaveApplicatnDetails();
        })
    },
    LeaveApplicatnDetails: function () {
        debugger;
        $("#displayleaveapp").show();
        var fdate = Ezsetdtpkdate($("#fdatetxt").val());
        var Tdate = Ezsetdtpkdate($("#tdatetxt").val());
        var newrow = {
            Fdate: fdate,
            Tdate: Tdate
        }
        debugger;
        var empdt = $('#Leavereport').DataTable({

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
                "url": '/GetLeaveApplReportDetails',
                "dataType": 'json',
                "data": newrow,
                //"contentType": "application/json; charset=utf-8",                     
            },
            "destroy": true,
            "sorting": true,
            "columns": [
                {
                    "data": "srno",
                    "defaultContent": "" // WHICH IS CHANGED TO SR NO 
                },
               { "data": "EmpCode" },
               {
                   "data": "JoiningDate",
                   "render": function (data) {
                       return (Ezdatefrmt1(data));
                   }
               },
               {
                   "data": "StartDate",
                   "render": function (data) {
                       return (Ezdatefrmt1(data));
                   }
               },
               {
                   "data": "EndDate",
                   "render": function (data) {
                       return (Ezdatefrmt1(data));
                   }
               },
               { "data": "TotalBalance" },
               { "data": "LeaveType" },
               { "data": "LeaveDays" },
               { "data": "TotalSanctioned" },
               { "data": "ApprovalYN" },
               { "data": "Remarks" },
               

            ]
        });
        empdt.on('order.dt search.dt', function () {
            empdt.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
                cell.innerHTML = i + 1;
                empdt.cell(cell).invalidate('dom');
            });
        }).draw();
        $("select option").filter(function () {
            debugger;
            //may want to use $.trim in here
            //return $(this).text() == text1;
            if ($(this).text() == "All") {
                var tabledata = $('#Leavereport').dataTable();
                //Get the total rows
                k = tabledata.fnSettings().fnRecordsTotal();
                $(this).val(k);
            }
        });
    }
}