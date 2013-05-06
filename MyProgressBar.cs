﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoPatchUpload
{
    public class MyProgressBar
    {
        public static void Start()
        {
            Start("正在加载...");
        }
        /// <summary>
        /// 进度条的初始化
        /// </summary>
        /// <param name="msg">最开始显示的信息</param>
        public static void Start(string msg)
        {
            string s = "<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n<title></title>\r\n\r\n";
            s += "<link href=\"/css.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n";
            s += "<style>body {text-align:center;margin-top: 50px;}#ProgressBarSide {height:25px;border:1px #2F2F2F;width:65%;background:#EEFAFF;}</style>\r\n";
            s += "<script language=\"javascript\">\r\n";
            s += "function SetPorgressBar(msg, pos)\r\n";
            s += "{\r\n";
            s += "document.getElementById('ProgressBar').style.width = pos + \"%\";\r\n";
            s += "WriteText('Msg1',msg + \" 已完成\" + pos + \"%\");\r\n";
            s += "}\r\n";
            s += "function SetCompleted(msg)\r\n{\r\nif(msg==\"\")\r\nWriteText(\"Msg1\",\"完成。\");\r\n";
            s += "else\r\nWriteText(\"Msg1\",msg);\r\n}\r\n";
            s += "function WriteText(id, str)\r\n";
            s += "{\r\n";
            s += "var strTag = '<span style=\"font-family:Verdana, Arial, Helvetica;font-size=11.5px;color:#DD5800\">' + str + '</span>';\r\n";
            s += "document.getElementById(id).innerHTML = strTag;\r\n";
            s += "}\r\n";
            s += "</script>\r\n</head>\r\n<body>\r\n";
            s += "<div id=\"Msg1\"><span style=\"font-family:Verdana, Arial, Helvetica;font-size=11.5px;color:#DD5800\">" + msg + "</span></div>\r\n";
            s += "<div id=\"ProgressBarSide\" align=\"left\" style=\"color:Silver;border-width:1px;border-style:Solid;\">\r\n";
            s += "<div id=\"ProgressBar\" style=\"background-color:#008BCE; height:25px; width:0%;color:#fff;\"></div>\r\n";
            s += "</div>\r\n</body>\r\n</html>\r\n";
            System.Web.HttpContext.Current.Response.Write(s);
            System.Web.HttpContext.Current.Response.Flush();//51+aspx
        }
        /// <summary>
        /// 滚动进度条
        /// </summary>
        /// <param name="Msg">在进度条上方显示的信息</param>
        /// <param name="Pos">显示进度的百分比数字</param>
        public static void Roll(string Msg, int Pos, string orderNum)
        {
            string jsBlock = "<script language=\"javascript\">window.parent.document.getElementById('preTitle" + orderNum + "').innerText = '已经上传" + Pos + "%数据';</script>";

            System.Web.HttpContext.Current.Response.Write(jsBlock);
            System.Web.HttpContext.Current.Response.Flush();
            System.Threading.Thread.Sleep(1000);

        }
    }
}
