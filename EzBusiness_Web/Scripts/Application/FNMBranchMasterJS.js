var FNMB = {

    initialize: function () {
        // var jq = $.noConflict(true);
        //$('input[Type="date"]').val(new Date().getToday());
        $.fn.dataTable.ext.errorMode = 'none';
        FNMB.Attachevent();

    },
    Attachevent: function () {

        $("#btnNew").click(function () {        
            debugger;
            $("#showlist").hide();
            $("#shownewbtn,#btnSave,#btnCancel,#btnDelete,#btnPrint").show();
            $("#btnNew").hide();
        })

        $("#btnCancel").click(function () {          
            debugger;
            $("#showlist").show();
            $("#shownewbtn,#btnSave,#btnCancel,#btnDelete,#btnPrint").hide();
            $("#btnNew").show();
        })

        $("#btnDelete").click(function () {
            debugger;
            $("#showlist").show();
            $("#shownewbtn,#btnSave,#btnCancel,#btnDelete,#btnPrint").hide();
            $("#btnNew").show();
            FNMB.DeleteFNMBranch();
        })

        $("#btnSave").click(function () {
            debugger;
            var n = EzAuthenticationBtn("/FNMBranch", "EditIt");
            $("#editshow").hide();
            var opMode = "Add";

            if (opMode == "Add") {
                // Code for Adding MainTable
                var FNMBranch = {
                    EditFlag: false,
                    FNMBRANCH_CODE: $("#branchcode").val(),
                    PRINTNAME: $("#PrintName").val(),
                    ADDRESS: $("#branchcode").val(),
                    EMAIL: $("#Email").val(),
                    WEBSITE: $("#WebSitetxt").val(),
                    MOBILE: $("#mobiletxt").val(),
                    CURRENCY: $("#Currencytxt").val(),
                    COUNTRY: $("#Countrytxt").val(),
                    DESCRIPTION:$("#Descriptiontxt").val(),
                    STATE: $("#Addresstxt").val(), 
                };
                //var validationResult =FNMB.ValidateForm(FNMBranch);
                //if (validationResult.formValid){                  
                    $.post("/SaveFNMBranch", FNMBranch).done(function (response) {
                        if (response.SaveFlag && !response.ErrorMessage.length > 0) {
                           // EzbtnsaveAcVis("#DRContainer");
                            EzAlertSave();

                        } else {
                            // Ezerrormsg("#ErrorMessage", validationResult.ErrorMessage);
                            EzAlerterrtxt(response.ErrorMessage);
                        }
                    });
                
               // }
            //    else {
            //    //Ezerrormsg("#ErrorMessage", validationResult.ErrorMessage);
            //    EzAlerterrtxt(validationResult.ErrorMessage);
            //}
            } else if (opMode == "Edit" && n == 1) {
                // Code for Adding Purchase order
                var dutyResume = {
                    EditFlag: true,
                    PRDR001_CODE: $("[name*='PRDR001_CODE']").val(),
                    Cmpycode: $("[name*='Cmpycode']").val(),
                    EmpCode: $("[name*='EmpCode'] option:selected").val(),
                    ResumeDate: Ezsetdtpkdate($("[name*='ResumeDate1']").val()),
                    PRLR001_CODE: $("[name*='PRLR001_CODE']").val(),
                    EndDate: Ezsetdtpkdate($("[name*='EndDate1']").val()),
                    StartDate: Ezsetdtpkdate($("[name*='StartDate1']").val()),
                    country: 0,
                    division: 0,
                    PRLS001_CODE: 0,
                    Approve_Days_in_Half: $("[name*='Approve_Days_in_Half']").val(),
                    Approve_Days_in_full: $("[name*='Approve_Days_in_full']").val(),
                    Excess_Days_plus_minus: $("[name*='Excess_Days_plus_minus']").val(),
                    Approve_Days: $("[name*='Approve_Days']").val(),
                    Duty_Rm_type: $("[name*='Duty_Rm_type']").val(),
                    Actual_Leave_Type: $("[name*='Actual_Leave_Type']").val(),
                    oldLeavedays: $('#oldLeavedays').val()

                };



                var validationResult =FNMB.ValidateForm(dutyResume);
                if (validationResult.formValid) {
                    k = EzSalrProcCondiont($("#EmpCode option:selected").val(), date1);
                    if (k == 1) {
                        $.post("/SaveDrs", dutyResume).done(function (response) {
                            if (response.SaveFlag && !response.ErrorMessage.length > 0) {

                                //EzbtnsaveAcVis("#DRContainer");
                                EzAlertSave();
                                $("#DRContainer").html(drHtml);
                                //GetDrs();
                                // window.location = '/DutyResume'

                            } else {
                                //  Ezerrormsg("#ErrorMessage", validationResult.ErrorMessage);
                                EzAlerterrtxt(response.ErrorMessage);
                            }
                        });
                    }
                } else {
                    //Ezerrormsg("#ErrorMessage", validationResult.ErrorMessage);
                    EzAlerterrtxt(validationResult.ErrorMessage);
                }
            }
        })

        $(document).on("click", "#DRList tbody tr", function () {
            debugger;
            EzbtnEditAcVis();
            var operationMode = $("#hdnOperationMode").val();
            if (operationMode == "Edit") {
                $("#DRList > tbody").children().removeClass("active");
                $(this).addClass("active");
               // var Cmpycode = $(this).find("#hdnCmpycode").val();
                var branchCode = $(this).find("#hdnFNMBRANCH_CODE").val();
                $.get("EditFNMBranch", { branchCode: branchCode }).done(function (response) {
                  $("#showlist").hide();
                  $("#shownewbtn,#btnSave,#btnCancel,#btnDelete,#btnPrint").show();
                  $("#btnNew").hide();
                    $("#branchcode").val(response[0].FNMBRANCH_CODE),
                  $("#PrintName").val(response[0].PRINTNAME),
                 // $("#branchcode").val(response.),
                  $("#Email").val(response[0].EMAIL),
                  $("#WebSitetxt").val(response[0].WEBSITE),
                  $("#mobiletxt").val(response[0].MOBILE),
                  $("#Currencytxt").val(response[0].CURRENCY),
                  $("#Countrytxt").val(response[0].COUNTRY),
                  $("#Statetxt").val(response[0].STATE),
                  $("#Descriptiontxt").val(response[0].DESCRIPTION),
                  $("#Addresstxt").val(response[0].ADDRESS)
                });
            }
        });

    },
    ValidateForm: function (FNMBranch) {
            debugger;
var response = {
    ErrorMessage: "",
    formValid: false
};
           
if (FNMBranch.EditFlag == false) {
    if (FNMBranch.FNMBRANCH_CODE =="") {
        response.ErrorMessage += "Sanctioned Code ,";
    }
} else if (FNMBranch.EditFlag == true) {
    if (FNMBranch.FNMBRANCH_CODE =="") {
        response.ErrorMessage += "Sanctioned Code ,";
    }
   
}
//if (dutyResume.EmpCode == '0') {
//    response.ErrorMessage += "Employee Name ,";
//}


return response;
    },

    DeleteFNMBranch:function()
    {
        debugger;
        var n = EzAuthenticationBtn("/FNMBranch", "DeleteIt");
       

     
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
                    var branchCode = $("#branchcode").val();
                   // var EmpCode = $("[name*='EmpCode']").val();
                    $.getJSON("/DeleteFNMBranch", { branchCode: branchCode }).done(function (data) {
                        if (data.DeleteFlag) {
                            //EzbtnsaveAcVis("#DRContainer");                                 
                            //$("#DRContainer").html(drHtml);
                            //GetDrs();
                            window.location = '/Branch_Master'
                         
                            //$("#btnCancel").trigger("click");
                        } else {
                            EzAlertdele(branchCode);
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
}