function EzDropFill(ids,urls) {
    var a = 0;
    var selectedValue = $("#" + ids + " option:selected").val();
    var lenG = $("#" + ids + " > option").length;
    if (selectedValue == null || selectedValue == '-1' || lenG<=2) {
        $("#"+ids).empty();
        debugger;
        $.ajax({
            async: false,
            cache: false,
            type: "POST",
            url: urls,//"/FFM_PORT/GetCountry1",
            dataType: "json",           
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $.each(data, function (i) {
                    $("#"+ids).append($('<option>', {
                        value: data[i].Value,
                        text: data[i].Text
                    }))                    
                });
                $("#" + ids).selectpicker('refresh');
                a = 1;
            }
        });
        $("#"+ids).addClass('selectpicker');

        $("#" + ids).val($("input[name=" + ids + "]").val()).change();
        return a;
    }
}