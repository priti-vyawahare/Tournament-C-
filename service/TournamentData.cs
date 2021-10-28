using ChessTournament.Models;
using System.Collections.Generic;
using System.Linq;
using System;
 namespace ChessTournament.Service
 {
     public static class TournamentData
     {
        static List<Tournament> Tournaments { get; }
     
        static TournamentData()
        {
            Tournaments = new List<Tournament>
            {
                new Tournament { 
                    Name = "ChessYouth", 
                    Location="London", 
                    Category ="open", 
                    StartDate = Convert.ToDateTime("12/01/2021 11:00"),
                    EndDate = Convert.ToDateTime("12/01/2021 5:00"), 
                    Website ="www.chessyouth.uk" 
                },
                new Tournament { 
                    Name = "Schaken", 
                    Location="Amsterdam", 
                    Category ="open", 
                    StartDate = Convert.ToDateTime("10/03/2021 1:00"), 
                    EndDate = Convert.ToDateTime("11/03/2021 5:00"), 
                    Website ="www.schakenams.nl" 
                },
            };
        }

    public static List<Tournament> GetAll() => Tournaments;
    public static Tournament Get(string name) => Tournaments.FirstOrDefault(t=> t.Name == name);

    public static void Add(Tournament tournament)
    {
        Tournaments.Add(tournament);
    }
    
    public static void Delete(string name)
    {
        var tournament = Get(name);
        if(tournament is null)
        return ;
        Tournaments.Remove(tournament);
    }

    public static void Update(Tournament tournament)
    {
        var index = Tournaments.FindIndex(t=> t.Name == tournament.Name);
        if(index ==-1)
        return;
        Tournaments[index] = tournament;
    }
    }
}