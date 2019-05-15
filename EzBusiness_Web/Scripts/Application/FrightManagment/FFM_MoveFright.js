var move = {
    initialize: function () {
        $('input[Type="date"]').val(new Date().getToday());
        // var jq = $.noConflict(true);
        $.fn.dataTable.ext.errorMode = 'none';
        move.Attachevent();
    },
    Attachevent: function () {
        $("#dcm").hide();
        EzAuthentication("/FFM_MOVEMaster");
        var n = EzAuthenticationBtn("/FFM_MOVEMaster", "ViewIt");
        if (n == 1) {
            Ezsidetbl1("#tblUnits", "#tblUnits tfoot td", true, "#tblUnits thead");
            $('#tblUnits').show();
        } else {
            $('#tblUnits').hide();
        }

        $("#tblcntr1").hide();
        $("#btnAdd").click(function () {
            var n = EzAuthenticationBtn("/FFM_MOVEMaster", "NewIt");
            if (n == 1) {
                $("#tbldiv").hide();
                var abk = [];
                abk.push('#btnAdd', "[name*='Edit']", "[name *= 'Delete']");
                Ezprop(abk, "disabled", true);
                abk = [];
                abk.push('#btnCancel', '#btnSave');
                Ezprop(abk, "disabled", false);
                $("#tblcntr1 tbody tr").css("background", "");
                $("#tblcntr1").show();
                $("#dcm").show();


            }
        });

        var counter = $("#Counter").val();


        /*Code Tab Event*/
        EztableTabEve("#tblcntr1", "[name*='txtMOVE_CODE']", "[name *= 'txtNAME']", "Please Enter FNMHEAD_CODE", 'T', "");


        // EztableTabEve("#tblcntr1", "[name*='txtNAME']", "[name *= 'txtMASTER_STATUS']", "Please Enter CURRENCY_CODE", 'T', "");

        //  EztableTabEve("#tblcntr1", "[name*='txtMASTER_STATUS']", "[name *= 'txtNOTE']", "Please Enter MASTER_STATUS", 'T', "");




        /*Enter Event*/
        EztableLstEnt("#tblcntr1", "[name*='txtNAME']", "[name *= 'txtMOVE_CODE']", "T", "");


        /*Add Table Change Event*/
        $("#tblcntr1").on("change", "[name*='txtMOVE_CODE']", function () {
            var tr = $(this).closest('tr');

            drec = [];
            $('#tblcntr1 tbody tr td:nth-child(1)').each(function () {
                //add item to array
                var ab = $(this).find("[name *= 'txtMOVE_CODE']").val();
                drec.push(ab);
            });

            drec.splice($.inArray(tr.find("[name *= 'txtMOVE_CODE']").val(), drec), 1);

            if ($.inArray(tr.find("[name *= 'txtMOVE_CODE']").val(), drec) >= 0) {
                var dr = tr.find("[name *= 'txtMOVE_CODE']").val();
                tr.css("background", "red");
                tr.find("[name *= 'txtMOVE_CODE']").focus();
                EzAlerterrtxt("Already Exist Code '" + dr + "'");
                tr.find("[name *= 'txtMOVE_CODE']").val('');


            }
            else {
                tr.css("background", "");
                if (tr.is(":last-child")) {
                    tr.clone(true, true).insertAfter(tr);
                    var trLast = $("#tableMetaSettings tr:last");
                    $("<td><button type='button' class='btn btn-danger' name='btnDelete" + counter + "')'><span class='glyphicon glyphicon-remove'></span></button></td>")
                               .appendTo("#tblcntr1 tbody tr:nth-last-child(2)");
                    $(this).closest('tr').next('tr').find("[name*='txtMOVE_CODE']").val('');
                    trLast.find("[name *= 'txtMOVE_CODE']").attr({
                        "name": ("txtMOVE_CODE" + counter)
                    });
                    trLast.find("[name *= 'txtNAME']").attr({
                        "name": ("txtNAME" + counter)
                    });
                    //trLast.find("[name *= 'txtMASTER_STATUS']").attr({
                    //    "name": ("txtMASTER_STATUS" + counter)
                    //});
                    //trLast.find("[name *= 'txtNOTE']").attr({
                    //    "name": ("txtNOTE" + counter)
                    //});



                    trLast.find(":first").text(counter);
                }
            }
            counter++;
        });


        /*Refresh */
        $("#btnCancel").click(function () {
            $("#dcm").hide();
            if ($("#tblcntr1 > tbody > tr").length > 1) {
                $("#tblcntr1 tbody tr td:last-child").remove();
            }
            $("#tblcntr1 tbody").find("tr:gt(0)").remove();

            var abk1 = [];
            abk1.push("[name*='txtMOVE_CODE']", "[name*='txtNAME']");
            Ezsettxtclr(abk1);
            abk1 = [];
            abk1.push("#btnCancel", "#btnSave");
            Ezprop(abk1, "disabled", true);
            abk1 = [];
            abk1.push('#btnAdd', "[name*='Edit']", "[name*='Delete']");
            Ezprop(abk1, "disabled", false);
            $("#tblcntr1").hide();
            $("#tbldiv").show();
        });
        /*Save Unit Table */
        $("#btnSave").click(function () {
            debugger;
            var Fcur = {
                ffmmovedetails: []
            };
            $("#tblcntr1 tbody tr").each(function (index, item) {

                var MOVE_CODE = $(this).find("[name*='txtMOVE_CODE']").val();
                var MOVE_NAME = $(this).find("[name*='txtNAME']").val();

                // var MASTER_STATUS = $(this).find("[name*='txtMASTER_STATUS']").val();
                // var NOTE = $(this).find("[name*='txtNOTE']").val();


                if ((MOVE_CODE != "") && (MOVE_NAME != "")) {
                    var FNM_MOVE_Detail = {
                        FFM_MOVE_CODE: MOVE_CODE,
                        NAME: MOVE_NAME,
                        //MASTER_STATUS:MASTER_STATUS,
                        //Note: NOTE,
                    };
                    Fcur.ffmmovedetails.push(FNM_MOVE_Detail);
                }
            });
            var validationResult = ValidateForm(Fcur);
            if (validationResult.formValid) {
                $.post("/FFM_MOVE/saveFFM_MOVE", Fcur).done(function (response) {
                    if (response.Drecord == null) {

                        response.Drecord = 0;
                        $("#tbldiv").show();
                        location.reload();
                    }
                    $("#tblcntr1 tbody tr").each(function (index, item) {
                        var tr = $(this).closest("tr");

                        var MOVE_CODE = $(this).find("[name*='txtMOVE_CODE']").val();
                        var MOVE_NAME = $(this).find("[name*='txtNAME']").val();

                        //var MASTER_STATUS = $(this).find("[name*='txtMASTER_STATUS']").val();
                        //var NOTE = $(this).find("[name*='txtNOTE']").val();


                        if (response.Drecord.length > 0) {
                            var ary1 = [];
                            ary1 = response.Drecord;
                            if ($.inArray(MOVE_CODE, ary1) < 0 && MOVE_CODE != '' && MOVE_NAME != '') {
                                $(this).closest('tr').remove();
                                var counter = $("#Counter").val();
                                var firstRow = $('#tblUnits tbody tr:first');

                                var newRow = "<tr><td>" + MOVE_CODE + "</td><td>" + MOVE_NAME + "</td>";

                                //newRow += "</td><td><button class='btn btn-primary' name='Edit" + counter + "' disabled>Edit</button>&nbsp;<button class='btn btn-danger' name='DeleteNew" + counter +
                                //    "' disabled>Delete</button><input type='hidden' name='EditMode" + counter + "'  value='false'><input name='item.CmpyCode' type='hidden' value='" + response.CmpyCode +
                                //    "'></td></tr>";
                                newRow += "</td><td><button class='btn btn-primary' name='Edit" + counter + "' disabled><span class='glyphicon glyphicon-pencil'></span></button>&nbsp;<button class='btn btn-danger' name='DeleteNew" + counter +
                                   "' disabled><span class='glyphicon glyphicon-trash'></span></button><input type='hidden' name='EditMode" + counter + "' value='false'><input name='item.CmpyCode' type='hidden' value='" + response.CmpyCode +
                                   "'></td></tr>";
                                $(firstRow).after(newRow);
                            }
                            else if (codeAdd != '') {
                                $(this).closest('tr').css("background", "red");
                            }
                            else {
                                $(this).closest('tr').css("background", "");
                            }
                        }
                        else {
                            $("#tblcntr1 tbody").find("tr:not(:last)").remove();
                            $("[name*='txtCNTR_CODE']").val();
                            // $("[name*='txtCURRENCY_CODE']").val();


                            $("#tblcntr1").hide();

                            if (MOVE_CODE != '' && MOVE_NAME != '') {
                                var counter = $("#Counter").val();
                                var firstRow = $('#tblUnits tbody tr:first');
                                var newRow = "<tr><td>" + MOVE_CODE + "</td><td>" + MOVE_NAME + "</td>";
                                newRow += "</td><td><button class='btn btn-primary' name='Edit" + counter + "' disabled><span class='glyphicon glyphicon-pencil'></span></button>&nbsp;<button class='btn btn-danger' name='DeleteNew" + counter +
                                    "' disabled><span class='glyphicon glyphicon-trash'></span></button><input type='hidden' name='EditMode" + counter + "' value='false'><input name='item.CmpyCode' type='hidden' value='" + response.CmpyCode +
                                    "'></td></tr>";
                                //newRow += "</tr>";
                                $(firstRow).after(newRow);
                            }
                            abk1 = [];
                            abk1.push("#btnCancel", "#btnSave");
                            Ezprop(abk1, "disabled", true);
                            abk1 = [];
                            abk1.push('#btnAdd', "[name*='Edit']", "[name*='Delete']");
                            Ezprop(abk1, "disabled", false);
                            EzAlertSave();
                            $(".dataTables_empty").replaceWith("");
                        }
                    });
                });
            }
            else {
                EzAlerterr();
            }
        });

        function ValidateForm(Fcur) {
            var response = {
                ErrorMessage: "",
                formValid: false
            };

            if (Fcur.ffmmovedetails.length == 0) {
                response.ErrorMessage += "Please Enter atleast One Branch code Details";
            }
            if (response.ErrorMessage.length == 0) {
                response.formValid = true;
            }

            return response;
        }
        $("#tblcntr1").on("click", "[name*='btnDelete']", function () {
            $(this).closest("tr").remove();
        });


        $(document).ajaxError(function (event, jqxhr, settings, thrownError) {
            console.log(thrownError);
        });


        $("#tblUnits").on("click", "[name^='Edit']", function () {
            var n = EzAuthenticationBtn("/FFM_MOVEMaster", "EditIt");
            if (n == 1) {
                var counter = $("#Counter").val();
                var hdnEditMode = $(this).parent().find('input:hidden:first');
                var tr = $(this).closest("tr");

                var index = $(this).attr("name").substring(4);
                var CURRENCY_NAMETd = $(tr).find("td:eq(1)");
                //var MASTER_STATUSTd = $(tr).find("td:eq(2)");
                //var NOTETd = $(tr).find("td:eq(3)");



                var editButton = $(this);

                if (hdnEditMode.val() == "true") {
                    debugger;
                    var CURRENCY_NAMEEdit = $(tr).find("[name*='txtNAME']").val().trim();
                    //var MASTER_STATUSEdit = $(tr).find("[name*='txtMASTER_STATUS']").val().trim();
                    //var NOTEEdit = $(tr).find("[name*='txtNOTE']").val().trim();
                    var CURRENCY_CODEEdit = $(tr).find("td:eq(0)").text().trim();
                    hdnEditMode.val("true");
                    var Fcur = {
                        FFM_MOVE_CODE: CURRENCY_CODEEdit,
                        NAME: CURRENCY_NAMEEdit,
                        EditFlag:true
                        //MASTER_STATUS: MASTER_STATUSEdit,
                        //Note: NOTEEdit
                    };

                    $.post("/FFM_MOVE/saveFFM_MOVE", Fcur).done(function (response) {
                        CURRENCY_NAMETd.text(response.NAME);
                        //MASTER_STATUSTd.text(response.MASTER_STATUS);
                        //NOTETd.text(response.Note);
                        hdnEditMode.val("true");
                        editButton.html('<span class="glyphicon glyphicon-pencil"></span>');
                        editButton.attr('title', 'Edit');
                        tr.find("[name^='Delete']").html('<span class="glyphicon glyphicon-trash"></span>');
                        tr.find("[name^='Delete']").attr('title', 'Delete');
                        tableDis("F");
                        EzAlertUpd(CURRENCY_CODEEdit);
                    });
                    $(document).ajaxError(function (event, jqxhr, settings, thrownError) {
                        console.log(thrownError);
                    });
                } else {
                    debugger;
                    var cntr_CODE = $(tr).find("td:eq(0)").text();
                    var cntr_NAME = $(tr).find("td:eq(1)").text();
                    //var MASTER_STATUS = $(tr).find("td:eq(2)").text();
                    //var NOTE = $(tr).find("td:eq(3)").text();

                    $('#inpdocname').val(cntr_NAME.trim());
                    //$('#hdnMstatus').val(MASTER_STATUS.trim());
                    //$('#hdnNote').val(NOTE.trim());


                    CURRENCY_NAMETd.html("<input type='text' name='txtNAME" + index + "' value='" + cntr_NAME.trim() + "' />");
                    //MASTER_STATUSTd.html("<input type='text' name='txtMASTER_STATUS" + index + "' value='" + MASTER_STATUS.trim() + "' />");
                    //NOTETd.html("<input type='text' name='txtNOTE" + index + "' value='" + NOTE.trim() + "' />");

                    $(this).html('<span class="glyphicon glyphicon-upload" ></span>');
                    $(this).attr('title', 'Update');
                    hdnEditMode.val("true");

                    tableDis("T");
                    $(this).attr("disabled", false);
                    tr.find("[name^='Delete']").prop("disabled", false);

                    tr.find("[name^='Delete']").html('<span class="glyphicon glyphicon-remove"></span>')
                    tr.find("[name^='Delete']").attr('title', 'Cancel');

                }
            }
        });

        $("#tblUnits").on("click", "[name^='Delete']", function () {
            debugger;
            var n = EzAuthenticationBtn("/FMHEAD", "DeleteIt");
            if (n == 1) {
                var tr = $(this).closest("tr");

                var FMHEADCodeTd = $(tr).find("td:eq(0)");
                var hdnMode = $(this).parent().find('input:hidden:first');
                var doccode = "";
                if (hdnMode.val() == "false") {

                    const swalWithBootstrapButtons = Swal.mixin({
                        confirmButtonClass: 'btn btn-success',
                        cancelButtonClass: 'btn btn-danger',
                        buttonsStyling: false,
                    })

                    swalWithBootstrapButtons.fire({
                        title: 'Are you sure?',
                        text: "You won't be able to revert this!",
                        type: 'warning',
                        showCancelButton: true,
                        confirmButtonText: 'Yes, delete it!',
                        cancelButtonText: 'No, cancel!',
                        reverseButtons: true
                    }).then((result) => {
                        if (result.value) {
                            CURRENCY_CODE = $(tr).find("td:eq(0)").text().trim();
                            $.getJSON("/DeleteFFM_CLAUSE", { FFM_CLAUSE_Code: CURRENCY_CODE }).done(function (data) {
                                if (data.DeleteFlag) {

                                    if ($('#tblUnits tbody tr').length == 2) {
                                        var firstRow = $('#tblUnits tbody tr:first');
                                        var newRow = "<tr><td valign='top' colspan='4' class='dataTables_empty'>No data available in table</td></tr>";
                                        $(firstRow).after(newRow);
                                        $('.dataTables_info').replaceWith('Showing 0 to 0 of 0 entries');
                                    }
                                    tr.remove();
                                } else {
                                    EzAlertdele(CURRENCY_CODE);
                                }
                            });
                            swalWithBootstrapButtons.fire(
                              'Deleted!',
                              'Your Code has been deleted.',
                              'success'
                            )

                        } else if (
                            // Read more about handling dismissals
                          result.dismiss === Swal.DismissReason.cancel
                        ) {
                            swalWithBootstrapButtons.fire(
                              'Cancelled',
                              'Your Code is safe :)',
                              'error'
                            )
                        }
                    })

                }
                else {
                    var nameTd = $(tr).find("td:eq(1)");

                    var MasterStatusTd = $(tr).find("td:eq(2)");
                    var NoteTd = $(tr).find("td:eq(3)");

                    var nameEdit = $('#inpdocname').val();

                    var MstatusEdit = $('#hdnMstatus').val();
                    var NoteEdit = $('#hdnNote').val();

                    var hdnEditMode = $(this).parent().find('input:hidden:first');
                    nameTd.html(nameEdit);
                    MasterStatusTd.html(MstatusEdit);
                    NoteTd.html(NoteEdit);
                    tr.find("[name^='Edit']").html('<span class="glyphicon glyphicon-pencil"></span>');
                    tr.find("[name^='Edit']").attr('title', 'Edit');
                    $(this).html('<span class="glyphicon glyphicon-trash"></span>');
                    $(this).attr('title', 'Delete');
                    hdnEditMode.val("false");

                    tableDis("F");
                }
            }
        });


        var k = 0;
        function tableDis(k) {
            if (k == "T") {
                $("#tblUnits tbody tr").find("[name^='Edit']").prop("disabled", true);
                $("#tblUnits tbody tr").find("[name^='Delete']").prop("disabled", true);
                $("#btnAdd").prop('disabled', true);
            }
            else {
                $("#tblUnits tbody tr").find("[name^='Edit']").prop("disabled", false);
                $("#tblUnits tbody tr").find("[name^='Delete']").prop("disabled", false);
                $("#btnAdd").prop('disabled', false);

            }
        }

    }
}