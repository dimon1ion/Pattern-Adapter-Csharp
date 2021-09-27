using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Adapter_Csharp
{
    public class Player
    {
        public string Name { get; set; }
        public Player()
        {

        }
        public Player(string name)
        {
            Name = name;
        }
    }
    public class Team
    {
        public Team()
        {

        }
        public string Name { get; set; }
        public Player[] Players { get; set; }
        public Team(string name, params Player[] players)
        {
            Name = name;
            Players = players;
        }
    }
    public class Game
    {
        public Team team1;
        public Team team2;
        public int scoreTeam1;
        public int scoreTeam2;
        public Game()
        {

        }
        public Game(Team team1, Team team2, int scoreTeam1, int scoreTeam2)
        {
            this.team1 = team1;
            this.team2 = team2;
            this.scoreTeam1 = scoreTeam1;
            this.scoreTeam2 = scoreTeam2;
        }
    }
}
