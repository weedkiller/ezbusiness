﻿var ShiftMaster = {

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
 $('.dataTables_scrollHead').css('margin-bottom', '0px');
        })
    },
    ShiftMasterDetails: function () {
       
        $("#displayShiftMaster").show();
        var shiftCode =$("#shiftcodetxt").val();
     
        var newrow = {
            PRSFT001_code: shiftCode,
           
        }
       
        var empdt = $('#ShiftMasterreport').DataTable({

            "ColumnDefs": [{ "Width": "5%", "targets": 0, "searchable": false, "orderable": false }],
            "order": [[0, 'asc']],
           // "scrollX": true,
            "language":
            {
                "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
            },
            "dom":'lBfrtip',
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
                title: 'Shift Master',
                text: 'Print',
                orientation: 'landscape',
                pageSize: 'LEGAL'   ,
                    customize: function ( win ) {
                        $(win.document.body)
                            .css( 'font-size', '12px' );

                        $(win.document.body).find( 'table' )
                            .css( 'font-size', '12px' );
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
                "url": '/GetEmpShiftMasterDetails',
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
               {"data":"PRSFT001_code"},
               { "data": "ShiftName" },
               { "data": "country" },
               { "data": "division" },
               { "data": "StTime" },
               { "data": "EdTime" },
             
            ]
        });
        $("select option").filter(function () {
           
            //may want to use $.trim in here
            //return $(this).text() == text1;
            if ($(this).text() == "All") {
                var tabledata = $('#ShiftMasterreport').dataTable();
                //Get the total rows
                k = tabledata.fnSettings().fnRecordsTotal();
                $(this).val(k);
            }
        });
    }
}