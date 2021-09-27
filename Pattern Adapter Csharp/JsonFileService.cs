using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Adapter_Csharp
{
    class JsonSerialize : IJsonSerializable
    {
        public List<Game> JsonOpen(string path)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Game>));
            try
            {
                List<Game> games;
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    games = (List<Game>)jsonSerializer.ReadObject(fs);
                }
                return games;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public void JsonSave(string path, List<Game> games)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Game>));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                jsonSerializer.WriteObject(fs, games);
            }
        }
    }
    class JsonToXMLAdapter : IXMLSerializable
    {
        IJsonSerializable json = new JsonSerialize();
        public List<Game> XMLOpen(string path)
        {
            return json.JsonOpen(path);
        }
        public void XMLSave(string path, List<Game> games)
        {
            json.JsonSave(path, games);
        }
    }
}
