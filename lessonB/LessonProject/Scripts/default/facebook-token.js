function FacebookToken() {
    _this = this;

    this.ajaxGetUserInfo = "https://graph.facebook.com/me?access_token=";

    this.init = function () {
        var token = $("#Token").val();
        $.ajax({
            type: "GET",
            dataType: 'json',
            url: _this.ajaxGetUserInfo + token,
            success: function (data)
            {
                $("#ID").text(data.id);
                $("#FirstName").text(data.first_name);
                $("#LastName").text(data.last_name);
                $("#Link").text(data.link);
            }
        })
    }
}

var facebookToken = null;

$().ready(function () {
    facebookToken = new FacebookToken();
    facebookToken.init();
});