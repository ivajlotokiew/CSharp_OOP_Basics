using System;
using System.Runtime.CompilerServices;

namespace _06.Problem_NewVersion.Models
{
    public class Player
    {
        private string name;
        private int skills;

        public Player(string name, Stats endurance, Stats sprint, Stats dribble, Stats passing, Stats shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
            this.CalculateMethod();
        }

        public Stats Endurance { get; }
        public Stats Sprint { get; }
        public Stats Dribble { get; }
        public Stats Passing { get; }
        public Stats Shooting { get; }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"A {nameof(this.name)} should not be empty.");
                }

                this.name = value;
            }
        }

        public int Skills
        {
            get { return this.skills; }
            set { this.skills = value; }
        }

        private void CalculateMethod()
        {
            this.Skills = (int)Math.Round((this.Endurance.Range + this.Shooting.Range +
                this.Dribble.Range + this.Passing.Range + this.Sprint.Range) / 5.0);
        }
    }
}
