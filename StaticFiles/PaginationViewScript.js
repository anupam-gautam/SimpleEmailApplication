var page = 1;

//Load the buttons to navigate the pages
$.ajax({
    type: "GET",
    url: "/api/DbInfo/GetDbInfo",
    data: {
        "page": page
    },
    dataType: "json",
    contentType: 'application/json;charset=utf-8',
    success: function (data) {
        
        firstBtnHTML = '<button onclick="returnPaginationData(' + page + ')">First</button>';
        $('#pagination').append(firstBtnHTML);

        //prevBtnHTML = '<button onclick="returnPaginationData(' + (page--) + ')">Previous</button>';
        //$('#pagination').append(prevBtnHTML);

        //nextBtnHTML = '<button onclick="returnPaginationData(' + (page++) + ')">Next</button>';
        //$('#pagination').append(nextBtnHTML);

        lastBtnHTML = '<button onclick="returnPaginationData(' + data.pages + ')">Last </button>';
        $('#pagination').append(lastBtnHTML);
        //for (var i = 0; i < data.pages; i++) {
        //    btnHTML = '<button onclick="returnPaginationData(' + (i + 1) + ')">' + (i + 1) + '</button>' ;
        //    $('#pagination').append(btnHTML);
        //}

    }
});

//Search Bar Functionality
function searchRecords() {

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
                for (i = 0; i < 10; i++) {
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
                $('#pagination').empty();

                firstBtnHTML = '<button onclick="returnPaginationData(' + 1 + ')">' + 1 + '</button>';
                $('#pagination').append(firstBtnHTML);

                prevBtnHTML = '<button onclick="returnPaginationData(' + (page - 1) + ')">Previous</button>';
                $('#pagination').append(prevBtnHTML);

                nextBtnHTML = '<button onclick="returnPaginationData(' + (page + 1) + ')">Next</button>';
                $('#pagination').append(nextBtnHTML);

                lastBtnHTML = '<button onclick="returnPaginationData(' + data.pages + ')">' + data.pages + '</button>';
                $('#pagination').append(lastBtnHTML);



            }
        });
    }
    catch (err) {
        console.log(err);
    }
}


//sort Jquery
function sortValues() {
    var column = $('#column').find('option:selected').text();
    var isAscend = $('#isascend').val();
    $.ajax({


        type: "POST",
        url: "/api/DbInfo/Sort",

        data: JSON.stringify({ "Column": column, "IsAscend": isAscend }),
        dataType: "json",
        contentType: 'application/json;charset=utf-8',
        success: function (data) {


            console.log(data);

            $('#tBody').empty();
            var trHTML = '';
            var i = 0;
            for (i = 0; i < data.length; i++) {
                trHTML =
                    '<tr><td>'
                    + data[i].id
                    + '</td><td>'
                    + data[i].email
                    + '</td><td>'
                    + data[i].otp
                    + '</td></tr>';
                $('#tBody').append(trHTML);
            }
        }
    });

}