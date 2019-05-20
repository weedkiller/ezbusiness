var voyage = {
    initialize: function () {
        $('input[Type="date"]').val(new Date().getToday());
        $.fn.dataTable.ext.errorMode = 'none';
        voyage.Attachevent();
        voyage.GetVessalCodeLis();
    },
    Attachevent: function () {
        debugger;
        $('body').on('focusin', '.datepicker', function () {
            $('.datepicker').datetimepicker({
                // defaultDate: new Date(),
                format: 'DD/MM/YYYY',
                showClose: true,
                showClear: true,
            });

        });

        EzdtePk('#txtETA,#txtETAB,#txtETAD');

        $("#dcm").hide();
        $("#displaytabledata").show();
        EzAuthentication("/VoyaGEDataMaster");
        var n = EzAuthenticationBtn("/VoyaGEDataMaster", "ViewIt");
        if (n == 1) {
            Ezsidetbl1("#tblUnits", "#tblUnits tfoot td", true, "#tblUnits thead");
            $('#tblUnits').show();
        } else {
            $('#tblUnits').hide();
        }
      
      
     //   $("#tblcntr1").hide();
        $("#btnAdd").click(function () {
          
            var n = EzAuthenticationBtn("/VoyaGEDataMaster", "NewIt");
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
                $("#showAddpanel").show();
                $("#tbldisplay").show();
                $("#displaytabledata").hide();
            }
        });

        var counter = $("#Counter").val();

        /*Code Tab Event*/
        EztableTabEve("#tblcntr1", "[name*='txtCODE']", "[name *= 'txtNAME']", "Please Enter FNMHEAD_CODE", 'T', "");

        EztableLstEnt("#tblcntr1", "[name*='txtNAME']", "[name *= 'txtCODE']", "T", "");

        $("#tblcntr1").on("change", "[name*='txtRotation']", function () {
            debugger;
          
            var tr = $(this).closest('tr');

            drec = [];
            $('#tblcntr1 tbody tr td:nth-child(1)').each(function () {
                //add item to array
                var ab = $(this).find("[name *= 'txtRotation']").val();
                drec.push(ab);
            });

            drec.splice($.inArray(tr.find("[name *= 'txtRotation']").val(), drec), 1);
            if ($.inArray(tr.find("[name *= 'txtRotation']").val(), drec) >= 0) {
                var dr = tr.find("[name *= 'txtRotation']").val();
                tr.css("background", "red");
                tr.find("[name *= 'txtRotation']").focus();
                EzAlerterrtxt("Already Exist Code '" + dr + "'");
                tr.find("[name *= 'txtRotation']").val('');


            }
            else {
                tr.css("background", "");
                if (tr.is(":last-child")) {
                    tr.clone(true, true).insertAfter(tr);
                    var trLast = $("#tableMetaSettings tr:last");
                    $("<td><button type='button' class='btn btn-danger' name='btnDelete" + counter + "')'><span class='glyphicon glyphicon-remove'></span></button></td>")
                               .appendTo("#tblcntr1 tbody tr:nth-last-child(2)");
                    $(this).closest('tr').next('tr').find("[name*='txtsrno']").val('');
                    $(this).closest('tr').next('tr').find("[name*='txtRotation']").val('');
                    $(this).closest('tr').next('tr').find("[name*='txtport']").val('');
                    trLast.find("[name *= 'txtsrno']").attr({
                        "name": ("txtsrno" + counter)
                    });
                    trLast.find("[name *= 'txtRotation']").attr({
                        "name": ("txtRotation" + counter)
                    });
                    trLast.find("[name *= 'txtport']").attr({
                        "name": ("txtport" + counter)
                    });
                    trLast.find("[name *= 'txtETA']").attr({
                        "name": ("txtETA" + counter)
                    });
                    trLast.find("[name *= 'txtETAB']").attr({
                        "name": ("txtETAB" + counter)
                    });
                    trLast.find("[name *= 'txtETD']").attr({
                        "name": ("txtETD" + counter)
                    });
                    trLast.find("[name *= 'txtPortStayhrs']").attr({
                        "name": ("txtPortStayhrs" + counter)
                    });
                    trLast.find("[name *= 'txtSailinghrs']").attr({
                        "name": ("txtSailinghrs" + counter)
                    });

                    trLast.find(":first").text(counter);
                }
            }
            counter++;
        });
        /* Edit Data */

        $(document).on("click", "#tblUnits tbody tr", function () {
            debugger
            EzbtnEditAcVis();
            var operationMode ="Edit";
            if (operationMode == "Edit") {
                $("#POList > tbody").children().removeClass("active");
                $(this).addClass("active");
                var VyogCode = $(this).find("#hdnFNMBRANCH_CODE").val(); 
               // var DivisionCode = $(this).find("#hdnDivisionCode").val();
                $.get("EditVoyagMaster", { VyogCode: VyogCode }).done(function (response) {
                    $("#POContainer").show();
                    $("#showAddpanel").show();
                    //  $("#btnDelete").prop("disabled", false);
                    $("#btnDelete").css("visibility", "");
                });
            }

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
            //$("#tblcntr1").hide();
            //$("#tbldiv").show();
            $("#showAddpanel").hide();
            $("#tbldisplay").hide();
            $("#displaytabledata").show();
        });
        /*Save Unit Table */
        $("#btnSave").click(function () {
            debugger;
            var Fcur = {
                FFM_VESSEL_CODE: $("#ddlvessalcode Option:selected").val(),
                NAME: $("#txtvessalname").val(),
                FFM_VOYAGE01_CODE: $("#txtVoyageCode").val(),
                DISPLAY_STATUS: $("#ddlstatus").val(),
                newdetails: []
            };
            $("#tblcntr1 tbody tr").each(function (index, item) {
                debugger;
                var SNO = $(this).find("[name*='txtsrno']").val();
                var ROTATION = $(this).find("[name*='txtRotation']").val();
                var PORT = $(this).find("[name*='txtport']").val();
                var ETA =Ezsetdtpkdate( $(this).find("[name*='txtETA']").val());
                var ETB =Ezsetdtpkdate( $(this).find("[name*='txtETAB']").val());
                var ETD =Ezsetdtpkdate( $(this).find("[name*='txtETD']").val());
                var PortStayhrs =$(this).find("[name*='txtPortStayhrs']").val();
                var Sailinghrs = $(this).find("[name*='txtSailinghrs']").val();
                // var MASTER_STATUS = $(this).find("[name*='txtMASTER_STATUS']").val();
                // var NOTE = $(this).find("[name*='txtNOTE']").val();
                if ((ROTATION != "")) {
                    var FNM_unitDetail = {
                       
                        SNO: SNO,
                        ROTATION:ROTATION,
                        PORT:PORT,
                        ETA:ETA,
                        ETB:ETB,
                        ETD:ETD,
                        PortStayHours: PortStayhrs,
                        SailingHrs: Sailinghrs
                        //Note:NOTE,
                    };
                    Fcur.newdetails.push(FNM_unitDetail);
                }
            });
            var validationResult = ValidateForm(Fcur);
            if (validationResult.formValid) {
                $.post("/FFM_VoYAGE/SaveFFM_Voyage", Fcur).done(function (response){
                    if (response.Drecord == null) {
                        response.Drecord = 0;
                        $("#tbldiv").show();
                        location.reload();
                    }
                    //$("#tblcntr1 tbody tr").each(function (index, item) {
                    //    var tr = $(this).closest("tr");

                    //    var CNTR_CODE = $(this).find("[name*='txtCODE']").val();
                    //    var CNTR_NAME = $(this).find("[name*='txtNAME']").val();

                    //    //var MASTER_STATUS = $(this).find("[name*='txtMASTER_STATUS']").val();
                    //    //var NOTE = $(this).find("[name*='txtNOTE']").val();


                    //    if (response.Drecord.length > 0) {
                    //        var ary1 = [];
                    //        ary1 = response.Drecord;
                    //        if ($.inArray(CNTR_CODE, ary1) < 0 && CNTR_CODE != '' && CNTR_NAME != '') {
                    //            $(this).closest('tr').remove();
                    //            var counter = $("#Counter").val();
                    //            var firstRow = $('#tblUnits tbody tr:first');

                    //            var newRow = "<tr><td>" + CNTR_CODE + "</td><td>" + CNTR_NAME + "</td>";

                    //            //newRow += "</td><td><button class='btn btn-primary' name='Edit" + counter + "' disabled>Edit</button>&nbsp;<button class='btn btn-danger' name='DeleteNew" + counter +
                    //            //    "' disabled>Delete</button><input type='hidden' name='EditMode" + counter + "'  value='false'><input name='item.CmpyCode' type='hidden' value='" + response.CmpyCode +
                    //            //    "'></td></tr>";
                    //            newRow += "</td><td><button class='btn btn-primary' name='Edit" + counter + "' disabled><span class='glyphicon glyphicon-pencil'></span></button>&nbsp;<button class='btn btn-danger' name='DeleteNew" + counter +
                    //               "' disabled><span class='glyphicon glyphicon-trash'></span></button><input type='hidden' name='EditMode" + counter + "' value='false'><input name='item.CmpyCode' type='hidden' value='" + response.CmpyCode +
                    //               "'></td></tr>";
                    //            $(firstRow).after(newRow);
                    //        }
                    //        else if (codeAdd != '') {
                    //            $(this).closest('tr').css("background", "red");
                    //        }
                    //        else {
                    //            $(this).closest('tr').css("background", "");
                    //        }
                    //    }
                    //    else {
                    //        $("#tblcntr1 tbody").find("tr:not(:last)").remove();
                    //        $("[name*='txtCODE']").val();
                    //        // $("[name*='txtCURRENCY_CODE']").val();


                    //        $("#tblcntr1").hide();

                    //        if (CNTR_CODE != '' && CNTR_NAME != '') {
                    //            var counter = $("#Counter").val();
                    //            var firstRow = $('#tblUnits tbody tr:first');
                    //            var newRow = "<tr><td>" + CNTR_CODE + "</td><td>" + CNTR_NAME + "</td>";
                    //            newRow += "</td><td><button class='btn btn-primary' name='Edit" + counter + "' disabled><span class='glyphicon glyphicon-pencil'></span></button>&nbsp;<button class='btn btn-danger' name='DeleteNew" + counter +
                    //                "' disabled><span class='glyphicon glyphicon-trash'></span></button><input type='hidden' name='EditMode" + counter + "' value='false'><input name='item.CmpyCode' type='hidden' value='" + response.CmpyCode +
                    //                "'></td></tr>";
                    //            //newRow += "</tr>";
                    //            $(firstRow).after(newRow);
                    //        }
                    //        abk1 = [];
                    //        abk1.push("#btnCancel", "#btnSave");
                    //        Ezprop(abk1, "disabled", true);
                    //        abk1 = [];
                    //        abk1.push('#btnAdd', "[name*='Edit']", "[name*='Delete']");
                    //        Ezprop(abk1, "disabled", false);
                    //        EzAlertSave();
                    //        $(".dataTables_empty").replaceWith("");
                    //    }
                    //});
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

            if (Fcur.newdetails.length == 0) {
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

    },
    GetVessalCodeLis: function()
    {
        debugger;
                $('#ddlvessalcode').empty();
                $.get("/GetVessalCode", { CmpyCode: $("#CmpyCode").val() }).done(function (response) {
                    debugger
                    $('#ddlvessalcode').empty();
                  //  $("[name*='ddlvessalcode']").append('<option value="0" selected="">--Select--</option>');
                    var ary = [];
                    ary = response;        
                    for (var i = 0; i < ary.length; i++) {
                        $("[name*='ddlvessalcode']").append('<option value="' + ary[i].Value + '" selected="">' + ary[i].Text + '</option>');
                    }
                    $("[name*='ddlvessalcode']").val(0);
                });
    }
}