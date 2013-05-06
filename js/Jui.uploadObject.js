/* Jason UI - Manage */
/*create by jason at 2009-4-22*/
/*文件上传类*/
var ifile = 0; //上传文件个数
var filePos = new Array("-1", "-1", "-1", "-1", "-1", "-1");
Jui.photo = {
    checkPhotoExtent: function(sFileName) {
        var ret = false;
        var fileArray = new Array('jpg', 'gif', 'png', 'bmp');
        for (i = 0; i < fileArray.length; i++) {
            if (fileArray[i] == sFileName.toLowerCase()) {
                ret = true;
                break;
            }
        }
        return ret;
    },
    checkSize: function(iSize) {
        var img = new Image()
        try {
            var imgDir = $.trim($("#filedir" + iSize).val());
            if (imgDir == "") {
                return;
            }
            try {
                img.src = imgDir;

            }
            catch (e) {
                alert("对不起该图片不能预览");
            }
            var getExtName = imgDir.split(".");
            if (!Jui.photo.checkPhotoExtent(getExtName[1])) {
                Jui.photo.showDiv("AUploadType");
                return;
            }
            else {
                ifile = ifile + 1;
                filePos[iSize - 1] = "1";
                $("#img" + iSize).attr({ src: "file:///" + imgDir.replace(/\\/g, '/'), width: Jui.photo.getSize(img.width, img.height, 1), height: Jui.photo.getSize(img.width, img.height, 2) });

            }
        }
        catch (e) {
            alert("对不起,格式检查出错!");
        }
    },
    getFileIndex: function(posVal) {

        var ret = "-1";
        for (i = posVal; i <= 5; i++) {
            if (filePos[i] == "1") {
                ret = i;
                break;
            }
        }
        return ret;
    },
    getSize: function(iWidth, iHeight, iType) {
        ret = 0;
        if (iWidth < 120 && iHeight < 90) {
            ret = iType == 1 ? iWidth : iHeight;//51(aspx)
            if (iWidth == 0 || iHeight == 0) {
                ret = iType == 1 ? 120 : 90;
            }
        }
        if (iWidth > 120 || iHeight > 90) {
            var size = width / 120.00 > height / 90.00 ? width / 120.00 : height / 90.00;
            ret = type == 1 ? width / size : height / size;
        }
        return ret;
    },
    showDiv: function(oName) {
        $("#" + oName).showDiv();
    },
    hideDiv: function(oName) {
        $("#" + oName).hideDiv();
    }

};
Jui.uploadObject = {

    currentNum: 0, //上传图片序号
    uploadForms: null,
    init: function() {
        if (ifile > 0) {
            var uploadPanel = $("#uploadPanel").get(0);
            Jui.uploadObject.uploadForms = $(uploadPanel).find("form");
            Jui.uploadObject.currentNum = 0;
            Jui.uploadObject.beginUpload();
        }
        else {
            Jui.photo.showDiv("AUploadSel");
        }
    },
    beginUpload: function() {

        var currentForm = $(Jui.uploadObject.uploadForms).eq(Jui.uploadObject.currentNum);

        var fileName = Jui.uploadObject.getInput(currentForm, "file").val();

        var arr = fileName.split(".");
        if (fileName != "" && Jui.photo.checkPhotoExtent(arr[1])) {
            $("#preTitle" + (Jui.uploadObject.currentNum + 1)).html("上传中");

            Jui.uploadObject.getInput(currentForm, "uploadid").val(Jui.uploadObject.currentNum + 1);

            currentForm.submit(); //此处添加上传事件
        }

    },
    uploadNext: function() {

        Jui.uploadObject.currentNum++;
        var iindex = Jui.photo.getFileIndex(Jui.uploadObject.currentNum);


        if (iindex > 0) {
            Jui.uploadObject.currentNum = iindex;

            Jui.uploadObject.beginUpload();
        }
        else {
            $("#ifrUpload").attr("src", "about:blank");
            alert("上传完成");


        }
    },
    getInput: function(oForm, sName) {
        var ret = null;
        var inputs = $(oForm).find("input");
        for (var i = 0; i < $(inputs).length; i++) {

            if ($(inputs).eq(i).attr("name").toLowerCase() == sName) {
                ret = $(inputs).eq(i);
                break;
            }
        }
        return ret;
    }

}