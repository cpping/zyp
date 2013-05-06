using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace PhotoPatchUpload
{
    public partial class uploadPhoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string value = "1";
            if (!String.IsNullOrEmpty(Request["uploadid"]))
            {
                value = Request["uploadid"].ToString();
            }

            HttpPostedFile oFile = Request.Files["file"];
            if (oFile == null || oFile.ContentLength < 1 || oFile.ContentLength > 1024 * 1024)
            {
                string js = "window.parent.document.getElementById('preTitle{0}').innerText = '上传失败';this.location.href='about:blank';";

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", string.Format(js, value), true);
            }
            else
            {
                try
                {
                    string cFileName = GetRandomFileName(oFile.FileName);
                    Stream fs = oFile.InputStream;//51^aspx

                    byte[] by = new byte[1024];//分块读取

                    string jsLoad = "";

                    string folderPath = Server.MapPath("~/UploadFloder/");
                    string filePath = folderPath + cFileName;
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    FileStream fStream = new FileStream(filePath, FileMode.Create);
                    int osize = fs.Read(by, 0, by.Length);
                    int totalNum = (int)fs.Length / by.Length;
                    totalNum++;
                    int i = 0;

                    while (osize > 0)
                    {

                        if (osize > 0)
                        {
                            fStream.Write(by, 0, osize);
                            string msg = "已经上传" + osize + "数据";
                            MyProgressBar.Roll(msg, ((i + 1) * 100 / totalNum), value);
                        }
                        osize = fs.Read(by, 0, by.Length);

                        jsLoad = "已经上传" + osize + "数据";

                        //fStream.Close();
                        //fStream.Dispose();
                        //string jsBlock = "<script language=\"javascript\">window.parent.document.getElementById('preTitle" + value + "').innerText = '上传成功';window.parent.Jui.uploadObject.uploadNext();</script>";

                        //System.Web.HttpContext.Current.Response.Write(jsBlock);
                        //System.Web.HttpContext.Current.Response.Flush();
                    }
                    fStream.Close();
                    fStream.Dispose();
                    string jsBlock = "<script language=\"javascript\">window.parent.document.getElementById('preTitle" + value + "').innerText = '上传成功';window.parent.Jui.uploadObject.uploadNext();</script>";

                    System.Web.HttpContext.Current.Response.Write(jsBlock);
                    System.Web.HttpContext.Current.Response.Flush();


                }
                catch
                {
                    string js = "window.parent.document.getElementById('preTitle{0}').innerText = '上传失败';this.location.href='about:blank';";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", string.Format(js, value), true);
                }

            }

        }
        /// <summary>
        /// 取得随机文件名
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public string GetRandomFileName(string filename)
        {
            string[] files = filename.Split('.');
            string exfilename = "." + files.GetValue(files.Length - 1);

            char[] s = new char[]{'0','1', '2','3','4','5','6','7','8','9','A' 
          ,'B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q' 
          ,'R','S','T','U','V','W','X','Y','Z'};
            string num = "";
            Random r = new Random();
            for (int i = 0; i < 4; i++)
                num += s[r.Next(0, s.Length)].ToString();//51&aspx
            DateTime time = DateTime.Now;
            string name = time.Year.ToString()
                + time.Month.ToString().PadLeft(2, '0')
                + time.Day.ToString().PadLeft(2, '0')
                + time.Hour.ToString().PadLeft(2, '0')
                + time.Minute.ToString().PadLeft(2, '0')
                + time.Second.ToString().PadLeft(2, '0')
                + num + exfilename;
            return name;
        }
    }
}
