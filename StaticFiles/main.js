function doRequest() {

    //fetch("https://localhost:7043/api/Email/SendEmail", {

    //    // adding method type
    //    method: "post",

    //    // adding body or contents to send
    //    body: json.stringify({

    //        To: "foo"
    //        //body: "bar",
    //        //userid: 1
    //    }),

    //    // adding headers to the request
    //    headers: {
    //        "content-type": "application/json; charset=utf-8"
    //    }
    //})

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
