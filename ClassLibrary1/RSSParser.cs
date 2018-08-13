using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
   public class RSSParser
    {
        public struct ElementFilterDefinition
        {
            public string Tag { get; set; }

            public string AttributeName { get; set; }
            public string ID { get; set; }
        }

        public class FilterContainer
        {
            public string MainContent { get; set; }

            public string MainAttributeName { get; set; }

            public List<ElementFilterDefinition> AddElements { get; set; } = new List<ElementFilterDefinition>();
            public List<ElementFilterDefinition> RemoveElements { get; set; } = new List<ElementFilterDefinition>();
        }
        // sample syntax: [maincontent:_content_]|[content:+_content/-_content_/+_content][images:/+_image_src_/-_image_src]
        public static string Parser(string content,string filter)
        {
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<FilterContainer>(filter);
            
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(content);

            // get maincontent element
            var maincontent = doc.DocumentNode.Descendants().FirstOrDefault(x => x.Attributes[data.MainAttributeName]?.Value == data.MainContent);
            if (maincontent!=null)
            {
                // remove all unwanted elements
                foreach (var item in data.RemoveElements)
                {
                    maincontent.Descendants().Where(x => x.Name == item.Tag && x.Attributes[item.AttributeName]?.Value == item.ID).ToList().ForEach(x=>x.Remove());
                }

                // add elements
                foreach (var item in data.AddElements)
                {
                    var node = doc.DocumentNode.Descendants().FirstOrDefault(x => x.Name == item.Tag && x.Attributes[item.AttributeName]?.Value == item.ID);
                    if (node!=null)
                    {
                        maincontent.PrependChild(node);
                    }
                }
                return maincontent.OuterHtml;
            }

            return content;
        }


    }
}
