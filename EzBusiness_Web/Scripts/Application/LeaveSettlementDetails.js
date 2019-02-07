var LeaveSet = {

    initialize: function () {
        // var jq = $.noConflict(true);
   $('input[Type="date"]').val(new Date().getToday());
        $.fn.dataTable.ext.errorMode = 'none';
        LeaveSet.Attachevent();

    },
    Attachevent: function () {
        $("#btnSearchData").click(function () {
            // alert("");

            LeaveSet.LeaveSettlementDetails();
        })
    },
    LeaveSettlementDetails: function () {
        debugger;
        $("#displayleaveset").show();
        var fdate = Ezsetdtpkdate($("#fdatetxt").val());
        var Tdate = Ezsetdtpkdate($("#tdatetxt").val());
        var empCode = $("#empcodetxt").val();
        var empname = $("#empnametxt").val();
        var i = 0;
        var newrow = {
            Fdate: fdate,
            Tdate: Tdate,
            EmpName: empname,
            EmpCode: empCode
        }
        debugger;
        $('#LeaveSetreport').empty();
        var empdt = $('#LeaveSettreport').DataTable({
            "ColumnDefs": [{ "Width": "5%", "targets":[0], "searchable": false, "orderable": false }],
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
                "url": '/GetLeaveSettlemenntReportDetails',
                "dataType": 'json',
                "data": newrow,
                //"contentType": "application/json; charset=utf-8",                     
            },
            "destroy": true,
            "columns": [
                {

                    "data": "srno",
                },
               { "data": "Empcode" },
               {"data":"EmpName"},
               { "data": "LStartDate",
               "render": function (data) {
                   return (EzdatefrmtRes1(data));
               }
               },
               {
                   "data": "LendDate",
                   "render": function (data) {
                       return (EzdatefrmtRes1(data));
                   }
               },
               { "data": "Sanctioned_Days" },
               { "data": "Total_days" },
               { "data": "Total_worked_Days" },
               { "data": "Total_LE_Days" },
               { "data": "LB_CF_Days" },
               { "data": "Leave_Salary" },
               { "data": "Addition_amt" },
               { "data": "Deduction_Amt" },
               { "data": "Ticket_amt" },
               { "data": "Ticket_Paid" },
               { "data": "Pending_Salary" },
               { "data": "Advance_Salary" },
               { "data": "Advance_Paid" },
               { "data": "Actual_Salary" },
               { "data": "Net_Pay" },
               {
                   "data": "salary_effect_date",
                   "render": function (data) {
                       return (EzdatefrmtRes1(data));
                   }
               },


            ]
        });
       
        $("select option").filter(function () {
            debugger;
            //may want to use $.trim in here
            //return $(this).text() == text1;
            if ($(this).text() == "All") {
                var tabledata = $('#LeaveSetreport').dataTable();
                //Get the total rows
                k = tabledata.fnSettings().fnRecordsTotal();
                $(this).val(k);
            }
        });

    }
}