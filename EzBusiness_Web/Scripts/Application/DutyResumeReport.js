var DutyResume = {

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
        
        $("#displayDutyResume").show();
        var Msg = "";
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
        Msg = DutyResume.ValidateReports(newrow)
        if (Msg == "") {
            var empdt = $('#DutyResumereport').DataTable({

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
                    "url": '/GetEmpDutyResumeDetails',
                    "dataType": 'json',
                    "data": newrow,
                    //"contentType": "application/json; charset=utf-8",                     
                },
                "destroy": true,
                "sorting": true,
                "columns": [
                   {
                       "data": "SrNo"
                   },
                   {
                       "data": "EmpCode"
                   },
                   { "data": "EmpName" },
                   {
                       "data": "ResumeDate",
                       "render": function (data) {
                           return (EzdatefrmtRes1(data));
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

            $("select option").filter(function () {

                //may want to use $.trim in here
                //return $(this).text() == text1;
                if ($(this).text() == "All") {
                    var tabledata = $('#DutyResumereport').dataTable();
                    //Get the total rows
                    k = tabledata.fnSettings().fnRecordsTotal();
                    $(this).val(k);
                }
            });
        }
        else {
            EzAlerterrtxt(Msg);
        }
    },
    ValidateReports: function (newrow)
    {
        var msg = "";
        if (newrow .Fdate== "")
        {
            msg = "FromDate should not be empty";
        }
        if (newrow.Tdate == "") {
            msg =msg+','+" "+"ToDate should not be empty";
        }
        if (newrow.Fdate > newrow.Tdate)
        {
            msg = msg + ',' + " " + "Todate should be greater than Fromdate";
        }
        return msg;
    }
}