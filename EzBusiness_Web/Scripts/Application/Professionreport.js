var Profdata = {

    initialize: function () {
        // var jq = $.noConflict(true);
        $('input[Type="date"]').val(new Date().getToday());
        $.fn.dataTable.ext.errorMode = 'none';
        Profdata.Attachevent();

    },
    Attachevent: function () {

        $("#lanbtnSearchData").click(function () {
            // alert("");
            //
            Profdata.ProfessionReportDetails();
        })
        $("#btncancel").click(function () {
            $("#fdatetxt").val("");
            $("#tdatetxt").val("");
            $("#empcodetxt").val("");
            $("#empnametxt").val("");
        })
    },

    ProfessionReportDetails: function () {
       
        $("#displayprofdetails").show();
        var Code = $("#empcodetxt").val();
        var name = $("#nametxt").val();
        var newrow ={
            ProfCode: Code,
            ProfName: name
        }
        //

        var fnldt = $('#profreport').DataTable({

            "ColumnDefs": [{ "Width": "5%", "targets": 0, "searchable": false, "orderable": false }],
            "order": [[0, 'asc']],
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
           
            "processing": true,
            "serverSide": true,
            "ajax":
            {
                "async": false,
                "cache": false,
                "type": "POST",
                "url": '/GetProfessionReprtDetails',
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
               { "data": "ProfCode" },
               { "data": "ProfName" },
               {"data":"UniCodeName"},
               { "data": "ProfType" }
               //{ "data": "Act_code" }
            ]
        });
     
        $("select option").filter(function () {
           
            //may want to use $.trim in here
            //return $(this).text() == text1;
            if ($(this).text() == "All") {
                var tabledata = $('#profreport').dataTable();
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

