﻿//NGP

function ezValidateNumbers(tableid, ids) {
    $(tableid).on("keydown", ids, function (e) {
        var keycode = event.which;
        if (!(event.shiftKey == false && (keycode == 46 || keycode == 8 || keycode == 37 || keycode == 39 || (keycode >= 48 && keycode <= 57)))) {
            event.preventDefault();
        }
        $(ids).focus();
    });
}
//function EZMessgDeleteBtn()
//{
//    debugger;
//   // var retunresult = "";
//    const swalWithBootstrapButtons = Swal.mixin({
//        confirmButtonClass: 'btn btn-success',
//        cancelButtonClass: 'btn btn-danger',
//        buttonsStyling: false,
//    })
//    swalWithBootstrapButtons.fire({
//        title: 'Are you sure?',
//        text: "You won't be able to revert this!",
//        type: 'warning',
//        showCancelButton: true,
//        confirmButtonText: 'Yes, delete it!',
//        cancelButtonText: 'No, cancel!',
//        reverseButtons: true
//    })
  
//}
function EzHeadTxtvalid(ide, tbl, tblid, errmsg, typH,typ) {
   
    if ($(ide).val() == typH) {
        alert(errmsg);
        var trLast1 = $(tbl);
        trLast1.find(tblid).val(typ);
        $(ide).focus();       
        return true;
    }
}

function EzAuthentication(Rpath) {   
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
function EzAlertdele(code) {
    Swal.queue([{
        type: 'error',
        title: 'Oops...',
        text: 'Already use ' + code + ' code!',
        allowOutsideClick: false,
        showLoaderOnConfirm: true,
    }])
}
function EzAlerterr() {
    Swal.queue([{
        type: 'error',
        title: 'Oops...',
        text: 'Enter Valid Data!',
        allowOutsideClick: false,
        showLoaderOnConfirm: true,
    }])
}
function EzAlertUpd(code) {
    Swal.queue([{
        type: 'success',
        title: 'Success..',
        text: 'Updated ' + code + ' code!',
        allowOutsideClick: false,
        showLoaderOnConfirm: true,
    }])
}

function EzAlertSave() {
    Swal.queue([{
        type: 'success',
        title: 'Success..',
        text: 'Save Successfully!',
        allowOutsideClick: false,
        showLoaderOnConfirm: true,
    }])
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

var EzMMNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun",
"Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
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
function Ezsettxtclr(Ideary) {
    var n = Ideary.length;
    while (n > 0) {
        $(Ideary[n - 1]).val('');
        n--;
    }
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
   
    $('input[Type="date"]').val(new Date().getToday());
}
//Set Today Date
function EzsetTodayDte(Ideary) {
   
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
   
    $(Idinp).change(function () {
       
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
    if ($(Idhid).val() == "Y") {       
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
/*tbl class date formate DD/MM/YYYY get current */
function EzdtePk(date1) {
    debugger;
    $(date1).datetimepicker({
        defaultDate: new Date(),
        format: 'DD/MM/YYYY',
        showClose: true,
        showClear: true,
        toolbarPlacement: 'top'
    });
}
/*tbl class date formate DD/MM/YYYY get input */
function tbldtpicker() {
    $('.datepicker').datetimepicker({
        // defaultDate: new Date(),
        format: 'DD/MM/YYYY',
        showClose: true,
        showClear: true,
        toolbarPlacement: 'top'
    });
}
/*tbl date formate yyyy  */
function tbldtpickerYY() {
    $('.datepicker').datetimepicker({      
        format: 'YYYY',
        showClose: true,
        showClear: true,
        toolbarPlacement: 'top'
    });
}

/*new date function base on format curent date*/
/* DD/MM/YYYY , YYYY , MMMM-YYYY  */
function Ezdteformtcur(date1,frmt) {
    $(date1).datetimepicker({
        defaultDate: new Date(),
        format: frmt,
        showClose: true,
        showClear: true,
        toolbarPlacement: 'top',

    });
}
/*tbl date formate yyyy  */
/* DD/MM/YYYY , YYYY , MMMM-YYYY  */
function tbldtpicker(date1, frmt) {
    $(date1).datetimepicker({      
        format: frmt,
        showClose: true,
        showClear: true,
        toolbarPlacement: 'top',

    });
}
/* date formate MMMM-yyyy get input date */
function EzdtePkEdit(date1, dtval, frmt) {
    $(date1).datetimepicker({
        defaultDate: new Date($(dtval).val()),
        format: frmt,
        showClose: true,
        showClear: true,
        toolbarPlacement: 'top'
    });
}

/* date formate MMMM-YYYY get current date */
function EzdtePkMMyy(date1) {
    $(date1).datetimepicker({
        defaultDate: new Date(),
        format: 'MMMM-YYYY',        
        showClose: true,
        showClear: true,
        toolbarPlacement: 'top',

    });
}
/* date formate yyyy get current date */
function EzdtePkyyyy(date1) {
    $(date1).datetimepicker({
        defaultDate: new Date(),
        format: 'YYYY',
        showClose: true,
        showClear: true,
        toolbarPlacement: 'top',

    });
}
/* date formate MMMM-yyyy get input date */
function EzdtePkMMyyEdit(date1, dtval) {   
    $(date1).datetimepicker({
        defaultDate: new Date($(dtval).val()),
        format: 'MMMM-YYYY',
        showClose: true,
        showClear: true,
        toolbarPlacement: 'top'
    });
}
/* date formate DD/MM/yyyy get input date */
//function EzdtePkEdit(date1, dtval) {   
//    $(date1).datetimepicker({
//        defaultDate: new Date($(dtval).val()),
//        format: 'DD/MM/YYYY',
//        showClose: true,
//        showClear: true,
//        toolbarPlacement: 'top'
//    });
//}
/* date formate dd/MM/yyyy set Table*/
function EzdteTblPkEdit(dtval) {
    debugger;
    var now = new Date(dtval);
    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    var today = (day) + "/" + (month) + "/" + now.getFullYear();
    return today;
}
/* date formate yy/mm/dd */
function Ezsetdtpkdate(date1) {   
    var d = new Date(date1.split("/").reverse().join("-"));
    var dd = d.getDate();
    var mm = d.getMonth() + 1;
    var yy = d.getFullYear();
    var newdate = yy + "/" + mm + "/" + dd;
    return newdate;
}


/* date format yyyy-MM-dd */
function Ezdatefrmt(dte) {       
    var now = new Date(dte);
    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    var today = now.getFullYear() + "-" + (month) + "-" + (day);
    return today;
}
/*json date format dd/MM/yyyy*/
function EzdatefrmtRes(dte) { 
    var now = new Date(parseInt(dte.substr(6)));
     var now = new Date(now);
    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    var today = (day) + "/" + (month) + "/" + now.getFullYear();
    return today;
}

/*json date format dd-MMM-yyyy*/
function EzdatefrmtRes1(dte) {
    var now = new Date(parseInt(dte.substr(6)));
    var now = new Date(now);
    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    var today = (day) + "-" + EzMMNames[month - 1] + "-" + now.getFullYear();
    return today;
}

//Table Number  N & Text T Tab Event
function EztableTabEve(tbl, ide, idf, errmsg, typ, vtyp) {
    $(tbl).on("keydown", ide, function (e) {
       
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
/*Lenght decide table inside input */
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
                tr.find(ide).val(ab.slice(0, 1 - ab.length));
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
   
    $(tbl).on("keydown", ide, function (e) {
       
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
/*Master Add*/
function EzMasterAdd(btnadd, btncan, btnsave) {
    $(btnadd).prop('disabled', true)
    $(btncan).prop("disabled", false);
    $(btnsave).prop("disabled", false);
}
/*Master Cancel*/
function EzMasterCancel(btnadd, btncan, btnsave) {
    $(btnadd).prop("disabled", false);
    $(btncan).prop("disabled", true);
    $(btnsave).prop("disabled", true);
}

function Ezprop(Ideary, propvalue, tf) {
    debugger;
    var n = Ideary.length;
    while (n > 0) {
        $(Ideary[n - 1]).prop(propvalue, tf);
        n--;
    }
}
function Ezattr(Ideary, propvalue, tf) {
    debugger;
    var n = Ideary.length;
    while (n > 0) {
        $(Ideary[n - 1]).attr(propvalue, tf);
        n--;
    }
}








