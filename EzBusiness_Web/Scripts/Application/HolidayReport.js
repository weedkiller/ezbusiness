﻿var holidaydata = {

    initialize: function () {
        // var jq = $.noConflict(true);
        $('input[Type="date"]').val(new Date().getToday());
        $.fn.dataTable.ext.errorMode = 'none';
        holidaydata.Attachevent();

    },
    Attachevent: function () {

        $("#lanbtnSearchData").click(function () {
            // alert("");
            //
            holidaydata.HolidayReportDetails();
            $('.dataTables_scrollHead').css('margin-bottom', '0px');
        })
        $("#btncancel").click(function () {
          
            $("#empcodetxt").val("");
           
        })
    },

    HolidayReportDetails: function () {
        
        $("#displayholidetails").show();
        //var fdate = $("#fnlfdatetxt").val();
        //var Tdate = $("#fnltdatetxt").val();
        var HolidayCode = $("#empcodetxt").val();
        //var empname = $("#empnametxt").val();
        var newrow = {
            HRPH001_CODE: HolidayCode
        }
        //
       
        var fnldt = $('#Holidayreport').DataTable({

            "ColumnDefs": [{ "Width": "5%", "targets": 0, "searchable": false, "orderable": false }],
            "order": [[0, 'asc']],
           // "scrollX": true,
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

                     },
                     {
                extend: 'print',                                        
                title: 'Holiday',
                text: 'Print',
                orientation: 'landscape',
                pageSize: 'LEGAL',
                customize: function (win) {
                    $(win.document.body)
                        .css('font-size', '12px');

                    $(win.document.body).find('table')
                        .css('font-size', '12px');
                }

                     }
            ],
           
            "processing": true,
            "serverSide": true,
            "ajax":
            {
                "async": false,
                "cache": false,
                "type": "POST",
                "url": '/GetHolidayDetails',
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
               { "data": "HRPH001_CODE" },
               { "data": "LEAVE_TYPEYCODE" },
               { "data": "Description" },
               {
                   "data": "Dates",
                   "render":function(data)
                   {
                       return (EzdatefrmtRes1(data));
                   }
               }
               
            ]
        });
        
        $("select option").filter(function () {
            
            //may want to use $.trim in here
            //return $(this).text() == text1;
            if ($(this).text() == "All") {
                var tabledata = $('#Holidayreport').dataTable();
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

