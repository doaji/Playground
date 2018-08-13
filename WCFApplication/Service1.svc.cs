using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

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

        public List<string> GetHello()
        {


              return new List<string> { "Hello" };
        }
    }
}
