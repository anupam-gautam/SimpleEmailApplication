$(document).ready(function () {
    //Login by Google
    $('#btnGoogleLogin').click(function () {
        var clientId = '888792722174-ou49vl5oph7qf5f006o1e1rtpjjh39vn.apps.googleusercontent.com';
        var redirectUrl = 'https://localhost:7043/StaticFiles/data.html';
        window.location.href = 'https://accounts.google.com/o/oauth2/auth?' +
            'scope=openid%20email' +
            '&response_type=token' +
            '&redirect_uri=' + redirectUrl +
            '&client_id=' + clientId;
    });
});
















//Old Code
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
    let emailValue = $("#dbemail").val();
    let otpValue = $('#dbotp').val();

    $.ajax({
        type: "POST",
        url: "/api/DbValidate/DbCheck",
        data: JSON.stringify({ "To": emailValue, "OTP": otpValue }),
        dataType: "json",
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            if (response) { // check whether response is received
                window.location.replace("https://www.google.com/");
            }
        }
    });
}



