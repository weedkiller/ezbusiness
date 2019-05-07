var DTDreport={
    initialize: function ()
    {
        $('input[Type="date"]').val(new Date().getToday());
        $.fn.dataTable.ext.errorMode = 'none';
        DTDreport.Attachevent();
    },
    Attachevent:function()
    {
        $("#btnSearchData").click(function () {           
            DTDreport.DailyTimeSheetReportDetails();
        })
    },
    DailyTimeSheetReportDetails:function()
    {
        $("#displayfinalsettlment").show();
        
        var msg = "";
        var fdate = Ezsetdtpkdate($("#fnlfdatetxt").val());
        var Tdate = Ezsetdtpkdate($("#fnltdatetxt").val());
        var newrow = {
            FDate: fdate,
            TDate: Tdate,
        }
        $.ajax({
            async: false,
            cache: false,
            type: "POST",            
            url: "/Report/DailyTimeSheetDetailsReport",
            data: '{timerrport:' + JSON.stringify(newrow) + ' }',            
            contentType: "Application/json",
            dataType: 'Json',
            success: function (data) {
                $('#dailytimesheetreport').find("tr:gt(0)").remove();
                $('#dailytimesheetreport thead').empty();
                $('#dailytimesheetreport tbody').empty();
                if(data!=null)
                {
                    //var temp = 0;
                    for (var i = 0; i < data.length; i++) {
                        var AttnList = data[i].Attendanclist;
                      //  var temp1=temp;
                        for (var j = 0; j < AttnList.length; j++) {
                         if (j == 0) {
                                if (i == 0) {
                                    $('#dailytimesheetreport thead').append("<tr>")
                                    $('#dailytimesheetreport thead').append("<th>Emp Code</th>")
                                    $('#dailytimesheetreport thead').append("<th>Emp Name</th>")
                                    $('#dailytimesheetreport thead').append("<th>Division</th>")
                                    $('#dailytimesheetreport thead').append("<th>Department</th>")
                                    //$('#AttendanceregisterReport thead').append("<th>Shift Name</th>")
                                    $('#dailytimesheetreport thead').append("<th>Project</th>")
                                }
                                $('#dailytimesheetreport tbody').append("<tr>")
                                $('#dailytimesheetreport tbody').append("<th>" + data[i].EmpCode + "</th>")
                                $('#dailytimesheetreport tbody').append("<th>" + data[i].EmpName + "</th>")
                                $('#dailytimesheetreport tbody').append("<th>" + data[i].DIVISION + "</th>")
                                $('#dailytimesheetreport tbody').append("<th>" + data[i].DeptCode + "</th>")
                                    //$('#AttendanceregisterReport thead').append("<th>Shift Name</th>")
                                $('#dailytimesheetreport tbody').append("<th>" + data[i].Project_code + "</th>")
                            }
                            if (i == 0) {
                                $('#dailytimesheetreport thead').append("<th>" + AttnList[j].Day + "</th>")
                               
                            }
                            //if (i > 0)
                            //{
                            //    if (AttnList[j].Daydata==null)
                            //    {
                            //        $('#dailytimesheetreport tbody').append("<td>NA</td>")

                            //    }
                            //    $('#dailytimesheetreport tbody').append("<td>" + AttnList[j].AttenStatus + "</td>")
                            //}
                            //else
                            //{
                                $('#dailytimesheetreport tbody').append("<td>" + AttnList[j].AttenStatus + "</td>")
                          //  }
                            
                        }
                        $('#dailytimesheetreport tbody').append("</tr>")
                    }
                }
            }
        })
    }
}