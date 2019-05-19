var Haz = {
    initialize: function () {
        $('input[Type="date"]').val(new Date().getToday());
        // var jq = $.noConflict(true);
        $.fn.dataTable.ext.errorMode = 'none';
        Haz.Attachevent();
    },
    Attachevent: function () {
        $("#dcm").hide();
        EzAuthentication("/FFM_HAZ_Master");
        var n = EzAuthenticationBtn("/FFM_HAZ_Master", "ViewIt");
        if (n == 1) {
            Ezsidetbl1("#tblUnits", "#tblUnits tfoot td", true, "#tblUnits thead");
            $('#tblUnits').show();
        } else {
            $('#tblUnits').hide();
        }

        $("#tblcntr1").hide();
        $("#btnAdd").click(function () {
            var n = EzAuthenticationBtn("/FFM_HAZ_Master", "NewIt");
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
        EztableTabEve("#tblcntr1", "[name*='txtCODE']", "[name *= 'txtNAME']", "Please Enter FNMHEAD_CODE", 'T', "");
        // EztableTabEve("#tblcntr1", "[name*='txtNAME']", "[name *= 'txtMASTER_STATUS']", "Please Enter CURRENCY_CODE", 'T', "");

        //  EztableTabEve("#tblcntr1", "[name*='txtMASTER_STATUS']", "[name *= 'txtNOTE']", "Please Enter MASTER_STATUS", 'T', "");

        /*Enter Event*/
        EztableLstEnt("#tblcntr1", "[name*='txtNAME']", "[name *= 'txtCODE']", "T", "");

        /*Add Table Change Event*/
        $("#tblcntr1").on("change", "[name*='txtCODE']", function () {
            var tr = $(this).closest('tr');

            drec = [];
            $('#tblcntr1 tbody tr td:nth-child(1)').each(function () {
                //add item to array
                var ab = $(this).find("[name *= 'txtCODE']").val();
                drec.push(ab);
            });

            drec.splice($.inArray(tr.find("[name *= 'txtCODE']").val(), drec), 1);
            if ($.inArray(tr.find("[name *= 'txtCODE']").val(), drec) >= 0) {
                var dr = tr.find("[name *= 'txtCODE']").val();
                tr.css("background", "red");
                tr.find("[name *= 'txtCODE']").focus();
                EzAlerterrtxt("Already Exist Code '" + dr + "'");
                tr.find("[name *= 'txtCODE']").val('');

            }
            else {
                tr.css("background", "");
                if (tr.is(":last-child")) {
                    tr.clone(true, true).insertAfter(tr);
                    var trLast = $("#tableMetaSettings tr:last");
                    $("<td><button type='button' class='btn btn-danger' name='btnDelete" + counter + "')'><span class='glyphicon glyphicon-remove'></span></button></td>")
                               .appendTo("#tblcntr1 tbody tr:nth-last-child(2)");
                    $(this).closest('tr').next('tr').find("[name*='txtCODE']").val('');
                    trLast.find("[name *= 'txtCODE']").attr({
                        "name": ("txtCODE" + counter)
                    });
                    trLast.find("[name *= 'txtNAME']").attr({
                        "name": ("txtNAME" + counter)
                    });
                    trLast.find("[name *= 'txtdisplaystatus']").attr({
                        "name": ("txtdisplaystatus" + counter)
                    });
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
            abk1.push("[name*='txtCODE']", "[name*='txtNAME']");
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
                FFM_HAZdetailsnew: []
            };
            $("#tblcntr1 tbody tr").each(function (index, item) {
                debugger;
                var CNTR_CODE = $(this).find("[name*='txtCODE']").val();
                var CNTR_NAME = $(this).find("[name*='txtNAME']").val();
                var Displayname = $(this).find("[name*='txtdisplaystatus'] option:selected").val();
                // var MASTER_STATUS = $(this).find("[name*='txtMASTER_STATUS']").val();
                // var NOTE = $(this).find("[name*='txtNOTE']").val();


                if ((CNTR_CODE != "") && (CNTR_NAME != "")) {
                    var FNM_unitDetail = {
                        FFM_HAZ_CODE: CNTR_CODE,
                        NAME: CNTR_NAME,
                        DISPLAY_STATUS: Displayname
                        //MASTER_STATUS:MASTER_STATUS,
                        //Note: NOTE,
                    };
                    Fcur.FFM_HAZdetailsnew.push(FNM_unitDetail);
                }
            });
            var validationResult = ValidateForm(Fcur);
            if (validationResult.formValid) {
                $.post("/FFM_HAZ/SaveFFM_HAZ", Fcur).done(function (response) {
                    if (response.Drecord == null) {

                        response.Drecord = 0;
                        $("#tbldiv").show();
                        location.reload();
                    }
                    $("#tblcntr1 tbody tr").each(function (index, item) {
                        var tr = $(this).closest("tr");

                        var CNTR_CODE = $(this).find("[name*='txtCODE']").val();
                        var CNTR_NAME = $(this).find("[name*='txtNAME']").val();

                        //var MASTER_STATUS = $(this).find("[name*='txtMASTER_STATUS']").val();
                        //var NOTE = $(this).find("[name*='txtNOTE']").val();


                        if (response.Drecord.length > 0) {
                            var ary1 = [];
                            ary1 = response.Drecord;
                            if ($.inArray(CNTR_CODE, ary1) < 0 && CNTR_CODE != '' && CNTR_NAME != '') {
                                $(this).closest('tr').remove();
                                var counter = $("#Counter").val();
                                var firstRow = $('#tblUnits tbody tr:first');

                                var newRow = "<tr><td>" + CNTR_CODE + "</td><td>" + CNTR_NAME + "</td>";

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
                            $("[name*='txtCODE']").val();
                            // $("[name*='txtCURRENCY_CODE']").val();


                            $("#tblcntr1").hide();

                            if (CNTR_CODE != '' && CNTR_NAME != '') {
                                var counter = $("#Counter").val();
                                var firstRow = $('#tblUnits tbody tr:first');
                                var newRow = "<tr><td>" + CNTR_CODE + "</td><td>" + CNTR_NAME + "</td>";
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

            if (Fcur.FFM_HAZdetailsnew.length == 0) {
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
            var n = EzAuthenticationBtn("/FFM_HAZ_Master", "EditIt");
            if (n == 1) {
                var counter = $("#Counter").val();
                var hdnEditMode = $(this).parent().find('input:hidden:first');
                var tr = $(this).closest("tr");

                var index = $(this).attr("name").substring(4);
                var CURRENCY_NAMETd = $(tr).find("td:eq(1)");
                var MASTER_STATUSTd = $(tr).find("td:eq(2)");
                //var NOTETd = $(tr).find("td:eq(3)");



                var editButton = $(this);

                if (hdnEditMode.val() == "true") {
                    debugger;
                    var CURRENCY_NAMEEdit = $(tr).find("[name*='txtNAME']").val().trim();
                    var MASTER_STATUSEdit = $(tr).find("[name*='txtdisplaystatus'] option:selected").val();
                    //$(tr).find("[name*='txtLEAVE_TYPECODE'] option:selected").val();
                    //var NOTEEdit = $(tr).find("[name*='txtNOTE']").val().trim();
                    var CURRENCY_CODEEdit = $(tr).find("td:eq(0)").text().trim();
                    hdnEditMode.val("true");
                    var Fcur = {
                        FFM_HAZ_CODE: CURRENCY_CODEEdit,
                        NAME: CURRENCY_NAMEEdit,
                        DISPLAY_STATUS: MASTER_STATUSEdit,
                        EditFlag: true
                        //MASTER_STATUS: MASTER_STATUSEdit,
                        //Note: NOTEEdit
                    };

                    $.post("/FFM_HAZ/SaveFFM_HAZ", Fcur).done(function (response) {
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
                    var MASTER_STATUS = $(tr).find("td:eq(2)");
                    //var NOTE = $(tr).find("td:eq(3)").text();

                    $('#inpdocname').val(cntr_NAME.trim());
                    //$('#hdnMstatus').val(MASTER_STATUS.trim());
                    //$('#hdnNote').val(NOTE.trim());

                    $('#hldte').val($(tr).find("td:eq(1)").text().trim());
                    $('#hltyp').val(MASTER_STATUS);
                    CURRENCY_NAMETd.html("<input type='text' name='txtNAME" + index + "' value='" + cntr_NAME.trim() + "' />");
                    MASTER_STATUSTd.html("<select class='form-control' id='txtdisplaystatus' name='txtdisplaystatus'> <option value='Y'>YES</option> <option value='N'>NO</option></select>")

                    //MASTER_STATUSTd.html("<input type='text' name='txtdisplaystatus" + index + "' value='" + MASTER_STATUS.trim() + "' />");
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
                            $.getJSON("/DeleteFFM_HAZ", { FFM_HAZ_CODE: CURRENCY_CODE }).done(function (data) {
                                if (data.DeleteFlag) {

                                    if ($('#tblUnits tbody tr').length == 2) {
                                      var firstRow = $('#tblUnits tbody tr:first');
                                      var newRow = "<tr><td valign='top' colspan='4' class='dataTables_empty'>No data available in table</td></tr>";
                                      $(firstRow).after(newRow);
                                      $('.dataTables_info').replaceWith('Showing 0 to 0 of 0 entries');
                                    }
                                    tr.remove();
                                } else {
                                    EzAlertdele(doccode);
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
                    var HRPH001_CODETd = $(tr).find("td:eq(0)");
                    var DateTd = $(tr).find("td:eq(1)");
                    var LEAVE_TYPECODETd = $(tr).find("td:eq(2)");
                    //var DescriptionTd = $(tr).find("td:eq(3)");
                    var DatesEdit = $('#hldte').val();
                    var LEAVE_TYPECODEEdit = $('#hltyp').val();
                    // var DescriptionEdit = $('#hlDesc').val();

                    var hdnEditMode = $(this).parent().find('input:hidden:first');

                    DateTd.html(DatesEdit);
                    LEAVE_TYPECODETd.html(LEAVE_TYPECODEEdit);
                    //  DescriptionTd.html(DescriptionEdit)

                    tr.find("[name^='Edit']").html('<span class="glyphicon glyphicon-pencil"></span>');
                    tr.find("[name^='Edit']").attr('title', 'Edit');


                    $(this).html('<span class="glyphicon glyphicon-trash"></span>')
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