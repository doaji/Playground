using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServiceApp.WS
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://localhost:12045")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<Person> GetPeople()
        {
            List<Person> p = new List<Person>();
            for (int i = 0; i < 10; i++)
            {
                p.Add(new Person
                {
                    Age = i,
                    ID = i,
                    Name = $"Robo {i}"
                });
            }
            return p;

         //  return new List<string> { "Hello" };
        }
    }
}
