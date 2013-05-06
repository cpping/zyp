/* Pomoho UI - Manage */
/*create by jason at 2009-4-21*/

jQuery(function($) {
    var from;
    $.fn.opendialog = function(a) {
        from = $(this);

        var doc = document;
        var docElement = doc.documentElement;
        var sHeight = docElement.clientHeight;
        var dH = docElement.scrollHeight > sHeight ? docElement.scrollHeight : sHeight;
        var scH = docElement.scrollTop >= 0 ? (docElement.scrollTop + sHeight / 2) : sHeight;
        hValue = scH - $(this)[0].clientHeight / 2;
        wValue = docElement.clientWidth / 2 - $(this)[0].clientWidth / 2;
        var o = { overlay: true, bgColor: '#ffffff', opacity: 0.5, h: hValue, w: wValue, iw: $(this).attr('width'), ih: $(this).attr('height') };
        if (a) {
            $.extend(o, a);
            if ($("#Msgdiv").length == 0) {
                var str = '';
                if ($.browser.msie) {
                    str += '<iframe id="Msgdiv" style="display:none"></iframe>';
                    $(str).appendTo("body");
                    var cw = window.frames['Msgdiv'];
                    cw.document.open();
                    cw.document.write('<style type="text/css">body{background:' + o.bgColor + '}</style>');
                    cw.document.close();
                }
                else {
                    str = '<div id="Msgdiv"><iframe style="display:none"></iframe></div>';
                    $(str).appendTo("body");
                }
            }
        }
        $(this).show();
        $("#Msgdiv").css({ width: docElement.clientWidth, height: dH, position: 'absolute', zIndex: 9999, left: '0px', top: '0px', background: o.bgColor, opacity: o.opacity }).show();

        //        $(this).css({ top: h, left: w, zIndex: 10001, width: o.iw, height: o.ih }).show(500);
        $(this).css({ top: o.h, left: o.w, zIndex: 10001, width: o.iw, height: o.ih }).fadeTo(400, 1);//5+1+a+s+p+x


        $(document).bind('keydown', $(this).EXC);

    }
    $.fn.hideDiv = function(fun) {
        $(this).hide();  //关闭小层
        $('#Msgdiv').hide(); //关闭大层
        if (fun) eval(fun);
    }
    $.fn.EXC = function(e) {
        var event = window.event || e;
        if (event.keyCode == 27) {
            from.hideDiv();
        }
    }
});
