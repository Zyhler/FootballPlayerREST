using Assignment1;
using FootballPlayerREST;
using Microsoft.AspNetCore.Http;

namespace FootballPlayerREST.Managers
{
    public class FootballPlayersManager
    {
            private static int _nextPlayerID = 10;
            private static readonly List<FootballPlayer> ListOfAthletes = new List<FootballPlayer>
            {
            new FootballPlayer { PlayerID = _nextPlayerID++, Name = "jon dahl", Age = 25, ShirtNumber = 4 },
            new FootballPlayer { PlayerID = _nextPlayerID++, Name = "Markus ericson", Age = 28, ShirtNumber = 15 },
            new FootballPlayer { PlayerID = _nextPlayerID++, Name = "messi", Age = 30, ShirtNumber = 28 },
            new FootballPlayer { PlayerID = _nextPlayerID++, Name = "ronaldo ", Age = 55, ShirtNumber = 18 },
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guPlayerIDe/classes-and-structs/object-and-collection-initializers
            };

            public List<FootballPlayer> GetAll()
            {
                return new List<FootballPlayer>(ListOfAthletes);
                // copy constructor
                // Callers should no get a reference to the ListOfObjects object, but rather get a copy
            }

            public FootballPlayer GetByPlayerID(int PlayerID)
            {

                return ListOfAthletes.Find(footballPlayer => footballPlayer.PlayerID == PlayerID);
            }

            public FootballPlayer Add(FootballPlayer newFootballPlayer)
            {
                newFootballPlayer.PlayerID = _nextPlayerID++;
                ListOfAthletes.Add(newFootballPlayer);
                return newFootballPlayer;
            }

            public FootballPlayer Delete(int PlayerID)
            {
                FootballPlayer footballPlayer = ListOfAthletes.Find(footballPlayer => footballPlayer.PlayerID == PlayerID);
                if (footballPlayer == null) return null;
                ListOfAthletes.Remove(footballPlayer);
                return footballPlayer;
            }

            public FootballPlayer Update(int PlayerID, FootballPlayer updates)
            {
                FootballPlayer footballPlayer = ListOfAthletes.Find(footballPlayer1 => footballPlayer1.PlayerID == PlayerID);
                if (footballPlayer == null) return null;
                footballPlayer.Name = updates.Name;
                footballPlayer.Age = updates.Age;
                footballPlayer.ShirtNumber = updates.ShirtNumber;
                return footballPlayer;
            }
        
    }
}
