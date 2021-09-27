using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Adapter_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Initialize

            Player p1 = new Player("James");
            Player p2 = new Player("Curry");
            Player p3 = new Player("Westbrook");
            Player p4 = new Player("Dmitriy");
            Player p5 = new Player("Ayxan");
            Player p6 = new Player("Ravan");
            Team team1 = new Team("Lakers", p1, p2, p3);
            Team team2 = new Team("FireLand", p4, p5, p6);

            #endregion

            #region XML Save in bin\Debug File

            IXMLSerializable xml = new XMLSerialize();
            xml.XMLSave(AppContext.BaseDirectory + "GamesXml.xml", new List<Game>() { new Game(team2, team1, 13, 37), new Game(team1, team2, 68, 72) });

            #endregion

            #region Json Save in bin\Debug File

            IJsonSerializable json = new JsonSerialize();
            json.JsonSave(AppContext.BaseDirectory + "GamesJson.json", new List<Game>() { new Game(team2, team1, 13, 37), new Game(team1, team2, 68, 72) });

            IXMLSerializable jsonToXML = new JsonToXMLAdapter();
            //jsonToXML.XMLSave(AppContext.BaseDirectory + "GamesJson.json", new List<Game>() { new Game(team2, team1, 13, 37), new Game(team1, team2, 68, 72) });

            #endregion

            List<Game> games = null;

            #region XML Open in bin\Debug File

            //games = xml.XMLOpen(AppContext.BaseDirectory + "GamesXML.xml");

            #endregion

            #region Json Open in bin\Debug File

            //games = json.JsonOpen(AppContext.BaseDirectory + "GamesJson.xml");

            //games = jsonToXML.XMLOpen(AppContext.BaseDirectory + "GamesJson.json");

            #endregion

            if (games != null)
            {
                Game game;
                for (int i = 0; i < games.Count; i++)
                {
                    game = games[i];
                    Console.WriteLine($"{game.team1.Name} VS {game.team2.Name}" +
                        $"\t {game.scoreTeam1} : {game.scoreTeam2}" +
                        $"\t Team {(game.scoreTeam1 > game.scoreTeam2 ? game.team1.Name : game.team2.Name)} Win!");
                }
            }
        }
    }
}
