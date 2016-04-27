using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WebApplication16
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public string tree = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string configPath = Server.MapPath("config/test.xml");

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(configPath);
            StringBuilder sb = new StringBuilder();
            foreach (XmlNode xmlNode in xmlDoc.ChildNodes)
            {
                XmlElement xe = xmlNode as XmlElement;


                foreach (XmlNode xChildNode in xe.ChildNodes)
                {
                    XmlElement childXe = xChildNode as XmlElement;
                    sb.Append("<li>");
                    string rootName = childXe.GetAttribute("Name");
                    sb.Append("<span>" + rootName + "</span>");

                    sb.Append("<ul>");

                    foreach (XmlNode xcChildNode in childXe.ChildNodes)
                    {
                        XmlElement cchildXe = xcChildNode as XmlElement;
                        sb.Append("<li>" + cchildXe.InnerText + "</li>");
                    }
                    sb.Append("</ul>");
                    sb.Append("</li>");
                }

                ;
            }

            tree = sb.ToString();

        }


    }
}