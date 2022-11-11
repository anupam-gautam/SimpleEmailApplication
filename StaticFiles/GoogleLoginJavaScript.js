$(document).ready(function () {
    $('#btnGoogleLogin').click(function () {
        var clientId = '888792722174-t937desh0knd6bojh43vmsvsqse4et3q.apps.googleusercontent.com';
        var redirectUrl = 'https://localhost:7043/StaticFiles/GoogleDataResponse.html';
        window.location.href = 'https://accounts.google.com/o/oauth2/v2/auth?' +
            'scope=openid%20email' +
            '&response_type=token' +
            '&redirect_uri=' + redirectUrl +
            '&client_id=' + clientId;
    });
});
