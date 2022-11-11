//var accessToken = '';
//function statusChangeCallback(response) {



//    // Called with the results from FB.getLoginStatus().
//    //console.log("statusChangeCallback");

//    console.log(response); // The current login status of the person.

//    accessToken = (response.authResponse.accessToken);
//    console.log(accessToken);
//    if (response.status === "connected") {
//        // Logged into your webpage and Facebook.
//        testAPI(accessToken);
//    } else {
//        // Not logged into your webpage or we are unable to tell.
//        document.getElementById("status").innerHTML =
//            "Please log " + "into this webpage.";
//    }
//}

//function checkLoginState() {
//    // Called when a person is finished with the Login Button.
//    FB.getLoginStatus(function (response) {
//        // See the onlogin handler
//        statusChangeCallback(response);
//    });
//}

//window.fbAsyncInit = function () {
//    FB.init({
//        appId: "1535037343619428",
//        cookie: true, // Enable cookies to allow the server to access the session.
//        xfbml: true, // Parse social plugins on this webpage.
//        version: "v15.0", // Use this Graph API version for this call.
//    });

//    FB.getLoginStatus(function (response) {
//        // Called after the JS SDK has been initialized.
//        statusChangeCallback(response); // Returns the login status.
//    });
//};

//function testAPI() {
//    // Testing Graph API after login.  See statusChangeCallback() for when this call is made.
//    //console.log("Welcome!  Fetching your information.... ");

//    FB.api("/me", function (response) {

//        //console.log("Successful login for: " + response);
//        //document.getElementById("status").innerHTML =
//        //    "Thanks for logging in, " + response.name + "!";
//        //console.log(JSON.stringify(response));
//    });
//    query();
//}

//function query() {
//    debugger
//    $.ajax({

//        url: 'https://graph.facebook.com/me?fields=first_name,last_name,picture,email&access_token=' + accessToken,
        
//        success: function (response) {
//            if (response) { // check whether response is received
//                console.log(response.email);
//                let inputValue = response.email;
//                $.ajax({
//                    type: "POST",
//                    url: "/api/Email/SendEmail",
//                    data: JSON.stringify({ "To": inputValue }),
//                    dataType: "json",
//                    contentType: 'application/json;charset=utf-8',
//                    success: function (response) {
//                        if (response) { // check whether response is received
//                            window.location.replace("https://localhost:7043/StaticFiles/OtpVerification.html");
//                        }
//                    }
//                });
//            }
//        },

//        failure: function () {
//            console.log("errro");
//        }

//    });
//}