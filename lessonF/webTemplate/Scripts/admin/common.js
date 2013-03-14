

function LoadCssDynamically(fileName) {
    var fileref = $('<link>');
    fileref.attr("rel", "stylesheet");
    fileref.attr("type", "text/css");
    fileref.attr("href", fileName);
    $("head").append(fileref);
}

function LoadJsDynamically(fileName) {
    var fileref = $('<script>');
    fileref.attr("type", "text/javascript");
    fileref.attr("src", fileName);

    $("head").append(fileref);
}


function InitUpload(item, multiple, url, oncomplete, extensions, title) {
    if (extensions == null) {
        extensions = [];
    }
    if (typeof (qq) == 'undefined') {
        LoadCssDynamically("/Content/css/fileuploader.css");
        LoadJsDynamically("/Scripts/fileuploader.js");
    }

    var obj = new qq.FileUploader({
        element: item,
        multiple: multiple,
        action: url,
        onComplete: oncomplete,
        allowedExtensions: extensions
    });

    if (title) {
        obj._button._element.firstChild.nodeValue = title;
    }
}

function Common() 
{
    var _this = this;

    this.init = function () {
        $(".delete-action, .btn-danger").live("click", function ()
        {
            return confirm("Вы действительно хотите удалить?");
        });
    };
}

var common;
$().ready(function () {
    common = new Common();
    common.init();
});


function Lang()
{
    var _this = this;

    this.init = function () 
    {
        $("#selectedLang").change(function () {
            $("#SelectLangForm").submit();
        });
    };
}

var lang;
$().ready(function () {
    lang = new Lang();
    lang.init();
});
