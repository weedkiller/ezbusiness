//NGP

function ezValidateNumbers(tableid, ids) {
    $(tableid).on("keydown", ids, function (e) {
        var keycode = event.which;
        if (!(event.shiftKey == false && (keycode == 46 || keycode == 8 || keycode == 37 || keycode == 39 || (keycode >= 48 && keycode <= 57)))) {
            event.preventDefault();
        }
        $(ids).focus();
    });
}


function EzHeadTxtvalid(ide, tbl, tblid, errmsg, typH,typ) {
    debugger;
    if ($(ide).val() == typH) {
        alert(errmsg);
        var trLast1 = $(tbl);
        trLast1.find(tblid).val(typ);
        $(ide).focus();       
        return true;
    }
}

function EzAuthentication(Rpath) {
    debugger;
    $.getJSON("/AuthCheck", { rpath1: Rpath }).done(function (data) {
        if (data.Urights == false) {
            Swal.queue([{
                type: 'error',
                title: 'Oops...',
                text: 'User Not Authenticate!',
                allowOutsideClick: false,
                showLoaderOnConfirm: true,
                preConfirm: () => {
                    return window.location.href = "/Index";
                }
            }])
        }              
    });

}

function EzAuthenticationBtn(Rpath, btnR) {
    
    var a = 0;
     $.ajax({
         url: "/GetUserRightAuth",
         dataType: 'json',
         async: false,
         data: { navurl:Rpath },
         success: function (data) {            
             if (btnR == "SelAll") {
                 a = data[0].SelAll;
             } else if (btnR == "NewIt") {
                 a = data[0].NewIt;
             } else if (btnR == "ViewIt") {
                 a = data[0].ViewIt;
             } else if (btnR == "EditIt") {
                 a = data[0].EditIt;
             } else if (btnR == "PrintIt") {
                 a = data[0].PrintIt;
             } else if (btnR == "DeleteIt") {
                 a = data[0].DeleteIt;
             }
              if (a == 0) {
                  Swal.queue([{
                      type: 'error',
                      title: 'Oops...',
                      text: 'No Right granted for this ' + data[0].user_name.toUpperCase() + '  user  !',
                      allowOutsideClick: false,
                      showLoaderOnConfirm: true,
                  }])
              }                                   
         }
     });

     return a;
}

//EmailValidation
function ValidateEmail(email) {
    var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    return expr.test(email);
}
var EzmonthNames = ["January", "February", "March", "April", "May", "June",
"July", "August", "September", "October", "November", "December"];
// Type Number Zero
function Ezsetzerotxt() {
    $('input[Type="Number"]').val("0.00");
    
    $("input[Type='Number']").click(function () {
        $(this).select();
    });

    $("input[type='Number']").on("click", function () {
        $(this).select();
    });
}

function EzsetNtxt(Ideary) {
    var n = Ideary.length;
    while (n > 0) {
        $(Ideary[n - 1]).val("N");
        n--;
    }
}

//Set Date Text
function EzsetDatetxt() {
    debugger;
    $('input[Type="date"]').val(new Date().getToday());
}

//Set Today Date
function EzsetTodayDte(Ideary) {
    debugger;
    var n = Ideary.length;
    while (n > 0) {
        $(Ideary[n - 1]).val(new Date().getToday());
        n--;
    }
}
Date.prototype.getToday = function () {
    var now = new Date();
    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);

    var today = now.getFullYear() + "-" + (month) + "-" + (day);
    return today;
}


//set Readonly Prop
function EzReadonlyT(Ideary) {
    var n = Ideary.length;
    while (n > 0) {
        $(Ideary[n - 1]).attr("Readonly", true);
        n--;
    }
}
function EzReadonlyF(Ideary) {
    var n = Ideary.length;
    while (n > 0) {
        $(Ideary[n - 1]).attr("Readonly", false);
        n--;
    }
}
//New Entry Check
function EzcheckedFn(Idinp, Idnme) {
    debugger;
    $(Idinp).change(function () {
        if ($(Idnme).is(":checked") == true) {
            $(Idinp).val("Y");
        }
        else {
            $(Idinp).val("N");
        }
    });
}

function EzcheckedFnD(Idinp, Idnme, Idtxt) {
    debugger;
    $(Idinp).change(function () {
        if ($(Idnme).is(":checked") == true) {
            $(Idinp).val("Y");
            $(Idtxt).attr("disabled", false);
        }
        else {
            $(Idinp).val("N");
            $(Idtxt).attr("disabled", true);
        }
    });
}
function EzcheckedFnS(Idinp, Idnme, Idtxt) {
    debugger;
    $(Idinp).change(function () {
        if ($(Idnme).is(":checked") == true) {
            $(Idinp).val("Y");
            $(Idtxt).show();
        }
        else {
            $(Idinp).val("N");
            $(Idtxt).hide();
        }
    });
}

//Edit Entry Check
function EzcheckedFnE(Idinp, Idnme) {
    $(Idinp).change(function () {
        if ($(Idinp).val() == "Y") {
            $(Idinp).val("N");
            $(Idnme).removeAttr("checked", "checked");
        }
        else {
            $(Idinp).val("Y");
            $(Idnme).attr("checked", "checked");
        }
    });
}
function EzcheckedFnES(Idinp, Idnme, Idtxt) {
    $(Idinp).change(function () {

        if ($(Idinp).val() == "Y") {
            $(Idinp).val("N");
            $(Idnme).removeAttr("checked", "checked");
            $(Idtxt).hide();
        }
        else {
            $(Idinp).val("Y");
            $(Idnme).attr("checked", "checked");
            $(Idtxt).show();
        }
    });
}
function EzcheckedFnED(Idinp, Idnme, Idtxt) {
    debugger;
    $(Idinp).change(function () {
        debugger;
        if ($(Idinp).val() == "Y") {
            $(Idinp).val("N");
            $(Idnme).removeAttr("checked", "checked");
            $(Idtxt).attr("disabled", true);
        }
        else {
            $(Idinp).val("Y");
            $(Idnme).attr("checked", "checked");
            $(Idtxt).attr("disabled", false);
        }
    });
}
//Retrive Entry Check
function EzcheckedFnEdit(Idinp, Idnme, Idhid) {
    debugger;
    if ($(Idhid).val() == "Y") {
        debugger;
        $(Idinp).val("Y");
        $(Idnme).attr("checked", "checked");

    }
    else {
        $(Idinp).val("N");
        $(Idnme).removeAttr("checked", "checked");
    }
}
function EzcheckedFnEditS(Idinp, Idnme, Idhid, Idtxt) {
    if ($(Idhid).val() == "Y") {
        $(Idinp).val("Y");
        $(Idnme).attr("checked", "checked");
        $(Idtxt).show();
    }
    else {
        $(Idinp).val("N");
        $(Idnme).removeAttr("checked", "checked");
        $(Idtxt).hide();
    }
}
function EzcheckedFnEditD(Idinp, Idnme, Idhid, Idtxt) {
    debugger;
    if ($(Idhid).val() == "Y") {
        $(Idinp).val("Y");
        $(Idnme).attr("checked", "checked");
        $(Idtxt).attr("disabled", false);
    }
    else {
        $(Idinp).val("N");
        $(Idnme).removeAttr("checked", "checked");
        $(Idtxt).attr("disabled", true);
    }
}
//New  Button
function EzbtnNewAc() {
    $("#btnEdit").prop("disabled", true);
    $("#btnDelete").prop("disabled", true);
    $("#hdnOperationMode").val("Add");
    $("#btnSave").prop("disabled", false);
    //$("#POListContainer1").hide();
}
//Edit  Button
function EzbtnEditAc() {
    $("#btnNew").prop("disabled", true);
    $("#hdnOperationMode").val("Edit");
    $("#btnSave").prop("disabled", false);
    // $("#POListContainer1").show();
}
//Cancel  Button
function EzbtnCancelAc() {
    $("#btnNew").prop("disabled", false);
    $("#btnEdit").prop("disabled", false);
    $("#btnDelete").prop("disabled", true);
    $("#hdnOperationMode").val("");
    $("#btnSave").prop("disabled", true);
    $("#ErrorMessage").text('');
    //$("#POListContainer1").hide();
}
//Save & Modify  Button
function EzbtnsaveAc(Idsucc) {
    $(Idsucc).html("<div class='row'><div class='col-lg-12 col-sm-12'><div class='alert alert-danger'><strong>Saved Successfully</strong></div></div></div>");
    $("#btnEdit").prop("disabled", false);
    $("#btnDelete").prop("disabled", true);
    $("#btnNew").prop("disabled", false);
    $("#btnSave").prop("disabled", true);
    $("#hdnOperationMode").val("");
}
//error msg
function Ezerrormsg(idl, msg) {
    debugger;
    $(idl).show();
    $(idl).text(msg);
    $(idl).css("color", "red");
    //.find("strong")
}
//Disabled true
function EzDisabledT(Ideary) {
    // $(Ide).attr("disabled", true);
    var n = Ideary.length;
    while (n > 0) {
        $(Ideary[n - 1]).attr("disabled", true);
        n--;
    }
}
//Disabled false
function EzDisabledF(Ideary) {
    var n = Ideary.length;
    while (n > 0) {
        $(Ideary[n - 1]).attr("disabled", false);
        n--;
    }
}
//Get Month Name
function EzGetMonthName(Mname, hdnMNum, dte) {
    $(Mname).val(EzmonthNames[dte.getMonth()]);
    $(hdnMNum).val(dte.getMonth()+1);
}

//Get Month Name1
function EzGetMonthName1(Mname, dte) {
    $(Mname).val(EzmonthNames[dte.getMonth()]);
}
//Get Year
function EzGetYear(Year1, hdnYear2, dte) {

    $(Year1).val(dte.getFullYear());
    $(hdnYear2).val(dte.getFullYear());
}

//Get Year1
function EzGetYear1(Year1, dte) {

    $(Year1).val(dte.getFullYear());
}
//divide parm Ist change Event, Ist amt, IInd Amt ,output in array
function Ezdivfn(idch, idA1, idA2, ot) {
    $(idch).change(function () {
        debugger;
        var res = 0;
        var lAmt = $(idA1).val();
        var lNoIns = $(idA2).val();
        if (lAmt > 0 && lNoIns > 0) {
            res = (lAmt / lNoIns);
        }
        else {
            res = 0.00;
        }
        var n = ot.length;
        while (n > 0) {
            $(ot[n - 1]).val(res);
            n--;
        }
    });
}
//drop Tab event
function EzDropTabEve(Ide, IdeSel, fIde, errmsg) {
    $(Ide).on('keydown', function (e) {
        var keyCode = e.keyCode || e.which;
        if (keyCode == 9) {
            e.preventDefault();
            debugger;
            var ab = $(IdeSel).val();
            if (ab != '0') {
                $(fIde).focus();
                $(fIde).select();
            }
            else {
                $(Ide).focus();
                alert(errmsg);
            }
        }
    });
}
//drop Change event
function EzDropChaEve(Ide, IdeSel, fIde, errmsg) {
    $(Ide).change(function () {
        debugger;
        var ab = $(IdeSel).val();
        if (ab != '0') {
            $(fIde).focus();
            $(fIde).select();
        }
        else {
            $(Ide).focus();
            alert(errmsg);
        }

    });
}
//Text Number  N & Text T Tab Event
function EzTxttabEve(Ide, fIde, errmsg, typ) {
    $(Ide).on('keydown', function (e) {
        var keyCode = e.keyCode || e.which;
        if (keyCode == 9) {
            e.preventDefault();
            var ab = '';
            if (typ == "N") {
                ab = parseInt($(Ide).val()) || 0;
            }
            else {
                ab = $(Ide).val();
            }
            debugger;
            if (ab != 0) {
                $(fIde).focus();
                $(fIde).select();
            }
            else {
                $(Ide).focus();
                $(Ide).select();
                alert(errmsg);
            }
        }
    });
}
//Side Grid with searching
function Ezsidetbl(ide, idef, lk) {
  // var jq = $.noConflict(true);

    $(document).ready(function () {
        // Setup - add a text input to each footer cell
        $(idef).each(function () {
            var title = $(this).text();
            $(this).html('<input type="text" placeholder="Search ' + title + '" />');
        });

        // DataTable
        var tableInstance = $(ide).DataTable({
            "paging": false,
            "ordering": true,
            "info": true
        });
        if (lk == true) {
            $("#tblUnits_length").hide();
        }

        tableInstance.columns().every(function () {
            var that = this;
            $('input', this.footer()).on('keydown', function (ev) {
                if (ev.keyCode == 13) { //only on enter keypress (code 13)
                    that
                        .search(this.value)
                        .draw();
                }
            });
        });


    });
}
function EzdtePk(date1) {    
    $(date1).datetimepicker({
        defaultDate: new Date(),
        format: 'DD/MM/YYYY',
        showClose: true,
        showClear: true,
        toolbarPlacement: 'top'
    });
}

function tbldtpicker() {
    $('.datepicker').datetimepicker({
        // defaultDate: new Date(),
        format: 'DD/MM/YYYY',
        showClose: true,
        showClear: true,
        toolbarPlacement: 'top'
    });
}

function tbldtpickerYY() {
    $('.datepicker').datetimepicker({
        // defaultDate: new Date(),
        format: 'YYYY',
        showClose: true,
        showClear: true,
        toolbarPlacement: 'top'
    });
}

function EzdtePkMMyy(date1) {
    $(date1).datetimepicker({
        defaultDate: new Date(),
        format: 'MMMM-YYYY',        
        showClose: true,
        showClear: true,
        toolbarPlacement: 'top',

    });
}

function EzdtePkyyyy(date1) {
    $(date1).datetimepicker({
        defaultDate: new Date(),
        format: 'YYYY',
        showClose: true,
        showClear: true,
        toolbarPlacement: 'top',

    });
}

function EzdtePkMMyyEdit(date1, dtval) {
    debugger;
    $(date1).datetimepicker({
        defaultDate: new Date($(dtval).val()),
        format: 'MMMM-YYYY',
        showClose: true,
        showClear: true,
        toolbarPlacement: 'top'
    });
}

function EzdtePkEdit(date1, dtval) {
    debugger;
    $(date1).datetimepicker({
        defaultDate: new Date($(dtval).val()),
        format: 'DD/MM/YYYY',
        showClose: true,
        showClear: true,
        toolbarPlacement: 'top'
    });
}

function EzdteTblPkEdit(dtval) {
    var now = new Date(dtval);
    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    var today = (day) + "/" + (month) + "/" + now.getFullYear();
    return today;
}


function Ezsetdtpkdate(date1) {   
    var d = new Date(date1.split("/").reverse().join("-"));
    var dd = d.getDate();
    var mm = d.getMonth() + 1;
    var yy = d.getFullYear();
    var newdate = yy + "/" + mm + "/" + dd;
    return newdate;
}
//Date Format
function Ezdatefrmt1(dte) {
    
    var now = new Date(parseInt(dte.substr(6)));
    var now = new Date(now);
    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    var today = now.getFullYear() + "-" + (month) + "-" + (day);
    return today;
}
function Ezdatefrmt(dte) {       
    var now = new Date(dte);
    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    var today = now.getFullYear() + "-" + (month) + "-" + (day);
    return today;
}

function EzdatefrmtRes(dte) { 
    var now = new Date(parseInt(dte.substr(6)));
     var now = new Date(now);
    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    var today = (day) + "/" + (month) + "/" + now.getFullYear();
    return today;
}
//Table Number  N & Text T Tab Event
function EztableTabEve(tbl, ide, idf, errmsg, typ, vtyp) {
    $(tbl).on("keydown", ide, function (e) {
        debugger;
        var keyCode = e.keyCode || e.which;
        if (keyCode == 9) {
            e.preventDefault();
            var tr = $(this).closest('tr');
            var ab = '';
            if (typ == "N") {
                ab = parseInt(tr.find(ide).val()) || 0;
            } else {
                ab = tr.find(ide).val();
            }
            if (ab != vtyp) {
                tr.find(idf).focus();
                tr.css("background", "");
            }
            else {
                tr.css("background", "red");
                tr.find(ide).focus();
                alert(errmsg);
            }
        }
    });
}

function EztableTabEveOne(tbl, ide, idf, errmsg, typ, vtyp,lent) {
    $(tbl).on("keydown", ide, function (e) {
        debugger;
        var keyCode = e.keyCode || e.which;
        if (keyCode == 9) {
            e.preventDefault();
            var tr = $(this).closest('tr');
            var ab = '';
            if (typ == "N") {
                ab = parseInt(tr.find(ide).val()) || 0;
            } else {
                ab = tr.find(ide).val();
            }
            if (ab.length <= lent) {
                tr.find(idf).focus();
                tr.css("background", "");
            }
            else {
                tr.css("background", "red");
                tr.find(ide).focus();
                alert(errmsg);
            }
        }
    });
}

/*Last Column Enter Event*/
function EztableLstEnt(tbl, ide, idf, errmsg, typ, vtyp) {
    $(tbl).on("keypress", ide, function (e) {
        debugger;
        if (e.keyCode == 13) {
            var tr = $(this).closest('tr');
            var ab = '';
            if (typ == "N") {
                ab = parseInt(tr.find(ide).val()) || 0;
            } else {
                ab = tr.find(ide).val();
            }
            if (ab != vtyp) {
                tr.find(idf).focus();
                tr.css("background", "");
                $(this).closest('tr').next('tr').find(idf).focus();
            }
            else {
                tr.css("background", "red");
                tr.find(ide).focus();
                alert(errmsg);
            }
            return false;
        }
    });
}

function EztableLstTabBlk(tbl, ide, idf, errmsg, typ, vtyp) {
    debugger;
    $(tbl).on("keydown", ide, function (e) {
        debugger;
        var keyCode = e.keyCode || e.which;
        if (keyCode == 9) {
            e.preventDefault();
            var tr = $(this).closest('tr');
            var ab = '';
            if (typ == "N") {
                ab = parseInt(tr.find(ide).val()) || 0;
            } else {
                ab = tr.find(ide).val();
            }
            if (ab != vtyp) {
                tr.find(idf).focus();
                tr.css("background", "");
                $(this).closest('tr').next('tr').find(idf).focus();
            }
            else {
                tr.css("background", "red");
                tr.find(ide).focus();
                alert(errmsg);
            }

        }
    });
}
/*Last Column Tab Event*/
function EztableLstTab(tbl, ide, idf) {
    $(tbl).on("keypress", ide, function (e) {
        debugger;
        var keyCode = e.keyCode || e.which;
        if (keyCode == 9) {
            e.preventDefault();
            $(this).closest('tr').next('tr').find(idf).focus();
        }
    });
}
/* delete grid record */
function EzGriddel(tbl, btndel) {
    $(tbl).on("click", btndel, function () {
        debugger;
        //  drec.pop($(this).find(ide).val());
        // counter1--;
        $(this).closest("tr").remove();
    });
}
function EzTableRowDel(tbl, btndel) {
    $(tbl).on("click", btndel, function () {
        $(this).closest("tr").remove();
    });
}

function EzMasterAdd(btnadd, btncan, btnsave) {
    $(btnadd).prop('disabled', true)
    $(btncan).prop("disabled", false);
    $(btnsave).prop("disabled", false);
}

function EzMasterCancel(btnadd, btncan, btnsave) {
    $(btnadd).prop("disabled", false);
    $(btncan).prop("disabled", true);
    $(btnsave).prop("disabled", true);
}



