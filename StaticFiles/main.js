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

function returnPaginationData() {
    
    try {
        $.ajax({
            type: "GET",
            url: "/api/DbInfo/GetDbInfo",
            data: {
                "page": 3
            }, 
            dataType: "json",
            contentType: 'application/json;charset=utf-8',
            success: function (data) {
                console.log(data);
            }
        });
    }
    catch (err) {
        console.log(err);
    }


    }