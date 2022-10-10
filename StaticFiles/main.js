function doRequest() {
    let inputValue = $('#email').val();
    $.ajax({
        type: "POST",
        url: "/api/Email/SendEmail",
        data: JSON.stringify({ "To": inputValue }),
        dataType: "json",
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            if (response) { // check whether response is received
                window.location.replace("https://localhost:7043/StaticFiles/OtpVerification.html");
            }
        }
    });
}

function ValidateUser() {
    debugger
    let emailValue = $("#dbemail").val();
    let otpValue = $('#dbotp').val();
    $.ajax({
        type: "POST",
        url: "/api/Email/DbCheck",
        data: JSON.stringify({ "To": emailValue, "OTP": otpValue }),
        dataType: "json",
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            debugger
            if (response) { // check whether response is received
                window.location.replace("https://www.google.com/");
            }
        }
    });
}