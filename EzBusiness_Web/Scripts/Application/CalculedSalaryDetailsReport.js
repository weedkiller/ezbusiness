var salr = {
    initialize:function()
    {
        $('input[Type="date"]').val(new Date().getToday());
        // var jq = $.noConflict(true);
        $.fn.dataTable.ext.errorMode = 'none';
        salr.Attachevent();
    },
    Attachevent:function()
    {
        EzdtePkMMyy('#DateINMonth');
        var dt = $('#DateINMonth').val();
        var currdat = $('#DateINMonth').val();
        $('.selectpicker').selectpicker('refresh');

        $(".datepicker").on("dp.show", function (e) {
            $(e.target).data("DateTimePicker").viewMode("months");
        });
        $('#DateINMonth').on('dp.change', function (event) {
            
            dt = $("#DateINMonth").val();
            currdat = $("#DateINMonth").val();
            dt = dt + "-" + '01';
            $('#CurrentDate').val(dt);
        });

        $('#Division').change(function () {
            
            var divcode = $('#Division option:selected').val();
            $.get("SalaryProcess/GetDepartmentList", { divcode: divcode }).done(function (response) {

                $('#DepCode').empty();
                var ary = [];
                ary = response;
                for (var i = 0; i < ary.length; i++) {
                    $('#DepCode').append('<option value="' + ary[i].Value + '" selected="">' + ary[i].Text + '</option>');
                }

                $('#DepCode').val(0);

                $('.selectpicker').selectpicker('refresh');
            });
        });

        $("#btncalculate").click(function () {
            

            var currmonthyear = dt;
            var CurrentDate = currmonthyear;
            var divcode = $('#Division option:selected').val();
            var Deptcode = $('#DepCode option:selected').val();
            var VisaLocation1 = $('#VisaLocation option:selected').val();
            $('#salrcontainer').show();
            
            var newrow =
               {
                   Process_Date: currmonthyear,
                   Division: divcode,
                   DepCode: Deptcode,
                   VisaLocation: VisaLocation1
               }
            var validationResult = salr.ValidateForm(divcode);
            if (validationResult.ErrorMessage == "") {
                var t = $('#tableslryDetails').DataTable({
                    "ColumnDefs": [{ "width": "10%", "searchable": false, "orderable": false }],
                    "order": [[1, 'asc']],
                    //"scrollY": true,
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
                                   title: 'EZ-Technology'+'\n'+'Office No.304, Al Ain Tower, Hamdan Street,'+'\n'+' Abu Dhabi, UAE, P.O. Box 43673.'+'\n'+' Tel : +971 2 672 1405 / Fax : +971 2 6725594.',
                                   orientation: 'landscape',
                                   pageSize: 'A3',
                                   exportOptions: {
                                      stripNewlines:false
                                   },
                                   customize: function (doc) {
                                       doc.styles.title = {
                                          // color: 'red',
                                           fontSize: '15',
                                           //background: 'blue',
                                           alignment: 'center'
                                       }
                                   }
                               },
                               {
                                   extend: 'print',
                                   title: 'Salary Report',
                                   text: 'Print',
                                   orientation: 'landscape',
                                   pageSize: 'A4',
                                   exportOptions: {
                                       columns: ['ALL', ':visible']
                                   },
                                   //customize: function (win) {
                                   //    $(win.document.body)
                                   //        .css('font-size', '6px');

                                   //    $(win.document.body).find('table')
                                   //        .css('font-size', '6px');
                                   //}
                               }
                    ],
                    "autoWidth": true,
                    "processing": true,
                    "serverSide": true,
                    "ajax":
                    {
                        "async": false,
                        "cache": false,
                        "type": "POST",
                        "url": '/GetSalaryReportDetails',
                        "dataType": "json",
                        "data": newrow,
                    },
                    "destroy": true,
                    "columns": [
                                 //{
                                 //   "className": 'control',
                                 //   "orderable": false,
                                 //   "data": null,
                                 //   "defaultContent": '',
                                 //},
                                 { "data": "srno" },
                                 { "data": "Empcode" },
                                 { "data": "Empname" },                      
                                 { "data": "Division" },
                                 { "data": "DepCode" },
                                 { "data": "VisaLocation" },
                                 { "data": "Worked_Days" },
                                 { "data": "Absent" },
                                 { "data": "nothrs" },
                                 { "data": "not_rate_perhr" },
                                 { "data": "NOTAmt" },
                                 { "data": "hothrs" },
                                 { "data": "hot_rate_perhr" },
                                 { "data": "HOTAmt" },
                                 { "data": "wothrs" },
                                 { "data": "wot_rate_perhr" },
                                 { "data": "WOTAmt" },
                                 { "data": "extraOThrs" },
                                 { "data": "ExtraOT_rate_perhr" },
                                 { "data": "ExtraOTAmt" },
                                 { "data": "adn_amount" },
                                 { "data": "loan_amt" },
                                 { "data": "NetSalary" },
                             ]
                   });
                $("select option").filter(function () {
                    if ($(this).text() == "All") {
                        var tabledata = $('#tableslryDetails').dataTable();
                        //Get the total rows
                        k = tabledata.fnSettings().fnRecordsTotal();
                        $(this).val(k);
                    }
                });

                if ($('#tableslryDetails tbody tr').length > 0) {
                    $("#btnactualsal,#btnotdetails").removeAttr("disabled", "disabled");

                }
                $('.dataTables_scrollHead').css('margin-bottom', '0px');
            }
            else {
                EzAlerterrtxt("Select Division");
            }

        });
    },
    ValidateForm:function(divcode) {
    
    var response = {
        ErrorMessage: "",

    };
    //if (employeemaster.IsEditMode == false) {
    if (divcode=="0") {
        response.ErrorMessage += "Select Division";
    }

    return response;
}
}