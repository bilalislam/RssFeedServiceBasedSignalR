
$(document).ready(function () {
    $("#btnSubmit").click(function () {
        $.post(ROOT + "/Home/Change", { url: $("#txtUrl").val() })
        .done().fail(function (error) {
            global.popup("Error", "An error occured");
        });
    });

    $("#btnClear").click(function () {
        $("#txtUrl").val('');
    });

});
