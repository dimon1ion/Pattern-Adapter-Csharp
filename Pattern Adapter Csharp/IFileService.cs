using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Adapter_Csharp
{
    interface IXMLSerializable
    {
        List<Game> XMLOpen(string path);
        void XMLSave(string path, List<Game> games);
    }
    interface IJsonSerializable
    {
        List<Game> JsonOpen(string path);
        void JsonSave(string path, List<Game> games);
    }
}
