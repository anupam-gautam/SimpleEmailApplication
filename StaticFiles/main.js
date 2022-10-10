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

    //    // converting to json
    //    .then(response => response.json())

    //    // displaying results to console
    //    .then(json => console.log(json));





        let inputValue = $('#email').val();

        $.ajax({
            type: "POST",
            url: "/api/Email/SendEmail",
            data: JSON.stringify({ "To": inputValue }),
            contentType: 'application/json;charset=utf-8',
            //success: alert("DONE"),
            dataType: "json"
        });

        

    //    // converting to json
    //    .then(response => response.json())

    //    // displaying results to console
    //    .then(json => console.log(json));





        let inputValue = $('#email').val();

        $.ajax({
            type: "POST",
            url: "/api/Email/SendEmail",
            data: JSON.stringify({ "To": inputValue }),
            contentType: 'application/json;charset=utf-8',
            //success: alert("DONE"),
            dataType: "json"
        });

        

    //    // converting to json
    //    .then(response => response.json())

    //    // displaying results to console
    //    .then(json => console.log(json));





        let inputValue = $('#email').val();

        $.ajax({
            type: "POST",
            url: "/api/Email/SendEmail",
            data: JSON.stringify({ "To": inputValue }),
            contentType: 'application/json;charset=utf-8',
            //success: alert("DONE"),
            dataType: "json"
        });

        

}



//    location.replace("https://www.w3schools.com")
