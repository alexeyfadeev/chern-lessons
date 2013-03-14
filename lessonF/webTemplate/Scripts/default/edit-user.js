function EditUser() {
    var _this = this;

    this.ajaxUploadAvatar = "/ru/User/UploadAvatar";
    this.init = function () {
        $("#ChangeAvatar").fineUploader({
            request: {
                endpoint: _this.ajaxUploadAvatar
            },
            text : {
                uploadButton :  $("#ChangeAvatar").text()
                },
            debug: true
        })
        .on('complete', function(event, id, filename, responseJSON){
            if (responseJSON.result == "ok") {
                $("#AvatarPath").val(responseJSON.data.AvatarUrl);
                $("#AvatarImage").attr("src", responseJSON.data.AvatarUrl);
            }
        });
    };
}

var editUser;
$().ready(function () {
    editUser = new EditUser();
    editUser.init();
});
