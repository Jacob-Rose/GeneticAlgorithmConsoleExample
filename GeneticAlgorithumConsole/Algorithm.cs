using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithumConsole
{
    class Algorithm
    {
        /* GA parameters */
        private const double uniformRate = 0.5;
        private const double mutationRate = 0.025;
        private const int tournamentSize = 5;
        private const bool elitism = true;
        public static Random random = new Random();

    /* Public methods */
    
    // Evolve a population
    public static Population evolvePopulation(Population pop)
        {
            Population newPopulation = new Population(pop.size(), false);

            // Keep our best individual
            if (elitism)
            {
                newPopulation.saveIndividual(0, pop.getFittest());
            }

            // Crossover population
            int elitismOffset;
            if (elitism)
            {
                elitismOffset = 1;
            }
            else
            {
                elitismOffset = 0;
            }
            // Loop over the population size and create new individuals with
            // crossover
            for (int i = elitismOffset; i < pop.size(); i++)
            {
                Individual indiv1 = tournamentSelection(pop);
                Individual indiv2 = tournamentSelection(pop);
                Individual newIndiv = crossover(indiv1, indiv2);
                newPopulation.saveIndividual(i, newIndiv);
            }

            // Mutate population
            for (int i = elitismOffset; i < newPopulation.size(); i++)
            {
                mutate(newPopulation.getIndividual(i));
            }

            return newPopulation;
        }

        // Crossover individuals
        private static Individual crossover(Individual indiv1, Individual indiv2)
        {
            Individual newSol = new Individual();
            // Loop through genes
            for (int i = 0; i < indiv1.size(); i++)
            {
                // Crossover
                if (new Random().NextDouble() <= uniformRate)
                {
                    newSol.setGene(i, indiv1.getGene(i));
                }
                else
                {
                    newSol.setGene(i, indiv2.getGene(i));
                }
            }
            return newSol;
        }

        // Mutate an individual
        private static void mutate(Individual indiv)
        {
            // Loop through genes
            for (int i = 0; i < indiv.size(); i++)
            {
                if (random.NextDouble() <= mutationRate)
                {
                    // Create random gene
                    byte gene = (byte)Math.Round(random.NextDouble());

                    indiv.setGene(i, gene);
                }
            }
        }

        // Select individuals for crossover
        private static Individual tournamentSelection(Population pop)
        {
            // Create a tournament population
            Population tournament = new Population(tournamentSize, false);
            // For each place in the tournament get a random individual
            for (int i = 0; i < tournamentSize; i++)
            {
                int randomId = (int)(random.NextDouble() * pop.size());
                tournament.saveIndividual(i, pop.getIndividual(randomId));
            }
            // Get the fittest
            Individual fittest = tournament.getFittest();
            return fittest;
        }
    }
}
