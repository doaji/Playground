using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class RSSParseOutPut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string content = File.ReadAllText(Request.MapPath("RSSParseTest.html"));
            string filter = File.ReadAllText(Request.MapPath("rssFilterJson.json"));
           OutputLabel.Text= ClassLibrary1.RSSParser.Parser(content, filter);
        }
    }
}