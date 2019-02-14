using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithumConsole
{
    class Individual
    {
        static int defaultGeneLength = 131;
        private byte[] genes = new byte[defaultGeneLength];
        // Cache
        private int fitness = 0;
        public static Random random = new Random();

        // Create a random individual
        public void generateIndividual()
        {
            for (int i = 0; i < size(); i++)
            {
                byte gene = (byte)Math.Round(random.NextDouble());
                genes[i] = gene;
            }
        }

        /* Getters and setters */
        // Use this if you want to create individuals with different gene lengths
        public static void setDefaultGeneLength(int length)
        {
            defaultGeneLength = length;
        }

        public byte getGene(int index)
        {
            return genes[index];
        }

        public void setGene(int index, byte value)
        {
            genes[index] = value;
            fitness = 0;
        }

        /* Public methods */
        public int size()
        {
            return genes.Length;
        }

        public int getFitness()
        {
            if (fitness == 0)
            {
                fitness = FitnessCalc.getFitness(this);
            }
            return fitness;
        }

     
        public override string ToString()
        {
            string geneString = "";
            for (int i = 0; i < size(); i++)
            {
                geneString += getGene(i);
            }
            return geneString;
        }
    }
}
