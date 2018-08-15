using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.RssOutputPages
{
    public partial class Nigeriana : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string content = System.IO.File.ReadAllText(Request.MapPath("~/RssTestPages/Nigeriana.html"));
            string filter = System.IO.File.ReadAllText(Request.MapPath("~/RssJsonFiles/Nigeriana.json"));
            OutputLabel.Text = ClassLibrary1.RSSParser.Parser(content, filter);
        }
    }
}