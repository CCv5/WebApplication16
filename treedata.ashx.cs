using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication16
{
    /// <summary>
    /// treedata 的摘要说明
    /// </summary>
    public class treedata : IHttpHandler
    {
        public string imageSrc = string.Empty;

        public string txtArea = string.Empty;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string nodeText = context.Request["node"];

            string pathJPG = "config/pic/" + nodeText + ".jpg";
            string pathTxT = "config/pic/" + nodeText + ".txt";

            string fullpathJPG = context.Server.MapPath(pathJPG);
            string fullpathTxT = context.Server.MapPath(pathTxT);


            imageSrc = pathJPG;

            fullpathTxT = File.ReadAllText(fullpathTxT);

            txtArea = fullpathTxT;

            context.Response.Write(imageSrc + "|" + txtArea);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}