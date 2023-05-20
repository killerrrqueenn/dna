using System;

namespace DNAReplicator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Input half of a DNA sequence: ");
                string dnaHalfSequence = Console.ReadLine();

                if (IsSequenceValid(dnaHalfSequence))
                {
                    Console.WriteLine($"Given half DNA sequence: {dnaHalfSequence}");
                    Console.Write("Would you like to replicate this sequence? (Y/N) : ");
                    char userDecision = GetUserDecision();

                    if (userDecision == 'Y')
                    {
                        string replicatedDnaSequence = ReplicateDNASequence(dnaHalfSequence);
                        Console.WriteLine($"Replicated half DNA sequence: {replicatedDnaSequence}");
                    }

                    Console.Write("Would you like to process another DNA sequence? (Y/N) : ");
                    userDecision = GetUserDecision();

                    if (userDecision == 'N')
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("The provided half DNA sequence is not valid.");
                    Console.Write("Would you like to process another DNA sequence? (Y/N) : ");
                    char userDecision = GetUserDecision();

                    if (userDecision == 'N')
                    {
                        break;
                    }
                }
            }
        }

        static bool IsSequenceValid(string dnaHalfSequence)
        {
            foreach (char nucleotide in dnaHalfSequence)
            {
                if (!"ATCG".Contains(nucleotide))
                {
                    return false;
                }
            }
            return true;
        }

        static string ReplicateDNASequence(string dnaHalfSequence)
        {
            string replicatedSequence = "";
            foreach (char nucleotide in dnaHalfSequence)
            {
                replicatedSequence += "TAGC"["ATCG".IndexOf(nucleotide)];
            }
            return replicatedSequence;
        }

        static char GetUserDecision()
        {
            char userDecision;
            while (true)
            {
                userDecision = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (userDecision == 'Y' || userDecision == 'N')
                {
                    break;
                }
                else
                {
                    Console.Write("Please enter Y or N: ");
                }
            }
            return userDecision;
        }
    }
}
