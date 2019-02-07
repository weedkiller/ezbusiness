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
        var empCode = $("#empcodetxt").val();
        var empname = $("#empnametxt").val();
        var newrow = {
            Fdate: fdate,
            Tdate: Tdate,
            EmpName: empname,
            EmpCode: empCode
        }
        debugger;
        var empdt = $('#Leavereport').DataTable({

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
                  
                },
               { "data": "EmpCode" },
               {"data":"EmpName"},
               {
                   "data": "JoiningDate",
                   "render": function (data) {
                       return (EzdatefrmtRes1(data));
                   }
               },
               {
                   "data": "StartDate",
                   "render": function (data) {
                       return (EzdatefrmtRes1(data));
                   }
               },
               {
                   "data": "EndDate",
                   "render": function (data) {
                       return (EzdatefrmtRes1(data));
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