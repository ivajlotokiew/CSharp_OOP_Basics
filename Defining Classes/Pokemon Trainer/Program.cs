using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Problem
{
    public class Pokemon
    {
        public string namePokemon;
        public string elementPokemon;
        public int healthPokemon;

        public Pokemon(string namePokemon, string elementPokemon, int healthPokemon)
        {
            this.namePokemon = namePokemon;
            this.elementPokemon = elementPokemon;
            this.healthPokemon = healthPokemon;
        }
    }

    public class Trainer
    {
        public string nameTrainer;
        public int numbersOfBags;
        public List<Pokemon> listOfPokemons;

        public Trainer(string nameTrainer)
        {
            this.nameTrainer = nameTrainer;
            this.numbersOfBags = 0;
            this.listOfPokemons = new List<Pokemon>();
        }

        public bool TournamentMethod(string elementPokemon)
        {
            if (this.listOfPokemons.Any(st => st.elementPokemon == elementPokemon))
            {
                this.numbersOfBags += 1;
                return true;
            }
            List<Pokemon> list = new List<Pokemon>();
            foreach (var pokemon in this.listOfPokemons.Select(st =>
            {
                st.healthPokemon -= 10;
                return st;
            }))
                list.Add(pokemon);

            return false;
        }
    }

    public class PokemonTrainer
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            List<Trainer> dataTrainers = new List<Trainer>();

            while (input != "Tournament")
            {
                string[] inputData = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string trainerName = inputData[0];
                string pokName = inputData[1];
                string pokElement = inputData[2];
                int pokHealth = int.Parse(inputData[3]);
                var currentPokemonData = new Pokemon(pokName, pokElement, pokHealth);
                if (dataTrainers.Any(st => st.nameTrainer == trainerName))
                {
                    var listIndex =
                        dataTrainers
                            .Select((st, i) => new
                            {
                                searchedName = st.nameTrainer,
                                index = i
                            }).First(f => f.searchedName == trainerName).index;

                    dataTrainers[listIndex].listOfPokemons.Add(currentPokemonData);
                }
                else
                {
                    var currentDataTrainer = new Trainer(trainerName);
                    currentDataTrainer.listOfPokemons.Add(currentPokemonData);
                    dataTrainers.Add(currentDataTrainer);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                foreach (var dataTrainer in dataTrainers)
                {
                    if (!dataTrainer.TournamentMethod(input))
                    {
                        CheckPockemonHealthInObj(dataTrainer);
                    }
                }

                input = Console.ReadLine();
            }

            PrintMethod(dataTrainers);
        }

        public static void CheckPockemonHealthInObj(Trainer trainer)
        {
            trainer.listOfPokemons.RemoveAll(st => st.healthPokemon <= 0);
        }

        public static void PrintMethod(List<Trainer> dataTrainers)
        {
            dataTrainers
                .OrderByDescending(st => st.numbersOfBags)
                .ToList()
                .ForEach(st => Console.WriteLine($"{st.nameTrainer} " +
                                                $"{st.numbersOfBags} " +
                                                $"{st.listOfPokemons.Count}"));
        }
    }
}