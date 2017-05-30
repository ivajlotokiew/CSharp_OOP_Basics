using System;
using System.Collections.Generic;

namespace _06.Problem_NewVersion.Models
{
    public class Team
    {
        private string name;
        private int rating;
        private Dictionary<string, Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.rating = 0;
            this.players = new Dictionary<string, Player>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"A {nameof(this.name)} should not be empty.");
                }

                this.name = value;
            }
        }

        public int Rating
        {
            get { return this.rating; }
            private set { value = this.rating; }
        }

        public void AddPlayerMethod(Player newPlayer)
        {
            this.rating += newPlayer.Skills;
            this.players.Add(newPlayer.Name, newPlayer);
        }

        public void RemovePlayerMethod(string playerNameToRemove)
        {
            if (!this.players.ContainsKey(playerNameToRemove))
            {
                throw new ArgumentException($"Player {playerNameToRemove} is not in {this.Name} team.");
            }

            this.rating -= this.players[playerNameToRemove].Skills;
            this.players.Remove(playerNameToRemove);
        }
    }
}
