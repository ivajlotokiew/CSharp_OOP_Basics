using System;
using System.Collections.Generic;
using System.IO;
using _06.Problem_NewVersion.Models;

namespace _06.Problem_NewVersion
{
    public class StartUp
    {
        public static Dictionary<string, Team> teams = new Dictionary<string, Team>();

        public static void Main()
        {

            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] dataLine = line.Split(';');

                try
                {
                    string cmd = dataLine[0];

                    switch (cmd)
                    {
                        case "Team":
                            string teamName = dataLine[1];
                            CreateNewTeam(teamName);
                            break;
                        case "Add":
                            AddNewPlayer(dataLine);
                            break;
                        case "Remove":
                            string team = dataLine[1];
                            string namePlayerToRemove = dataLine[2];
                            RemoveGivenPlayer(team, namePlayerToRemove);
                            break;
                        case "Rating":
                            string teamRating = dataLine[1];
                            ShowRatingTeam(teamRating);
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine($"Team {dataLine[1]} does not exist.");
                }

                line = Console.ReadLine();
            }
        }

        private static void ShowRatingTeam(string teamRating)
        {
            Console.WriteLine($"{teamRating} - {teams[teamRating].Rating}");
        }

        private static void RemoveGivenPlayer(string team, string namePlayerToRemove)
        {
            teams[team].RemovePlayerMethod(namePlayerToRemove);
        }

        private static void AddNewPlayer(string[] dataLine)
        {
            string nameTeam = dataLine[1];
            string namePlayer = dataLine[2];
            int endurance = int.Parse(dataLine[3]);
            int sprint = int.Parse(dataLine[4]);
            int driblle = int.Parse(dataLine[5]);
            int passing = int.Parse(dataLine[6]);
            int shooting = int.Parse(dataLine[7]);

            if (!teams.ContainsKey(nameTeam))
            {
                Console.WriteLine($"Team {nameTeam} does not exist.");
                return;
            }

            Player newPlayer = new Player(namePlayer,
                new Stats("Endurance", endurance),
                new Stats("Sprint", sprint),
                new Stats("Dribble", driblle),
                new Stats("Passing", passing),
                new Stats("Shooting", shooting)
                );

            teams[nameTeam].AddPlayerMethod(newPlayer);
        }


        private static void CreateNewTeam(string teamName)
        {
            Team newTeam = new Team(teamName);
            teams.Add(teamName, newTeam);
        }
    }
}
