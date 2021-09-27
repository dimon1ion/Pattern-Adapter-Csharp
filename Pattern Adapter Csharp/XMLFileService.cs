using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Pattern_Adapter_Csharp
{
    class XMLSerialize : IXMLSerializable
    {
        public List<Game> XMLOpen(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Game>));
            try
            {
                List<Game> games = new List<Game>();
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    games = (List<Game>)xmlSerializer.Deserialize(fs);
                }
                return games;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public void XMLSave(string path, List<Game> games)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Game>));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, games);
            }
        }
    }
}
