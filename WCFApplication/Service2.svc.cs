using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace WCFApplication
{
    [ServiceContract(Namespace = "http://localhost:14072/Service2")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service2
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        public void DoWork()
        {
            // Add your operation implementation here
            return;
        }

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        public string GetHello()
        {
            return "Hello";
        }

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
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
        // Add more operations here and mark them with [OperationContract]
    }
}
