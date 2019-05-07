//var k=-1;
//var ln= "[[10, 25, 50, 100], [10, 25, 50, 100, 200]] "  ;
var EmpBankTrfreport = {

    initialize: function () {

        Ezdteformtcur('#fdatetxt', 'MMMM-YYYY');
        // var jq = $.noConflict(true);
        $.fn.dataTable.ext.errorMode = 'none';
        EmpBankTrfreport.Attachevent();

    },
    Attachevent: function () {
        $("#btnSearchData").click(function () {

            $('select').val('10');
            EmpBankTrfreport.EmpBankTrfreportDetails();

            $('.dataTables_scrollHead').css('margin-bottom', '0px');

        })
       
        $("#btncancel").click(function () {
            //$("#fdatetxt").val("");
            //$("#tdatetxt").val("");
            Ezdteformtcur('#fdatetxt', 'MMMM-YYYY');
        })
    
    },
    EmpBankTrfreportDetails: function () {
        //
        

        var groupColumn = 5;

        var msg = "";
        $("#displayemp").show();
        var fdate = Ezsetdtpkdate($("#fdatetxt").val());       
        var i = 0;
        var newrow = {
            dte: fdate
        }
        msg = EmpBankTrfreport.ValidateReports(newrow)
        if (msg == "") {
            var empdt = $('#EmpBankTrfreport').DataTable({
                "ColumnDefs": [{ "Width": "5%", "targets": 0, "searchable": false, "orderable": false }],
                "order": [[1, 'asc']],
               // "scrollX": true,
                "language":
                {
                    "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
                },
                "dom": 'Blfrtip',
               
                "processing": true,
                "serverSide": true,
                //"stateSave": true,
                "ajax":
                {
                    "async": false,
                    "cache": false,
                    "type": "POST",
                    "url": '/GetEmpBankTrf',
                    "dataType": 'json',
                    "data": newrow,
                    //"contentType": "application/json; charset=utf-8",                     
                },
                "destroy": true,
                "sorting": true,
                "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
                "columns": [
                    //Sr No	PRSPD001_CODE	EMPCODE	EMPNAME	ACCOUNTNO	AMOUNT	BANKCODE	Bank_name	TMONTH	TYEAR	CMPYCODE
                   { "data": "SrNo" },
                   { "data": "PRSPD001_CODE" },
                   { "data": "EMPCODE" },
                   { "data": "EMPNAME" },
                     { "data": "Bank_name" },
                   { "data": "BANKCODE" },
                   { "data": "ACCOUNTNO" },                  
                   { "data": "AMOUNT" },
                                
                                    
                ],
                "drawCallback": function (settings) {
                    var api = this.api();
                    var rows = api.rows({ page: 'current' }).nodes();
                    var last = null;

                    api.column(groupColumn, { page: 'current' }).data().each(function (group, i) {
                        if (last !== group) {
                            $(rows).eq(i).before(
                                '<tr class="group"><td colspan="8">' + group + '</td></tr>'
                            );

                            last = group;
                        }
                    });
                },
                "buttons": [

                         'excel',
                            {
                                extend: 'pdfHtml5',
                                orientation: 'landscape',
                                pageSize: 'LEGAL',
                                exportOptions: {
                                    columns: ':visible:not(.not-export-col)',
                                    grouped_array_index: [5]
                                },

                            },
                            {
                                extend: 'print',
                                title: 'Employee Detail',
                                text: 'Print',
                                orientation: 'landscape',
                                pageSize: 'LEGAL',
                                exportOptions: {
                                    columns: ':visible:not(.not-export-col)',
                                    modifier: { "page": 'current' },
                                    grouped_array_index: [5]
                                },
                                customize: function (win) {
                                    $(win.document.body)
                                        .css('font-size', '12px');

                                    $(win.document.body).find('table')
                                        .css('font-size', '12px');

                                    $(win.document.body).find('h1').css('font-size', '15pt');
                                    $(win.document.body).find('h1').css('text-align', 'center');
                                }

                            }


                ]
            });

            $('#EmpBankTrfreport').DataTable().columns([ 4, 5]).visible(false);

            $("select option").filter(function () {

                //may want to use $.trim in here
                //return $(this).text() == text1;
                if ($(this).text() == "All") {
                    var tabledata = $('#EmpBankTrfreport').dataTable();
                    //Get the total rows
                    k = tabledata.fnSettings().fnRecordsTotal();
                    $(this).val(k);
                }
            });

        }
        else {
            EzAlerterrtxt(msg)
        }
    },
    

    ValidateReports: function (newrow) {
        var msg = "";
        if (newrow.Fdate == "") {
            msg = "Month , Year should not be empty";
        }
      
        return msg;
    }
}

