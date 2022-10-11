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
                "page": 6
            },
            dataType: "json",
            contentType: 'application/json;charset=utf-8',
            success: function (data) {
                debugger
                
                var trHTML = '';
                
                //foreach(i in data.emailOtps)
                //{
                //    trHTML +=
                //        '<tr><td>'
                //        + i.id
                //        + '</td><td>'
                //        + i.email
                //        + '</td><td>'
                //        + i.otp
                //        + '</td></tr>';

                //    $('#tBody').append(trHTML);

                //}
                
                var i = 0;
                for (i = 0; i < 3; i++) {
                    trHTML =
                        '<tr><td>'
                        + data.emailOtps[i].id
                        + '</td><td>'
                        + data.emailOtps[i].email
                        + '</td><td>'
                        + data.emailOtps[i].otp
                        + '</td></tr>';

                    $('#tBody').append(trHTML);
                    
                }

            }
        });
    }
    catch (err) {
        console.log(err);
    }


}