$.ajax({
    type: "GET",
    url: "/api/DbInfo/GetDbInfo",
    data: {
        "page": 4
    },
    dataType: "json",
    contentType: 'application/json;charset=utf-8',
    success: function (data) {
        console.log(data.currentPages);
        console.log(data.pages);
        for (var i = 0; i < data.pages; i++) {
            
            btnHTML = '<button onclick="returnPaginationData('+(i+1)+')">' + (i+1) + '</button>' + '</br>';

            $('#pagination').append(btnHTML);
        }

    }
});

//Search Bar Functionality
function searchRecords() {
    debugger
    let emailValue = $("#search").val();
    $.ajax({
        type: "POST",
        url: "/api/DbInfo/DatabaseSearch",
        data: JSON.stringify({ "To": emailValue }),
        dataType: "json",
        contentType: 'application/json;charset=utf-8',
        success: function (data) {
            $('#tBody').empty();
            var trHTML = '';
            for (var i = 0; i < data.length; i++) {
                console.log(data[i].id);
                trHTML +=
                    '<tr><td>'
                    + data[i].id
                    + '</td><td>'
                    + data[i].email
                    + '</td><td>'
                    + data[i].otp
                    + '</td></tr>';
            }
            $('#tBody').append(trHTML);
        }
    });
}

//display data in table
function returnPaginationData(page) {
    try {
        $.ajax({
            type: "GET",
            url: "/api/DbInfo/GetDbInfo",
            data: {
                "page": page
            },
            dataType: "json",
            contentType: 'application/json;charset=utf-8',
            success: function (data) {
                $('#tBody').empty();
                var trHTML = '';
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
