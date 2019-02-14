using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithumConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // Set a candidate solution
            FitnessCalc.setSolution("11110000000111001011101101110001111000011000001111111111101110001100111111000110011101001111111100101101000100011110000000110001111");

            // Create an initial population
            Population myPop = new Population(3, true);

            // Evolve our population until we reach an optimum solution
            int generationCount = 0;
            while (myPop.getFittest().getFitness() < FitnessCalc.getMaxFitness())
            {
                generationCount++;
                Console.WriteLine("Generation: " + generationCount + " Fittest: " + myPop.getFittest().getFitness() + " / " + FitnessCalc.getMaxFitness());
                myPop = Algorithm.evolvePopulation(myPop);
            }
            Console.WriteLine("Solution found!");
            Console.WriteLine("Generation: " + generationCount);
            Console.WriteLine("Genes:");
            Console.WriteLine(myPop.getFittest());
            Console.ReadLine();
        }
    }
}
